using System;
using PSP3.Controllers;
using PSP3.ViewModels;

namespace PSP3.Views
{
    public class OrderMonitoring
    {
        private OrderMonitoringController _controller;
        public void Initialize(OrderMonitoringController controller)
        {
            _controller = controller;

            Console.Clear();
            Console.WriteLine("Order monitoring menu");
            Console.WriteLine("1. Show all orders");
            Console.WriteLine("2. Show all free orders");
            Console.WriteLine("3. Show all taken orders");
            Console.WriteLine("4. Show all finished orders");
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    GetAllOrders();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    GetAllFreeOrders();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    GetAllTakenOrders();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    GetAllFinishedOrders();
                    break;
            }
        }

        private void GetAllFinishedOrders()
        {
            PrintOrders(_controller.GetAllFinishedOrders());
        }

        private void GetAllTakenOrders()
        {
            PrintOrders(_controller.GetAllTakenOrders());
        }

        private void GetAllFreeOrders()
        {
            PrintOrders(_controller.GetAllFreeOrders());
        }

        private void GetAllOrders()
        {
            PrintOrders(_controller.GetAllOrders());
        }

        private void PrintOrders(IOrderView modelView)
        {
            Console.Clear();
            modelView.Display();
            Console.WriteLine("Press Spacebar to go back");

            while (Console.ReadKey().Key != ConsoleKey.Spacebar)
            {
            }

            _controller.InitializeView();
        }
    }
}