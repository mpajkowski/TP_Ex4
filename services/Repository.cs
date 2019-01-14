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

        public static void CreateVehicle(Vehicle vehicle)
        {
            Context.Vehicles.InsertOnSubmit(vehicle);
            Context.SubmitChanges();
        }

        public static List<Client> GetClients()
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

        public static List<Vehicle> GetVehicles()
        {
            return (from vehicle in Context.Vehicles select vehicle).ToList();
        }

        public static Vehicle GetVehicleById(int id)
        {
            return (from vehicle in Context.Vehicles
                    where id == vehicle.client_id
                    select vehicle)
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
        public static void DeleteCar(Vehicle vehicle)
        {
            Vehicle toRemove = (from item in Context.Vehicles
                               where item.vehicle_id == vehicle.vehicle_id
                               select item)
                               .First();

            if (toRemove != null)
            {
                Context.Vehicles.DeleteOnSubmit(toRemove);
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
        public static void UpdateVehicleOwner(Vehicle vehicle, Client newOwner)
        {
            Vehicle toUpdate = (from item in Context.Vehicles
                               where item.vehicle_id == vehicle.vehicle_id
                               select item)
                               .Single();

            int newOwnerId = newOwner.client_id;
            toUpdate.client_id = newOwnerId;

            Context.SubmitChanges();
        }
    }
}
