using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Writtit.BLL;
using Writtit.Models;
using Writtit.UI.Models;

namespace Writtit.UI.Controllers
{
    public class PostsController : Controller
    {
        private WrittitOperations _ops = new WrittitOperations();

        // GET: Posts
        public ActionResult Index()
        {
            return View(_ops.GetAllPosts());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _ops.GetPostByID(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View(new AddPostViewModels());
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddPostViewModels add)
        {
            if (ModelState.IsValid)
            {
                add.Post.PostID = _ops.AddNewPost(add.Post);

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

                return RedirectToAction("Index");
            }

            return View(add);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _ops.GetPostByID(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,UserEmail,Company,Title,Content,DateTime,IsApproved,IsHidden")] Post post)
        {
            if (ModelState.IsValid)
            {
                _ops.UpdatePost(post);
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _ops.GetPostByID(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = _ops.GetPostByID(id);
            _ops.DeletePost(post);
            return RedirectToAction("Index");
        }
    }
}
