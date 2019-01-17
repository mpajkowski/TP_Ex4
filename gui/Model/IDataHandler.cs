using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using services;

namespace app.Model
{
    public interface IDataHandler
    {
        void CreateClientEntry(Client client);
        void CreateDogEntry(Dog dog);
        IEnumerable<Client> GetClientsList();
        Client GetClientById(int id);
        IEnumerable<Dog> GetDogsList();
        Dog GetDogById(int id);
        void DeleteClient(Client client);
        void DeleteDog(Dog dog);
        void UpdateClientData(Client client);
        void UpdateDogData(Dog dog);
    }
}
