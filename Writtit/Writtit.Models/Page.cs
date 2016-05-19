using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Writtit.Models
{
    public class Page
    {
        public int PageID { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Please enter some content")]
        public string Content { get; set; }
        public bool IsHidden { get; set; }
        public bool IsHome { get; set; }
    }
}