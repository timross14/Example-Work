using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models
{
    public class Order
    {
        public DateTime Date { get; set; }//DateTime.Now
        public int OrderNumber { get; set; }//TODO:set need to get last know order
        public string CustomerName { get; set; }
        public string State { get; set; }
        public string ProductTypeString; //todo: convert producttypestring into producttype...
        public int Area { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Tax { get; set; }
        public decimal TaxRate { get; set; }
        public ProductType ProductType { get; set; }
        public bool RemoveStatus { get; set; }

    }
}
