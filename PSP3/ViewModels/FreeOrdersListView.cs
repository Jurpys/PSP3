using System;
using System.Collections.Generic;
using System.Linq;
using PSP3.Repositories;
using PSP3.ViewModels;

namespace PSP3.ViewModels
{
    public class FreeOrdersListView : OrderListView
    {
        List<OrdersListItemModel> _orders; 
        public FreeOrdersListView(OrderRepository repository) : base(repository)
        {
        }

        protected override void UpdateFields()
        {
            var orders = _repository.FindAll().ToList().Where(o => !o.IsTaken);

            _orders = new List<OrdersListItemModel>();

            foreach (var order in orders)
            {
                _orders.Add(new OrdersListItemModel()
                {
                    Destination = order.Destination,
                    Id = order.Id
                });
            }
        }

        public override void Display()
        {
            UpdateFields();
            Console.WriteLine(" -- Free Orders List -- ");

            foreach (var order in _orders)
            {
                Console.Write("Id: {0} | ", order.Id);
                Console.WriteLine("Destination: {0}", order.Destination);
            }
        }
    }
}