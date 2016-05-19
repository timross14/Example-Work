using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Writtit.Models;

namespace Writtit.UI.Models
{
    public class AdminAllPostVM
    {
        public Post Post { get; set; }
        public bool IsHidden { get; set; }
        public bool IsApproved { get; set; }
        public int PostID { get; set; }
    }
}