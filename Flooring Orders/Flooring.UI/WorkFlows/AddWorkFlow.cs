using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL;
using Flooring.Models;

namespace Flooring.UI.WorkFlows
{
    public class AddWorkFlow
    {
        public static void CreateOrder()
        {
            
            Console.Clear();
            OrderOps ops = new OrderOps();
            Order localOrder = new Order();
            Console.Write("Please Enter A Name For Your Order: ");
            localOrder.CustomerName = OrderPrompt.CheckIfQuit(Console.ReadLine());
            if (localOrder.CustomerName.Contains(','))
            {
                localOrder.CustomerName = localOrder.CustomerName.Replace(", ", " ");
            }
            string userInput;
            do
            { 
                Console.Write("Where in our service area is this order for?  ");
                Console.Write("We service - OH, PA, MI, IN: ");
                userInput = OrderPrompt.CheckIfQuit(Console.ReadLine().ToUpper());
            } while (!OrderPrompt.CheckValidState(userInput));
            localOrder.State = userInput;

            do
            {
                Console.Write("What Type Of Product Would You Like?\n");
                Console.Write("We currently carry ");
                List<string> products = ops.GetProductTypeList();
                for (int i = 0; i < products.Count; i++)
                {
                    if (i == products.Count - 1)
                    {
                        Console.Write("{0}: ", products[i]);
                        continue;
                    }
                    Console.Write("{0}, ", products[i]);
                }
                localOrder.ProductTypeString = OrderPrompt.CheckIfQuit(Console.ReadLine());
                if (ops.GetProductTypeList().All(product => product != localOrder.ProductTypeString))
                {
                    Console.WriteLine("Sorry, We don't carry that product currently!");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    continue;
                }
                break;
            } while (true);
            do
            {
                Console.Write("How Many Square Ft. Do You Need? ");
                userInput = OrderPrompt.CheckIfQuit(Console.ReadLine());

            } while (!OrderPrompt.CheckIfValidNumber(userInput));
            localOrder.Area = int.Parse(userInput);

            OrderFactory factory = new OrderFactory();
            DisplayOrderSummary(localOrder);
            factory.CreateOrder(localOrder);
           
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Order was created successfully!");
            Console.ReadLine();
            Console.Clear();

        }

        private static void DisplayOrderSummary(Order order)
        {
<<<<<<< HEAD

            Console.WriteLine("Name: {0}\nState: {1}\n Product Type: {2}", order.CustomerName, order.State, order.ProductTypeString);
            Console.WriteLine("Area: {0}", order.Area, order.TotalCost);
            Console.WriteLine();
            Console.WriteLine("Is this information correct? (Y)es or (N)o");
            string input = Console.ReadLine();
            if (input.ToUpper() == "Y")
            {
                return;
            }
=======
>>>>>>> a849eed8e229f2150856fb019459b9f37fb81d31
            while (true)
            {
                Console.WriteLine("Name: {0}\nState: {1}\n Product Type: {2}", order.CustomerName, order.State,
                    order.ProductTypeString);
                Console.WriteLine("Area: {0}", order.Area, order.TotalCost);
                Console.WriteLine();
                Console.WriteLine("Is this information correct? (Y)es or (N)o");
                string input1 = Console.ReadLine();
                if (input1.ToUpper() == "N" || input1.ToUpper() == "NO")
                {
                    Console.WriteLine("Returning to Main Menu...");
                    Console.ReadLine();
                    MainMenu.DisplayMainMenu();
                }
                if (input1.ToUpper() == "Y" || input1.ToUpper() == "YES")
                {
                    return;
                }
<<<<<<< HEAD

=======
>>>>>>> a849eed8e229f2150856fb019459b9f37fb81d31
            }
        }
    }
}
