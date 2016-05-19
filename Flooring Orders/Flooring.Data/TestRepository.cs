using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;

namespace Flooring.Data
{
    public class TestRepository : IRepository
    {
        public List<Order> GetAllOrdersFromDate(string stringDate)
        {
            List<Order> orders = new List<Order>();

            string prefix = "Order_";
            string suffix = ".txt";
            string fileName = prefix + stringDate + suffix;

            string fullPath = ConfigurationManager.AppSettings["FileLocation"] + fileName;

            var reader = File.ReadAllLines(fullPath);

            for (int i = 0; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var order = new Order();
                order.OrderNumber = int.Parse(columns[0]);
                order.CustomerName = columns[1];
                order.State = columns[2];
                order.ProductTypeString = columns[3];
                order.Area = int.Parse(columns[4]);
                order.MaterialCost = decimal.Parse(columns[5]);
                order.LaborCost = decimal.Parse(columns[6]);
                order.TotalCost = decimal.Parse(columns[7]);
                order.Tax = decimal.Parse(columns[8]);
                order.TaxRate = decimal.Parse(columns[9]);
                order.RemoveStatus = bool.Parse(columns[10]);

                orders.Add(order);
            }

            return orders;
        }

        public void EditOrder(Order inputOrder, string stringDate)
        {
            return;
        }

        public void RemoveOrder(Order inputOrder, string stringDate)
        {
            return;
        }

        public void WriteOrderToFile(string stringDate, Order order)
        {
            return;
        }

        public decimal GetTaxRate(string state)
        {
            string filePath = ConfigurationManager.AppSettings["TaxRates"];

            var reader = File.ReadAllLines(filePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                if (columns[0] == state)
                {
                    return decimal.Parse(columns[2]);
                }


            }
            throw new Exception(); // shouldn't get here
        }

        public ProductType GetProductType(string productTypeString)
        {
            string filePath = ConfigurationManager.AppSettings["ProductTypes"];

            var reader = File.ReadAllLines(filePath);

            ProductType prodType = new ProductType();

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                if (columns[0] == productTypeString)
                {
                    prodType.Type = columns[0];
                    prodType.CostPerSqFt = decimal.Parse(columns[1]);
                    prodType.LaborCostPerSqFt = decimal.Parse(columns[2]);
                    return prodType;
                }


            }
            throw new Exception(); //shouldn't get here
        }

        public List<string> GetListOfProductTypes()
        {
            string filePath = ConfigurationManager.AppSettings["ProductTypes"];

            var reader = File.ReadAllLines(filePath);

            List<string> productTypeList = new List<string>();

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');
                productTypeList.Add(columns[0]);
            }
            return productTypeList;
        }

        public string GetLastOrderNumberFromDate(string date)
        {
            
            string prefix = "Order_";
            string suffix = ".txt";
            string fileName = prefix + date + suffix;

            string fullPath = ConfigurationManager.AppSettings["FileLocation"] + fileName;

            List<string> orderNumberList = new List<string>();
            var reader = File.ReadAllLines(fullPath);
            
            for (int i = 0; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');
                orderNumberList.Add(columns[0]);
            }

            return orderNumberList.Last();
            
        }

        public bool DoesDateExist(string date)
        {
            string prefix = "Order_";
            string suffix = ".txt";
            string fileName = prefix + date + suffix;

            string path = ConfigurationManager.AppSettings["FileLocation"];
            string[] fileNames = Directory.GetFiles(path);

            foreach (var file in fileNames)
            {
                if (file.Contains(fileName))
                {
                    return true;
                }
            }
            
            return false;
        }

        public void LogError(string errorMessage)
        {
            
        }


    }
}
