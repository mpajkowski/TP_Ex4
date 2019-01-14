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

        public static async Task<IEnumerable<Client>> GetClientsList()
        {
            IEnumerable<Client> clientList = null;
            var job = await Task.Run(() => clientList = Repository.GetClientsList());
            return clientList; 
        }
        public static async Task<Client> GetClientById(int id)
        {
            Client client = null;
            await Task.Run(() => client = Repository.GetClientById(id));
            return client;
        }

        public static async Task<IEnumerable<Dog>> GetDogsList()
        {
            IEnumerable<Dog> dogList = null;
            await Task.Run(() => dogList = Repository.GetDogsList());
            return dogList; 
        }

        public static async Task<Dog> GetDogById(int id)
        {
            Dog dog = null;
            await Task.Run(() => dog = Repository.GetDogById(id));
            return dog;
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
