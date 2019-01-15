using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using services;

namespace app.Model
{
    class DataHandling
    {
        public static void CreateClientEntry(Client client)
        {
            Task.Run(() => Repository.CreateClientEntry(client));
        }

        public static void CreateDogEntry(Dog dog)
        {
            Task.Run(() => Repository.CreateDogEntry(dog));
        }

        public static IEnumerable<Client> GetClientsList()
        {
            return Repository.GetClientsList();
        }
        public static Client GetClientById(int id)
        {
            return Repository.GetClientById(id);
        }

        public static IEnumerable<Dog> GetDogsList()
        {
            return Repository.GetDogsList();
        }

        public static Dog GetDogById(int id)
        {
            return Repository.GetDogById(id);
        }

        public static void DeleteClient(Client client)
        {
            Task.Run(() => Repository.DeleteClient(client));
        }

        public static void DeleteDog(Dog dog)
        {
            Task.Run(() => Repository.DeleteDog(dog));
        }

        public static void UpdateClientData(Client client)
        {
            Task.Run(() => Repository.UpdateClientData(client));
        }

        public static void UpdateDogData(Dog dog)
        {
            Task.Run(() => Repository.UpdateDogData(dog));
        }
    }
}
