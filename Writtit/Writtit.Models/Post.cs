using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Writtit.Models
{
    public class Post
    {
        public int? PostID { get; set; }
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Please enter a company")]
        public string Company { get; set; }

        [MaxLength(40, ErrorMessage = "Title must be less than 40 characters")]
        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Please enter some content")]
        public string Content { get; set; }
        public int CategoryID { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHidden { get; set; }

        public Post()
        {
            IsApproved = false;
            IsHidden = false;
        }
    }
}