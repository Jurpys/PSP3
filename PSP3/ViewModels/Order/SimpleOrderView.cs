﻿using System;
using PSP3.DomainService;

namespace PSP3.ViewModels
{
    public class SimpleOrderView : OrderView
    {
        IOrderRepository _IOrderRepository;

        public string IsTaken;
        public int Destination;
        public double Price;

        OrderViewAdapter adapter = new OrderViewAdapter();

        public SimpleOrderView(int id, IOrderRepository IOrderRepository) : base(id)
        {
            _IOrderRepository = IOrderRepository;
            Initilize();
        }

        protected override void Update(ObservableOrder order)
        {
            IsTaken = adapter.GetOrderIsTaken(order);
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
            var order = _IOrderRepository.Find(_id);
            order.AttachObserver(this);
            Update(order);
        }
    }
}