using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Writtit.BLL;
using Writtit.Models;
using Writtit.UI.Models;

namespace Writtit.UI.Controllers
{
    public class AdminController : Controller
    {
        private WrittitOperations _ops = new WrittitOperations();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminBlogIndex()
        {
            return View(_ops.GetAllPosts());
        }

        [HttpPost]
        public ActionResult AdminBlogIndex(IList<Post> postChange)
        {
            _ops.UpdateAllPosts(postChange.ToList());

            return RedirectToAction("AdminBlogIndex");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminStaticPageIndex()
        {
            return View(_ops.GetAllPages());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditPage(int id)
        {
            return View(_ops.GetPageByID(id));
        }

        [HttpPost]
        public ActionResult EditPage(Page page)
        {
            _ops.UpdatePage(page);
            return View("AdminStaticPageIndex", _ops.GetAllPages());
        }


        [Authorize(Roles = "Admin,Contributor")]
        public ActionResult CreatePost()
        {
            return View(new AddPostViewModels());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(AddPostViewModels add)
        {
            if (ModelState.IsValid)
            {
                add.Post.PostID = _ops.AddNewPost(add.Post);
                if (add.Tags != null)
                {
                    var tags = add.Tags.Split(',').ToList();
                    var dbTags = _ops.GetAllTags();

                    foreach (var dbTag in dbTags.Where(dbTag => tags.Any(t => t == dbTag.Name)))
                    {
                        dbTag.Frequency++;
                        _ops.UpdateTag(dbTag, add.Post);
                    }

                    foreach (var tag in tags.Where(tag => dbTags.All(t => t.Name != tag)))
                    {
                        Tag newTag = new Tag {Name = tag};
                        newTag.TagId = _ops.AddNewTag(newTag);
                        _ops.UpdateTag(newTag, add.Post);
                    }
                }

                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("AdminBlogIndex");
                }
                return RedirectToAction("BlogIndex","Blog");
            }

            return View(add);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateStaticPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStaticPage([Bind(Include = "PageID,Title,Content")] Page page)
        {
            if (ModelState.IsValid)
            {
                _ops.AddNewPage(page);
                return RedirectToAction("AdminStaticPageIndex");
            }

            return View(page);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RemoveStaticPage(int? id)
        {
            Page page = _ops.GetPageByID(id);
            _ops.DeletePage(page);
            return RedirectToAction("AdminStaticPageIndex");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminUserIndex()
        {
            var vm = _ops.GetAllUserRoles();
            return View(vm);
        }

        

        [HttpPost]
        public ActionResult AdminUserIndex(IList<UserRoleModel> roleChange)
        {
            _ops.SetAllUserRoles(roleChange.ToList());
            return RedirectToAction("AdminUserIndex");
        }

        [HttpPost]
        public ActionResult CreateCategory(Category c)
        {
            _ops.AddNewCategory(c);
            return RedirectToAction("CreatePost");
        }
    }
}