using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL;
using Flooring.Models;

namespace Flooring.UI.WorkFlows
{
    public class EditWorkFlow
    {
        public static void EditOrder()
        {
            List<Order> order = new List<Order>();
            OrderOps ops = new OrderOps();
            DateTime date = OrderPrompt.GetOrderDate();
            order = ops.GetOrdersFromDate(date);
            foreach (var o in order)
            {
                Console.WriteLine("{0} - {1} - {2:C} ", o.OrderNumber, o.CustomerName, o.TotalCost);
            }
            int orderNumber = OrderPrompt.GetOrderNumber();
            Order orderToEdit = EditPrompts(GetAnOrder(order, orderNumber));
            ops.EditOrder(orderToEdit, ops.ConvertDateToString(date));
            MainMenu.DisplayMainMenu();
        }

        public static Order GetAnOrder(List<Order> orders, int orderNumber)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].OrderNumber == orderNumber)
                {
                    Order orderToEdit = orders[i];
                    return orderToEdit;
                }
            }
            return null;
        }

        private static Order EditPrompts(Order editOrder)
        {
            Console.Write("Enter Customer Name ({0}): ", editOrder.CustomerName);
            string localName = OrderPrompt.CheckIfQuit(Console.ReadLine());
            if (localName.Contains(','))
            {
                localName = localName.Replace(",", " ");
            }
            if (localName != editOrder.CustomerName)
            {
                if (localName == "")
                {
                    localName = editOrder.CustomerName;
                }

                editOrder.CustomerName = localName;
            }

            do
            {
                Console.Write("Location of the order ({0}): ", editOrder.State);
                string localState = OrderPrompt.CheckIfQuit(Console.ReadLine().ToUpper());

                if (localState != editOrder.State && localState != "")
                {
                    if (OrderPrompt.CheckValidState(localState))
                    {
                        editOrder.State = localState;
                        break;
                    }
                    continue;
                }
                break;
            } while (true);

            do
            {
                OrderOps ops = new OrderOps();
                Console.Write("Product type purchased ({0}): ", editOrder.ProductTypeString);
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
                string inputType = OrderPrompt.CheckIfQuit(Console.ReadLine());

                if (ops.GetProductTypeList().All(product => product != inputType))
                {
                    Console.WriteLine("Sorry, We don't carry that product currently!");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    continue;
                }
                editOrder.ProductTypeString = inputType;
                break;
            } while (true);

            do
            {
                Console.Write("Number of Sq. Ft. purchased ({0}): ", editOrder.Area);
                string localArea = OrderPrompt.CheckIfQuit(Console.ReadLine());
                if (!OrderPrompt.CheckIfValidNumber(localArea))
                {
                    continue;
                }
                if (localArea != editOrder.Area.ToString() && localArea != "")
                {
                    editOrder.Area = int.Parse(localArea);
                    break;
                }
                Console.WriteLine("Please enter a valid value!");
                Console.ReadLine();
            } while (true);

            do
            {
                Console.Clear();
                Console.WriteLine("Please verify the changed information is correct: (Y)es or (N)o \n");
                Console.WriteLine("Name: {0}", editOrder.CustomerName);
                Console.WriteLine("State: {0}", editOrder.State);
                Console.WriteLine("Product Type: {0}", editOrder.ProductTypeString);
                Console.WriteLine("Sq. Ft. Purchased: {0}", editOrder.Area);
                string userResponse = Console.ReadLine();


                if (userResponse.ToUpper() == "Y" || userResponse.ToUpper() == "YES")
                {
                    Console.WriteLine("Order Edit was Successful!\n");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    Console.Clear();
                    return editOrder;
                }
                if (userResponse.ToUpper() == "N" || userResponse.ToUpper() == "NO")
                {
                    Console.WriteLine("Your changes have been discarded.");
                    Console.WriteLine("Press 'Enter' to continue.");

                    Console.ReadLine();
                    MainMenu.DisplayMainMenu();
                }

                Console.WriteLine("Please Confirm or Deny changes");
                Console.WriteLine("Press Enter To Continue");
                Console.ReadLine();
                
            } while (true);
        }
    }
}

