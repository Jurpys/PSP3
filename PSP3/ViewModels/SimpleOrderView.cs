using System;
using PSP3.Repositories;

namespace PSP3.ViewModels
{
    public class SimpleOrderView : OrderView
    {
        OrderRepository _orderRepository;
        public SimpleOrderView(int id, OrderRepository orderRepository) : base(id)
        {
            _orderRepository = orderRepository;
        }

        public override void Display()
        {
            base.Display();
            var order = _orderRepository.Find(_id);
            Console.WriteLine(order.Destination);
        }
    }
}