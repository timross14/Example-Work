using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writtit.Models
{
    public class Tag
    {
        public int? TagId { get; set; }
        public int Frequency { get; set; }
        public string Name { get; set; }
        public virtual List<Post> Posts { get; set; }

        public Tag()
        {
            Frequency = 1;
        }
    }
}
