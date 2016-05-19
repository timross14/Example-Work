using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Writtit.Models;

namespace Writtit.UI.Models
{
    public class WrittitUIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WrittitUIContext() : base("name=WrittitUIContext")
        {
        }

        public System.Data.Entity.DbSet<Writtit.Models.Post> Posts { get; set; }

        public System.Data.Entity.DbSet<Writtit.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<Writtit.Models.Page> Pages { get; set; }

        public System.Data.Entity.DbSet<Writtit.Models.Tag> Tags { get; set; }
    }
}