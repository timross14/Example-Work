using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class RepositoryFactory
    {
        public static IRepository CreateRepository()
        {
            string type = ConfigurationManager.AppSettings["FileLocation"];
            if (type.Contains("Test"))
            {
                return new TestRepository();
            }
            return new ProductionRepository();
        }
    }
}
