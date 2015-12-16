using System;
using PSP3.Commands;
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
            Console.WriteLine("2. Show order details");
            Console.WriteLine("3. Delete order");
            Console.WriteLine("4. Update order");
            Console.WriteLine("5. Register new order");
            Console.WriteLine("6. Undo last operation");
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    OpenOrdersList();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    OpenOrderDetails();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    DeleteOrder();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    UpdateOrder();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    CreateNewOrder();
                    break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    UndoLastOperation();
                    break;
            }
        }

        private void OpenOrdersList()
        {
            Console.Clear();

            var model = _controller.GetOrdersList();
            model.Display();
            WaitForSpace();
        }

        private void UndoLastOperation()
        {
            _controller.UndoLastOperation();
            Console.Clear();
            Console.WriteLine("Last operation has been successfully undone");
            WaitForSpace();
        }

        private void UpdateOrder()
        {
            var id = GetIdInput();

            var model = _controller.GetOrderDetailsById(id);

            Console.Clear();
            model.Display();
            Console.WriteLine("Which field do you want to change?");
            Console.WriteLine("1. Destination");

            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    UpdateDestination(id);
                    break;
            }
        }

        private void UpdateDestination(int id)
        {
            Console.Clear();

            var val = GetNewValue();

            _controller.UpdateOrderDestination(id, val);

            Console.Clear();
            Console.WriteLine("Order has been successfully updated");
            WaitForSpace();
        }

        private void DeleteOrder()
        {
            var id = GetIdInput();

            _controller.DeleteOrderById(id);
            Console.Clear();
            Console.WriteLine("Order has been successfully deleted");
            WaitForSpace();

        }

        private void OpenOrderDetails()
        {
            var id = GetIdInput();

            var model = _controller.GetOrderDetailsById(id);

            Console.Clear();
            model.Display();
            WaitForSpace();
        }

        private int GetIdInput()
        {
            Console.Clear();
            Console.WriteLine("Enter id of the order");
            var numericString = Console.ReadLine();
            int id;

            if (int.TryParse(numericString, out id))
            {
                return id;
            }

            Console.WriteLine("Bad input");
            Console.WriteLine("Press any key to try again");
            Console.ReadKey();

            return GetIdInput();
        }

        private void CreateNewOrder()
        {
            Console.Clear();
            Console.WriteLine("Enter the destination");

            var destination = Console.ReadLine();
            _controller.NewOrder(destination);

            Console.Clear();
            Console.WriteLine("Order has been successfully registered");
            WaitForSpace();
        }

        private void PrintOrders(IOrderView modelView)
        {
            Console.Clear();
            modelView.Display();
            WaitForSpace();
        }

        private void WaitForSpace()
        {
            Console.WriteLine("Press Spacebar to go back to menu");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar)
            {
            }

            _controller.InitializeView();
        }

        private string GetNewValue()
        {
            Console.WriteLine("Enter new value");
            return Console.ReadLine();
        }
    }
}