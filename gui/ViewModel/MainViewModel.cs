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
using System.Collections.Specialized;

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

        private Client currentClient;
        public Client CurrentClient
        {
            get => currentClient;
            set
            {
                currentClient = value;
                RaisePropertyChanged();
            }
        }

        private Dog currentDog;
        public Dog CurrentDog
        {
            get => currentDog;
            set
            {
                currentDog = value;
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

        public String newDogName;
        public String NewDogName
        {
            get => newDogName;
            set
            {
                newDogName = value;
                RaisePropertyChanged();
            }
        }

        private void PopulateClientData()
        {
            IEnumerable<Client> fetchedClients = DataHandling.GetClientsList();

            Clients = new ObservableCollection<Client>(fetchedClients);
        }

        private void PopulateDogData()
        {
            IEnumerable<Dog> fetchedDogs = DataHandling.GetDogsList();

            Dogs = new ObservableCollection<Dog>(fetchedDogs);
        }

        private void UpdateCurrentClient()
        {
            if (CurrentClient != null)
            {
                DataHandling.UpdateClientData(currentClient);
            }
        }

        private void UpdateCurrentDog()
        {
            if (CurrentDog != null)
            {
                DataHandling.UpdateDogData(currentDog);
            }
        }

        private void DeleteCurrentClient()
        {
            if (CurrentClient != null)
            {
                DataHandling.DeleteClient(currentClient);
                Clients.Remove(CurrentClient);
            }
        }

        private void DeleteCurrentDog()
        {
            if (CurrentDog != null)
            {
                DataHandling.DeleteDog(CurrentDog);
                Dogs.Remove(CurrentDog);
            }
        }

        public DelegateCommand GetClientDataCmd { get; private set; }
        public DelegateCommand GetDogDataCmd { get; private set; }

        public DelegateCommand UpdateCurrentClientCmd { get; private set; }
        public DelegateCommand UpdateCurrentDogCmd { get; private set; }

        public DelegateCommand DeleteCurrentClientCmd { get; private set; }
        public DelegateCommand DeleteCurrentDogCmd { get; private set; }

        public MainViewModel()
        {
            clients = new ObservableCollection<Client>();
            dogs = new ObservableCollection<Dog>();

            GetClientDataCmd = new DelegateCommand(PopulateClientData);
            GetDogDataCmd = new DelegateCommand(PopulateDogData);

            UpdateCurrentClientCmd = new DelegateCommand(UpdateCurrentClient);
            UpdateCurrentDogCmd = new DelegateCommand(UpdateCurrentDog);

            DeleteCurrentClientCmd = new DelegateCommand(DeleteCurrentClient);
            DeleteCurrentDogCmd = new DelegateCommand(DeleteCurrentDog);

            PopulateClientData(); 
        }
    }
}
