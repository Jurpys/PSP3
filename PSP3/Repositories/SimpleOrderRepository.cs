using System.Collections.Generic;
using PSP3.Domain;
using PSP3.Repositories;

namespace PSP3.Repositories
{
    public class SimpleOrderRepository : IOrderRepository
    {
        private int lastId = 1;

        private Dictionary<int, ObservableOrder> orders = new Dictionary<int, ObservableOrder>();

        public void Save(ObservableOrder order)
        {
            if (order.Id == 0)
            {
                order.Id = lastId++;
            }

            orders.Add(order.Id, order);
        }

        public ObservableOrder Find(int orderId)
        {
            return orders[orderId];
        }

        public ICollection<ObservableOrder> FindAll()
        {
            return orders.Values;
        }

        public void Delete(int orderId)
        {
            orders.Remove(orderId);
        }
    }
}