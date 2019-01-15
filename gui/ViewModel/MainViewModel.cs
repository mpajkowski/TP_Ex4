using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Commands;
using services;
using app.Model;
using System.Windows.Forms;
using System.Windows.Controls;

namespace app.ViewModel
{
    class MainViewModel : BindableBase
    {
        private ObservableCollection<Client> clients;
        public ObservableCollection<Client> Clients
        {
            get => clients;
            set
            {
                clients = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Dog> dogs;
        public ObservableCollection<Dog> Dogs
        {
            get => dogs;
            set
            {
                dogs = value;
                RaisePropertyChanged();
            }
        }

        private bool showDogs;
        public bool ShowDogs
        {
            get => showDogs;
            set
            {
                showDogs = value;
                RaisePropertyChanged();
            }
        }

        private String newClientName;
        public String NewClientName
        {
            get => newClientName;
            set
            {
                newClientName = value;
                RaisePropertyChanged();
            }
        }

        private String newClientSurname;
        public String NewClientSurname
        {
            get => newClientSurname;
            set
            {
                newClientSurname = value;
                RaisePropertyChanged();
            }
        }

        private void PopulateClientData()
        {
            IEnumerable<Client> fetchedClients = DataHandling.GetClientsList();

            Clients = new ObservableCollection<Client>(fetchedClients);
            ShowDogs = false;
            MessageBox.Show("Done!");
        }

        private void PopulateDogData()
        {
            IEnumerable<Dog> fetchedDogs = DataHandling.GetDogsList();

            Dogs = new ObservableCollection<Dog>(fetchedDogs);
            ShowDogs = true;
            MessageBox.Show("Done!");
        }

        public DelegateCommand GetClientDataCmd { get; private set; }
        public DelegateCommand GetDogDataCmd { get; private set; }

        public MainViewModel()
        {
            clients = new ObservableCollection<Client>();
            dogs = new ObservableCollection<Dog>();
            ShowDogs = false;
            GetClientDataCmd = new DelegateCommand(PopulateClientData);
            GetDogDataCmd = new DelegateCommand(PopulateDogData);
        }
    }
}
