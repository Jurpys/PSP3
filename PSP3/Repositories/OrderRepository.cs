using System.Collections.Generic;
using PSP3.Domain;

namespace PSP3.Repositories
{
    public class OrderRepository
    {
        private int lastId = 1;

        private Dictionary<int, IOrder> orders = new Dictionary<int, IOrder>();

        public void Save(IOrder order)
        {
            if (order.Id == 0)
            {
                order.Id = lastId++;
            }

            orders.Add(order.Id, order);
        }

        public IOrder Find(int orderId)
        {
            return orders[orderId];
        }

        public ICollection<IOrder> FindAll()
        {
            return orders.Values;
        }

        public void Delete(int orderId)
        {
            orders.Remove(orderId);
        }
    }
}