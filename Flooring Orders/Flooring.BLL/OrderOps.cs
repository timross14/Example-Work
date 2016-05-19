using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Data;
using Flooring.Models;

namespace Flooring.BLL
{
    public class OrderOps
    {
        public string ConvertDateToString(DateTime date)
        {
            string stringDate = "";
            stringDate = date.ToString("MMddyyyy");
            return stringDate;
        }

        public bool DoesDateExist(DateTime date)
        {
            IRepository repo = RepositoryFactory.CreateRepository();
            string stringDate = ConvertDateToString(date);
            if (!repo.DoesDateExist(stringDate))
            {
                return false;
            }
            return true;
        }

        public List<Order> GetOrdersFromDate(DateTime date)
        {
            IRepository repo = RepositoryFactory.CreateRepository();

            string stringDate = ConvertDateToString(date);
           
            List<Order> list = repo.GetAllOrdersFromDate(stringDate);
            var order = from o in list where o.RemoveStatus != true select o;
            List<Order> outputOrder = new List<Order>();
            foreach (var o in order)
            {
                outputOrder.Add(o);
            }
            return outputOrder;
        }

        public void RemoveOrder(Order orders, string date)
        {
            IRepository repo = RepositoryFactory.CreateRepository();
            
            repo.RemoveOrder(orders, date);
      

        }

        public void EditOrder(Order order, string date)
        {
            IRepository repo = RepositoryFactory.CreateRepository();
            repo.EditOrder(order, date);
        }

        public List<string> GetProductTypeList()
        {
            IRepository repo = RepositoryFactory.CreateRepository();
            return repo.GetListOfProductTypes();
        }

        public void LogUserInputError()
        {
            IRepository repo = RepositoryFactory.CreateRepository();
            repo.LogError("User input invalid.");
        }
    }
}
