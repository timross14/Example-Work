using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Writtit.Models;

namespace Writtit.UI.Models
{
    public class SidebarVM
    {
        public List<Post> Posts { get; set; }
        public List<Tag> Tags { get; set; } 
    }
}