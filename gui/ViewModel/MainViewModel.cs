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

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("appTests")]

class DialogService : IDialogService
{
    public void Show(string text)
    {
        MessageBox.Show(text);
    }
}

namespace app.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private static readonly string TEXT_TOO_LONG 
            = "Dane zawierają nieprawidłowy format (długość imienia lub nazwiska jest większa niż 50 znaków)";
        private static readonly string CLIENT_NOT_FOUND
            = "Nie znaleziono klienta o podanym ID";
        private static readonly string EMPTY_BOX = "Puste pole!";
        private static readonly string DATA_UPDATED = "Zaaktualizowao dane!";

        private IDataHandler dataHandler;
        private IDialogService dialogService;

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

        public String newDogOwner;
        public String NewDogOwner
        {
            get => newDogOwner;
            set
            {
                newDogOwner = value;
                RaisePropertyChanged();
            }
        }

        internal void PopulateClientData()
        {
            IEnumerable<Client> fetchedClients = dataHandler.GetClientsList();
            Clients = new ObservableCollection<Client>(fetchedClients);
        }

        internal void PopulateDogData()
        {
            IEnumerable<Dog> fetchedDogs = dataHandler.GetDogsList();
            Dogs = new ObservableCollection<Dog>(fetchedDogs);
        }

        internal void UpdateCurrentClient()
        {
            if (CurrentClient == null)
            {
                return;
            }

            if (CurrentClient.client_name.Length >= 50
                || CurrentClient.client_surname.Length >= 50)
            {
                dialogService.Show(TEXT_TOO_LONG);
                return;
            }

            if (CurrentClient.client_name == String.Empty
                || CurrentClient.client_surname == String.Empty)
            {
                dialogService.Show(EMPTY_BOX);
                return;
            }

            dataHandler.UpdateClientData(currentClient);
            dialogService.Show(DATA_UPDATED);
        }

        internal void UpdateCurrentDog()
        {
            if (CurrentDog == null)
            {
                return;
            }
            
            if (CurrentDog.dog_name.Length >= DataHandler.VARCHAR_COUNT)
            {
                dialogService.Show(TEXT_TOO_LONG);
                return;
            }

            if (!CurrentDog.dog_owner_id.HasValue || CurrentDog.dog_name == String.Empty)
            {
                dialogService.Show(EMPTY_BOX);
                return;
            }

            Client client = dataHandler.GetClientById(currentDog.dog_owner_id.Value);

            if (client == null)
            {
                dialogService.Show(CLIENT_NOT_FOUND);
            }
            else
            {
                dataHandler.UpdateDogData(currentDog);
                dialogService.Show(DATA_UPDATED);
            }

        }

        internal void CreateNewClient()
        {
            if (NewClientName.Length >= DataHandler.VARCHAR_COUNT
                && NewClientSurname.Length >= DataHandler.VARCHAR_COUNT)
            {
                dialogService.Show(TEXT_TOO_LONG);
                return;
            }

            if (NewClientName == String.Empty
                || NewClientSurname == String.Empty)
            {
                dialogService.Show(EMPTY_BOX);
                return;
            }

            Client newClient = new Client
            {
                client_name = NewClientName,
                client_surname = NewClientSurname
            };

            dataHandler.CreateClientEntry(newClient);
            dialogService.Show(DATA_UPDATED);
        }

        internal void CreateNewDog()
        {
            if (NewDogName.Length >= DataHandler.VARCHAR_COUNT)
            {
                dialogService.Show(TEXT_TOO_LONG);
                return;
            }

            int newOwnerId = 0;
            try
            {
                newOwnerId = int.Parse(NewDogOwner);
            }
            catch (Exception)
            {
                return;
            }

            Client newOwner = dataHandler.GetClientById(newOwnerId);
            if (newOwner == null)
            {
                dialogService.Show(CLIENT_NOT_FOUND);
                return;
            }

            Dog newDog = new Dog()
            {
                dog_name = NewDogName,
                dog_owner_id = newOwnerId
            };

            dataHandler.CreateDogEntry(newDog);
            dialogService.Show(DATA_UPDATED);
        }

        internal void DeleteCurrentClient()
        {
            if (CurrentClient != null)
            {
                foreach (var dog in dataHandler.GetDogsList())
                {
                    if (dog.dog_owner_id == CurrentClient.client_id)
                    {
                        dialogService.Show("Nie można usunąć klienta, który ma odwołanie do psa!");
                        return;
                    }
                }

                dataHandler.DeleteClient(currentClient);
                Clients.Remove(CurrentClient);
                dialogService.Show(DATA_UPDATED);
            }
        }

        internal void DeleteCurrentDog()
        {
            if (CurrentDog != null)
            {
                dataHandler.DeleteDog(CurrentDog);
                Dogs.Remove(CurrentDog);
                dialogService.Show(DATA_UPDATED);
            }
        }

        // for testing purposes
        internal void InjectDataHandler(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }

        // for testing purposes
        internal void InjectDialogService(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        public DelegateCommand GetClientDataCmd { get; private set; }
        public DelegateCommand GetDogDataCmd { get; private set; }

        public DelegateCommand UpdateCurrentClientCmd { get; private set; }
        public DelegateCommand UpdateCurrentDogCmd { get; private set; }

        public DelegateCommand CreateNewClientCmd { get; private set; }
        public DelegateCommand CreateNewDogCmd { get; private set; }

        public DelegateCommand DeleteCurrentClientCmd { get; private set; }
        public DelegateCommand DeleteCurrentDogCmd { get; private set; }

        public MainViewModel()
        {
            dataHandler = new DataHandler();
            dialogService = new DialogService();
            clients = new ObservableCollection<Client>();
            dogs = new ObservableCollection<Dog>();

            newClientName = String.Empty;
            newClientSurname = String.Empty;

            newDogName = String.Empty;
            newDogOwner = String.Empty;

            GetClientDataCmd = new DelegateCommand(PopulateClientData);
            GetDogDataCmd = new DelegateCommand(PopulateDogData);

            UpdateCurrentClientCmd = new DelegateCommand(UpdateCurrentClient);
            UpdateCurrentDogCmd = new DelegateCommand(UpdateCurrentDog);

            CreateNewClientCmd = new DelegateCommand(CreateNewClient);
            CreateNewDogCmd = new DelegateCommand(CreateNewDog);

            DeleteCurrentClientCmd = new DelegateCommand(DeleteCurrentClient);
            DeleteCurrentDogCmd = new DelegateCommand(DeleteCurrentDog);
        }
    }
}
