using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL;
using Flooring.Models;

namespace Flooring.UI
{
     public class OrderPrompt
    {
        public static DateTime GetOrderDate()
        {
            DateTime date = new DateTime();
            do
            {
                Console.Clear();
                Console.WriteLine("Press 'Q' to return to Main Menu");
                Console.WriteLine("Date entry methods: MM-DD-YYYY or MM/DD/YYYY\n");
                Console.WriteLine();
                Console.Write("Please enter the date of the order: ");
                if (DateTime.TryParse(CheckIfQuit(Console.ReadLine()), out date))
                {
                    
                    return date;

                }
                Console.WriteLine("Please enter a valid format!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to Continue.");
                OrderOps ops = new OrderOps();
                ops.LogUserInputError();
                CheckIfQuit(Console.ReadLine());
            } while (true);

        }

        public static int GetOrderNumber()
        {
            int orderNumber;
            do
            {
                Console.Write("Please enter the order number: ");
                if (int.TryParse(CheckIfQuit(Console.ReadLine()), out orderNumber))
                {
                    return orderNumber;
                }
                Console.WriteLine("Please make sure your order number matches a listed order.");
                Console.WriteLine("Press Enter to Continue.");
                CheckIfQuit(Console.ReadLine());
            } while (true);

        }

         public static string CheckIfQuit(string input)
         {
             if (input.ToUpper() == "Q")
             {
                 MainMenu.DisplayMainMenu();
                
             }
             return input;
         }

         public static bool CheckValidState(string input)
         {
             if (input != "OH" && input != "PA" && input != "MI" && input != "IN")
             {
                Console.WriteLine();
                 Console.WriteLine("At this time, we only service these states: OH, PA, MI, IN");
                Console.WriteLine("Press Enter to Continue");
                 Console.ReadLine();
                Console.Clear();
                OrderOps ops = new OrderOps();
                ops.LogUserInputError();
                 return false;
             }
             return true;
         }

        public static bool CheckIfValidNumber(string input)
        {
            if (!input.All(char.IsDigit) || input == "" || int.Parse(input) < 1)
            {
                Console.WriteLine();
                Console.WriteLine("Please make sure to enter a valid number");
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
                Console.Clear();
                OrderOps ops = new OrderOps();
                ops.LogUserInputError();
                return false;
            }
            return true;

        }
    }
}
