using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;

namespace Flooring.Data
{
    public interface IRepository
    {
        List<Order> GetAllOrdersFromDate(string date);
        void EditOrder(Order order, string stringDate);
        void WriteOrderToFile(string stringDate, Order order);
        decimal GetTaxRate(string state);
        ProductType GetProductType(string productTypeString);
        List<string> GetListOfProductTypes();
        string GetLastOrderNumberFromDate(string date);
        bool DoesDateExist(string date);
        void RemoveOrder(Order order, string date);
        void LogError(string message);
    }
}
