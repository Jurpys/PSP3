using System;
using PSP3.Controllers.Interfaces;

namespace PSP3.Views
{
    public static class ConsoleHelper
    {
        public static void WaitForSpace(IController controller)
        {
            Console.WriteLine("Press Spacebar to go back to menu");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar)
            {
            }

            controller.InitializeView();
        }

        public static string GetStringValue(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static int GetIntInput(string message)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(message);
                var numericString = Console.ReadLine();
                int id;

                if (int.TryParse(numericString, out id))
                {
                    return id;
                }

                Console.WriteLine("Bad input");
                Console.WriteLine("Press any key to try again");
                Console.ReadKey();
            }
        }
    }
}