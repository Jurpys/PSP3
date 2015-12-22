using System;
using PSP3.Controllers;

namespace PSP3.Views
{
    public class OrderUIView
    {
        private OrderController _controller;
        public void Initialize(OrderController controller)
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
            ConsoleHelper.WaitForSpace(_controller);
        }

        private void UndoLastOperation()
        {
            _controller.UndoLastOperation();
            Console.Clear();
            Console.WriteLine("Last operation has been successfully undone");
            ConsoleHelper.WaitForSpace(_controller);
        }

        private void UpdateOrder()
        {
            var id = ConsoleHelper.GetIntInput("Enter id");

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

            var val = ConsoleHelper.GetIntInput("Enter new destination");

            _controller.UpdateOrderDestination(id, val);

            Console.Clear();
            Console.WriteLine("Order has been successfully updated");
            ConsoleHelper.WaitForSpace(_controller);
        }

        private void DeleteOrder()
        {
            var id = ConsoleHelper.GetIntInput("Enter id");

            _controller.DeleteOrderById(id);
            Console.Clear();
            Console.WriteLine("Order has been successfully deleted");
            ConsoleHelper.WaitForSpace(_controller);

        }

        private void OpenOrderDetails()
        {
            var id = ConsoleHelper.GetIntInput("Enter id");

            var model = _controller.GetOrderDetailsById(id);

            Console.Clear();
            model.Display();
            ConsoleHelper.WaitForSpace(_controller);
        }

        private void CreateNewOrder()
        {
            Console.Clear();

            var destination = ConsoleHelper.GetIntInput("Enter Destination");

            _controller.NewOrder(destination);

            Console.Clear();
            Console.WriteLine("Order has been successfully registered");
            ConsoleHelper.WaitForSpace(_controller);
        }
    }
}