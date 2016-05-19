using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Flooring.Data;
using Flooring.Models;

namespace Flooring.BLL
{
    public class OrderFactory
    {
        public Order CreateOrder(Order order)
        {
            order.Date = new DateTime();
            order.Date = DateTime.Today;
            order.TaxRate = GetTaxRate(order);
            order.RemoveStatus = false;
            order.ProductType = GetProductType(order.ProductTypeString);
            TotalCostCalc(order);

            OrderOps ops = new OrderOps();
            
            string stringDate = ops.ConvertDateToString(order.Date);
            IRepository repo = RepositoryFactory.CreateRepository();

            repo.WriteOrderToFile(stringDate, order);

            return order;
        }

        private Order TotalCostCalc(Order order)
        {
            order.MaterialCost = (order.ProductType.CostPerSqFt * order.Area);
            order.LaborCost = order.ProductType.LaborCostPerSqFt * order.Area;
            order.Tax = (order.LaborCost + order.MaterialCost) * (order.TaxRate/100);
            order.TotalCost = order.MaterialCost + order.LaborCost + order.Tax;
            return order;
        }

        private decimal GetTaxRate(Order order)
        {
            ProductionRepository repo = new ProductionRepository();
            return repo.GetTaxRate(order.State);
        }

        private ProductType GetProductType(string productTypeString)
        {
            ProductionRepository repo = new ProductionRepository();
            return repo.GetProductType(productTypeString);

        }


    }
}
