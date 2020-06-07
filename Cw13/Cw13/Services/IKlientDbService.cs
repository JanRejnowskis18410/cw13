using Cw13.Models;
using System.Collections.Generic;

namespace Cw13.Services
{
    public interface IKlientDbService
    {
        public bool CheckIfClientExists(string surname);

        public ICollection<ZamowienieKlientWyrobCukierniczy> GetClientsOrders();

        public ICollection<ZamowienieKlientWyrobCukierniczy> GetClientOrders(string surname);
    }
}
