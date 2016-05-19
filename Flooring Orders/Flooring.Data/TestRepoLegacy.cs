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
    //public class TestRepository : IRepository
    //{
    //    public List<Order> GetAllOrdersFromDate(string stringDate)
    //    {
    //        List<Order> orders = new List<Order>();

    //        string prefix = "Order_";
    //        string suffix = ".txt";
    //        string fileName = prefix + stringDate + suffix;

    //        string fullPath = ConfigurationManager.AppSettings["FileLocation"] + fileName;

    //        var reader = File.ReadAllLines(fullPath);

    //        for (int i = 0; i < reader.Length; i++)
    //        {
    //            var columns = reader[i].Split(',');

    //            var order = new Order();
    //            order.OrderNumber = int.Parse(columns[0]);
    //            order.CustomerName = columns[1];
    //            order.State = columns[2];
    //            order.ProductTypeString = columns[3];
    //            order.Area = int.Parse(columns[4]);
    //            order.MaterialCost = decimal.Parse(columns[5]);
    //            order.LaborCost = decimal.Parse(columns[6]);
    //            order.TotalCost = decimal.Parse(columns[7]);
    //            order.Tax = decimal.Parse(columns[8]);
    //            order.TaxRate = decimal.Parse(columns[9]);
    //            order.RemoveStatus = bool.Parse(columns[10]);

    //            orders.Add(order);
    //        }

    //        return orders;
    //    }

    //    public void EditOrder(Order inputOrder, string stringDate)
    //    {
    //        List<Order> orders = new List<Order>();

    //        string prefix = "Order_";
    //        string suffix = ".txt";
    //        string fileName = prefix + stringDate + suffix;

    //        string fullPath = ConfigurationManager.AppSettings["FileLocation"] + fileName;

    //        var reader = File.ReadAllLines(fullPath);

    //        for (int i = 0; i < reader.Length; i++)
    //        {

    //            var columns = reader[i].Split(',');

    //            if (int.Parse(columns[0]) == inputOrder.OrderNumber)
    //            {
    //                orders.Add(inputOrder);
    //                continue;
    //            }

    //            var order = new Order();
    //            order.OrderNumber = int.Parse(columns[0]);
    //            order.CustomerName = columns[1];
    //            order.State = columns[2];
    //            order.ProductTypeString = columns[3];
    //            order.Area = int.Parse(columns[4]);
    //            order.MaterialCost = decimal.Parse(columns[5]);
    //            order.LaborCost = decimal.Parse(columns[6]);
    //            order.TotalCost = decimal.Parse(columns[7]);
    //            order.Tax = decimal.Parse(columns[8]);
    //            order.TaxRate = decimal.Parse(columns[9]);
    //            order.RemoveStatus = bool.Parse(columns[10]);

    //            orders.Add(order);
    //        }

    //        TextWriter tw = new StreamWriter(fullPath);

    //        foreach (var o in orders)
    //        {
    //            tw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",
    //                o.OrderNumber, o.CustomerName, o.State, o.ProductTypeString, o.Area,
    //                o.MaterialCost, o.LaborCost, o.TotalCost, o.Tax, o.TaxRate, o.RemoveStatus);
    //        }

    //        tw.Close();
    //    }

    //    public void WriteOrderToFile(string stringDate, Order order)
    //    {
    //        Dictionary<string, List<Order>> mockDictionary = CreateOrderDictionary();
    //        foreach (var list in mockDictionary)
    //        {
    //            if (list.Key == stringDate)
    //            {
    //                list.Value.Add(order);
    //            }
    //        }
    //    }



    //    public Dictionary<string, List<Order>> CreateOrderDictionary()
    //    {
    //        Dictionary<string, List<Order>> orderDictionary = new Dictionary<string, List<Order>>();

    //        List<Order> sampleOrders = new List<Order>();
            
    //        for (int i = 1; i < 4; i++)
    //        {

    //            var order = new Order();
    //            order.OrderNumber = i;
    //            order.CustomerName = "Bob Smith";
    //            order.State = "OH";
    //            order.ProductTypeString = "Wood";
    //            order.Area = 20;
    //            order.MaterialCost = 10;
    //            order.LaborCost = 5;
    //            order.TotalCost = 7;
    //            order.Tax = 8;
    //            order.TaxRate = .05M;

    //            sampleOrders.Add(order);


    //        }

    //        orderDictionary.Add("03152016", sampleOrders);
    //        return orderDictionary;
    //    }

    //    public decimal GetTaxRate(string state)
    //    {
    //        string filePath = ConfigurationManager.AppSettings[@"ProductionData\TaxRate.txt"];

    //        var reader = File.ReadAllLines(filePath);

    //        for (int i = 1; i < reader.Length; i++)
    //        {
    //            var columns = reader[i].Split(',');

    //            if (columns[0] == state)
    //            {
    //                return decimal.Parse(columns[2]);
    //            }


    //        }
    //        throw new Exception(); // shouldn't get here
    //    }


    //    public ProductType GetProductType(string productTypeString)
    //    {
    //        string filePath = ConfigurationManager.AppSettings[@"ProductionData\ProductTypes.txt"];

    //        var reader = File.ReadAllLines(filePath);

    //        ProductType prodType = new ProductType();

    //        for (int i = 1; i < reader.Length; i++)
    //        {
    //            var columns = reader[i].Split(',');

    //            if (columns[0] == productTypeString)
    //            {
    //                prodType.Type = columns[0];
    //                prodType.CostPerSqFt = decimal.Parse(columns[1]);
    //                prodType.LaborCostPerSqFt = decimal.Parse(columns[2]);
    //                return prodType;
    //            }


    //        }
    //        throw new Exception(); //shouldn't get here
    //    }

    //    public List<string> GetListOfProductTypes()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public string GetLastOrderNumberFromDate(string date)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool DoesDateExist(string date)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
