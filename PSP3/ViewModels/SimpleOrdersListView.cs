using System;
using System.Collections.Generic;
using System.Linq;
using PSP3.Repositories;

namespace PSP3.ViewModels
{
    public class SimpleOrdersListView : OrderListView
    {
        List<OrdersListItemModel> _orders; 
        public SimpleOrdersListView(OrderRepository repository) : base(repository)
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
            Console.WriteLine(" -- All Orders List -- ");

            foreach (var order in _orders)
            {
                Console.Write("Id: {0} | ", order.Id);
                Console.Write("Destination: {0} | ", order.Destination);
                Console.WriteLine("Is taken: {0} | ", order.IsTaken ? "Yes" : "No");
            }
        }
    }
}