using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.UI.WorkFlows;

namespace Flooring.UI
{
    public class MainMenu
    {
        public static void DisplayMainMenu()
        {
            Console.Clear();

            string input = "";
            do
            {
                Console.WriteLine("********** Floors - R - US **********");
                Console.WriteLine();
                Console.WriteLine("  1. Display Orders");
                Console.WriteLine();
                Console.WriteLine("  2. Add an Order");
                Console.WriteLine();
                Console.WriteLine("  3. Edit an Order");
                Console.WriteLine();
                Console.WriteLine("  4. Remove an Order");
                Console.WriteLine();
                Console.WriteLine("  5. Quit");
                Console.WriteLine();
                Console.Write("  Please enter your choice: ");
                input = Console.ReadLine();


                GetUserInput(input);

            } while (input != "5");


        }

        private static void GetUserInput(string input)
        {
            switch (input)
            {
                case "1":
                    DisplayWorkFlow display = new DisplayWorkFlow();
                    display.DisplayOrders();
                    break;
                case "2":
                    AddWorkFlow.CreateOrder();
                    break;
                case "3":
                    EditWorkFlow.EditOrder();
                    break;
                case "4":
                    RemoveWorkFlow.RemoveOrder();
                    break;
                case "5":
                    break;


                default:
                    Console.WriteLine("{0} is not a valid choice!", input);
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;

            }
        }
    }
}
