using System;
using System.Collections.Generic;
using System.Linq;
using PSP3.Repositories;

namespace PSP3.ViewModels
{
    public class TakenOrdersListView : OrderListView
    {
        List<OrdersListItemModel> _orders; 
        public TakenOrdersListView(OrderRepository repository) : base(repository)
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
                    Id = order.Id,
                    IsTaken = order.IsTaken
                });
            }
        }

        public override void Display()
        {
            UpdateFields();

            Console.WriteLine(" -- Taken Orders List -- ");

            foreach (var order in _orders)
            {
                Console.Write("Id: {0} | ", order.Id);
                Console.WriteLine("Destination: {0}", order.Destination);
            }
        }
    }
}