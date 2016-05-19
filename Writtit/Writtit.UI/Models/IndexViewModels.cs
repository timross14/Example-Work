using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Writtit.BLL;
using Writtit.Models;

namespace Writtit.UI.Models
{
    public class IndexViewModels
    {
        public List<Post> Posts { get; set; }
        public List<Post> SearchList { get; set; }
        public string SearchType { get; set; }
        public string SearchField { get; set; }
        public string CategoryField { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> SearchSelect { get; set; }

        public IndexViewModels()
        {
            WrittitOperations ops = new WrittitOperations();

            Posts = ops.GetAllPosts();
            SearchList = Posts;

            Categories = new List<SelectListItem>
            {
                new SelectListItem { Text = "Select Category", Value = ""}
            };

            foreach (var category in ops.GetAllCategories())
            {
                Categories.Add(new SelectListItem { Text = category.Name, Value = category.CategoryID.ToString() });
            }

            SearchSelect = new List<SelectListItem>
            {
                new SelectListItem {Value = "Title", Text = "Title", Selected = true},
                new SelectListItem {Value = "Category", Text = "Category"},
                new SelectListItem {Value = "Tag", Text = "Tag"},
                new SelectListItem {Value = "Company", Text = "Company"},
                new SelectListItem {Value = "Email", Text = "Email"}
            };


        }
    }
}