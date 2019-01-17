using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Model;
using services;

namespace appTests.Model
{
    class DataHandlerMock : IDataHandler
    {
        public int CreateClientEntryHits { get; private set; }
        public int CreateDogEntryHits { get; private set; }
        public int DeleteClientHits { get; private set; }
        public int DeleteDogHits { get; private set; }
        public int UpdateClientDataHits { get; private set; }
        public int UpdateDogDataHits { get; private set; }

        private List<Client> fakeClientsList;
        private List<Dog> fakeDogsList;

        public void CreateClientEntry(Client client)
        {
            ++CreateClientEntryHits;
        }

        public void CreateDogEntry(Dog dog)
        {
            ++CreateDogEntryHits;
        }

        public IEnumerable<Client> GetClientsList()
        {
            return fakeClientsList;
        }

        public Client GetClientById(int id)
        {
            return fakeClientsList.Where((cl) => id == cl.client_id).SingleOrDefault();
        }

        public IEnumerable<Dog> GetDogsList()
        {
            return fakeDogsList;
        }

        public Dog GetDogById(int id)
        {
            return fakeDogsList.Where((dog) => id == dog.dog_id).SingleOrDefault();
        }

        public void DeleteClient(Client client)
        {
            ++DeleteClientHits;
        }

        public void DeleteDog(Dog dog)
        {
            ++DeleteDogHits;
        }

        public void UpdateClientData(Client client)
        {
            ++UpdateClientDataHits;
        }

        public void UpdateDogData(Dog dog)
        {
            ++UpdateDogDataHits;
        }

        public DataHandlerMock()
        {
            Client c1 = new Client();
            c1.client_id = 1;
            c1.client_name = "Andrzej";
            c1.client_surname = "Zupa";

            Client c2 = new Client();
            c2.client_id = 2;
            c2.client_name = "Jerzy";
            c2.client_surname = "Szczypiorek";

            Client c3 = new Client();
            c3.client_id = 3;
            c3.client_name = "Anna";
            c3.client_surname = "Warzywniak";

            fakeClientsList = new List<Client>();
            fakeClientsList.Add(c1);
            fakeClientsList.Add(c2);
            fakeClientsList.Add(c3);

            Dog d1 = new Dog();
            d1.dog_id = 1;
            d1.dog_name = "Fafik";
            d1.dog_owner_id = 1;

            Dog d2 = new Dog();
            d2.dog_id = 2;
            d2.dog_name = "Wróbel";
            d2.dog_owner_id = 2;

            fakeDogsList = new List<Dog>();
            fakeDogsList.Add(d1);
            fakeDogsList.Add(d2);
        }
    }
}
