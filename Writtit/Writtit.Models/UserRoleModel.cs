using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Writtit.Models
{
    public class UserRoleModel
    {
        public string Email { get; set; }
        public int? RoleID { get; set; }
        public string Name { get; set; }

        public Role UserChange { get; set; }
    }
}