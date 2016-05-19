using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL;
using Flooring.Models;

namespace Flooring.UI.WorkFlows
{
    public class DisplayWorkFlow
    {
        public void DisplayOrders()
        {
            OrderOps ops = new OrderOps();
            DateTime date = OrderPrompt.GetOrderDate();
            
            if (!ops.DoesDateExist(date))
            {
                Console.WriteLine("This date does not have any orders.  Please try another date.\n");
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
                DisplayOrders();
            }
            List<Order> displayOrders = ops.GetOrdersFromDate(date);
            if (AreAllOrdersRemoved(displayOrders))
            {
                Console.WriteLine("This date does not have any orders.  Please try another date.\n");
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
                DisplayOrders();
            }
            Console.WriteLine();
            Console.WriteLine("Orders");
            Console.WriteLine("-------------");
            foreach (var order in displayOrders)
            {
                Console.WriteLine("{0} - {1} - {2:C} ",order.OrderNumber, order.CustomerName, order.TotalCost);
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter To Return to Main Menu");
            Console.ReadLine();
            MainMenu.DisplayMainMenu();
        }

        private bool AreAllOrdersRemoved(List<Order> orders)
        {
            int index = 0;
            foreach (Order o in orders)
            {
                if (o.RemoveStatus == true)
                    index++;
            }
            if (index == orders.Count)
            {
                return true;
            }
            return false;
        }
    }


}
