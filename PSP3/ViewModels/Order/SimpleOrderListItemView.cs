using System;
using PSP3.Domain;
using PSP3.Repositories;

namespace PSP3.ViewModels
{
    public class SimpleOrderListItemView : OrderView
    {
        OrderRepository _orderRepository;

        public string IsTaken;
        public int Destination;
        public double Price;

        public SimpleOrderListItemView(int id, OrderRepository orderRepository) : base(id)
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
            Console.Write($"Id: {_id} | ");
            Console.Write($"Is taken: {IsTaken} | ");
            Console.Write($"Destination: {Destination} | ");
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