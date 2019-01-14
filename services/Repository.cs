using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    class Repository
    {
        private static DatabaseDataContext Context { get; set; } = new DatabaseDataContext();

        public static void CreateDogEntry(Dog dog)
        {
            Context.Dogs.InsertOnSubmit(dog);
            Context.SubmitChanges();
        }

        public static List<Client> GetClientsList()
        {
            return (from client in Context.Clients select client).ToList();
        }

        public static Client GetClientById(int id)
        {
            return (from client in Context.Clients
                    where id == client.client_id
                    select client)
                    .Single();
        }

        public static List<Dog> GetDogsList()
        {
            return (from dog in Context.Dogs select dog).ToList();
        }

        public static Dog GetDogById(int id)
        {
            return (from dog in Context.Dogs
                    where id == dog.dog_owner_id
                    select dog)
                    .Single();
        }
        public static void DeleteClient(Client client)
        {
            Client toRemove = (from item in Context.Clients
                               where item.client_id == client.client_id
                               select item)
                               .First();

            if (toRemove != null)
            {
                Context.Clients.DeleteOnSubmit(toRemove);
                Context.SubmitChanges();
            }
        }
        public static void DeleteDog(Dog dog)
        {
            Dog toRemove = (from item in Context.Dogs
                            where item.dog_id == dog.dog_id
                            select item)
                            .First();

            if (toRemove != null)
            {
                Context.Dogs.DeleteOnSubmit(toRemove);
                Context.SubmitChanges();
            }
        }

        public static void UpdateClientData(Client client)
        {
            Client toUpdate = (from item in Context.Clients
                               where item.client_id == client.client_id
                               select item)
                               .Single();

            toUpdate.client_id = client.client_id;
            toUpdate.client_name = client.client_name;
            toUpdate.client_surname = client.client_surname;

            Context.SubmitChanges();
        }
        public static void UpdateDogData(Dog dog)
        {
            Dog toUpdate = (from item in Context.Dogs
                            where item.dog_id == dog.dog_id
                            select item)
                            .Single();

            toUpdate.dog_name = dog.dog_name;
            toUpdate.dog_owner_id = dog.dog_owner_id;

            Context.SubmitChanges();
        }
    }
}
