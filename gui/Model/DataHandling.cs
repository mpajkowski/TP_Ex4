using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using services;

namespace app.Model
{
    class DataHandler : IDataHandler
    {
        public static readonly int VARCHAR_COUNT = 50;

        public void CreateClientEntry(Client client)
        {
            Task.Run(() => Repository.CreateClientEntry(client));
        }

        public void CreateDogEntry(Dog dog)
        {
            Task.Run(() => Repository.CreateDogEntry(dog));
        }

        public IEnumerable<Client> GetClientsList()
        {
            return Repository.GetClientsList();
        }
        public Client GetClientById(int id)
        {
            return Repository.GetClientById(id);
        }

        public IEnumerable<Dog> GetDogsList()
        {
            return Repository.GetDogsList();
        }

        public Dog GetDogById(int id)
        {
            return Repository.GetDogById(id);
        }

        public void DeleteClient(Client client)
        {
            Task.Run(() => Repository.DeleteClient(client));
        }

        public void DeleteDog(Dog dog)
        {
            Task.Run(() => Repository.DeleteDog(dog));
        }

        public void UpdateClientData(Client client)
        {
            Task.Run(() => Repository.UpdateClientData(client));
        }

        public void UpdateDogData(Dog dog)
        {
            Task.Run(() => Repository.UpdateDogData(dog));
        }
    }
}
