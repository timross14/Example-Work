using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Writtit.BLL;
using Writtit.Models;

namespace Writtit.UI.Models
{
    public class AddPostViewModels
    {
        public Post Post { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public string Tags { get; set; }

        public AddPostViewModels()
        {
            WrittitOperations ops = new WrittitOperations();
            var cats = ops.GetAllCategories();

            Categories = new List<SelectListItem>();

            foreach (var category in cats)
            {
                Categories.Add(new SelectListItem { Text = category.Name, Value = category.CategoryID.ToString() });
            }
            //{
            //    new SelectListItem { Text = "New Company", Value = "1", Disabled = false },
            //    new SelectListItem { Text = "Company Update", Value = "2", Disabled = false },
            //    new SelectListItem { Text = "Company Event", Value = "3", Disabled = false },
            //    new SelectListItem { Text = "News", Value = "4", Disabled = false },
            //    new SelectListItem { Text = "Opinion", Value = "5", Disabled = true },
            //};
        }
    }
}