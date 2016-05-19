using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Writtit.BLL;
using Writtit.Models;
using Writtit.UI.Models;

namespace Writtit.UI.Controllers.ProjectControllers
{
    public class BlogController : Controller
    {
        private WrittitOperations _ops = new WrittitOperations();

        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BlogIndex()
        {
            return View(new IndexViewModels());
        }

        [HttpPost]
        public ActionResult BlogIndex(IndexViewModels vm)
        {
            if (vm.SearchType == "Category")
            {
                vm.SearchList = _ops.SearchThrough(vm.CategoryField, vm.SearchType);
                return View(vm);
            }

            vm.SearchList = _ops.SearchThrough(vm.SearchField, vm.SearchType);

            return View(vm);
        }

        [HttpPost]
        public ActionResult GetBlogsByTag(int tagid)
        {
            var models = new IndexViewModels();
            models.Posts.Clear();

            foreach (var post in _ops.GetAllPosts())
            {
                foreach (var t in post.Tags)
                {
                    if (t.TagId == tagid)
                    {
                        models.Posts.Add(post);
                    }
                }
            }
            return View("BlogIndex", models);
        }

        public ActionResult PostDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _ops.GetPostByID(id);
            post.Tags = _ops.GetTagsByPostID(id.Value);
            if (post == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoryName = _ops.GetAllCategories().First(p => p.CategoryID == post.CategoryID).Name;

            return View(post);
        }

        public ActionResult PageDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = _ops.GetPageByID(id);
            if (page == null)
            {
                return HttpNotFound();
            }

            string customUrl = new Regex("[^a-zA-Z0-9]").Replace(page.Title, "-");
            return View(page);
        }

        public PartialViewResult AboutPartial()
        {
            var model = _ops.GetAllPages();

            return PartialView("AboutPartial", model);
        }

        public PartialViewResult SidebarPartial()
        {
            var model = new SidebarVM
            {
                Posts = _ops.GetAllPosts(),
                Tags = _ops.GetTagFrequency()
            };

            return PartialView("_SidebarPartial", model);
        }
    }
}