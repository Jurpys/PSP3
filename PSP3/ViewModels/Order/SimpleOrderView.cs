using System;
using PSP3.Domain;
using PSP3.Repositories;

namespace PSP3.ViewModels
{
    public class SimpleOrderView : OrderView
    {
        OrderRepository _orderRepository;

        public string IsTaken;
        public string Destination;
        public double Price;

        public SimpleOrderView(int id, OrderRepository orderRepository) : base(id)
        {
            _orderRepository = orderRepository;
            Initilize();
        }

        protected override void Update(ObservableOrder order)
        {
            IsTaken = order.IsTaken ? "Yes" : "No";
            Destination = order.Destination;
            Price = order.Price ?? 0;
        }

        public override void Display()
        {
            Console.WriteLine($"Order {_id}:");
            Console.WriteLine($"Is taken: {IsTaken}");
            Console.WriteLine($"Destination: {Destination}");
            Console.WriteLine($"Price: {Price}");
        }

        private void Initilize()
        {
            var order = _orderRepository.Find(_id);
            order.AttachObserver(this);
            Update(order);
        }
    }
}