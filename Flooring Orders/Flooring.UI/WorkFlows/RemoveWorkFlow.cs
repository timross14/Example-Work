using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL;
using Flooring.Models;

namespace Flooring.UI.WorkFlows
{
    public class RemoveWorkFlow
    {
        public static void RemoveOrder()
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
            Console.Clear();
            Console.WriteLine("Order #{0} has been removed", orderNumber);
            Console.WriteLine("Press Enter To Continue");
            Console.ReadLine();
            Console.Clear();
            ops.RemoveOrder(EditWorkFlow.GetAnOrder(order, orderNumber), ops.ConvertDateToString(date));

        }
    }
}
