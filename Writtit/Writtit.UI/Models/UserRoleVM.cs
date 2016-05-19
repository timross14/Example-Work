using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Writtit.UI.Models
{
    public class UserRoleVM
    {
        public Dictionary<string,int?> UserRoleDictionary { get; set; }

        public UserRoleVM(Dictionary<string,int?> inputDictionary)
        {
            UserRoleDictionary = inputDictionary;
        }
    }
}