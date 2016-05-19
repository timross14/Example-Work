using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Writtit.BLL;
using Writtit.Models;
using Writtit.UI.Models;

namespace Writtit.UI.Controllers
{
    public class PagesController : Controller
    {
        private WrittitOperations _ops = new WrittitOperations();

        // GET: Pages
        public ActionResult Index()
        {
            return View(_ops.GetAllPages());
        }

        // GET: Pages/Details/5
        public ActionResult Details(int? id)
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

        // GET: Pages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageID,Title,Content")] Page page)
        {
            if (ModelState.IsValid)
            {
                _ops.AddNewPage(page);
                return RedirectToAction("Index");
            }

            return View(page);
        }

        // GET: Pages/Edit/5
        public ActionResult Edit(int? id)
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
            return View(page);
        }

        // POST: Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageID,Title,Content")] Page page)
        {
            if (ModelState.IsValid)
            {
                _ops.UpdatePage(page);
                return RedirectToAction("Index");
            }
            return View(page);
        }

        // GET: Pages/Delete/5
        public ActionResult Delete(int? id)
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
            return View(page);
        }

        // POST: Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Page page = _ops.GetPageByID(id);
            _ops.DeletePage(page);
            return RedirectToAction("Index");
        }
    }
}

