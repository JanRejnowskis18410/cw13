using Cw13.DTOs.Requests;
using Cw13.Models;
using System.Collections.Generic;

namespace Cw13.Services
{
    public interface IKlientDbService
    {
        public bool CheckIfEmployeeExists(int id);
        public bool CheckIfClientExists(string surname);
        public bool CheckIfClientExists(int id);
        public ICollection<OrderInfo> GetClientsOrders();
        public ICollection<OrderInfo> GetClientOrders(string surname);
        public string CheckIfProductsExistst(CreateNewOrderRequest request);
        public void AddNewOrder(CreateNewOrderRequest request, int clientId);
    }
}
