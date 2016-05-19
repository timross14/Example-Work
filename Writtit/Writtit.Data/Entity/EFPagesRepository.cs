using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writtit.Models;
using Writtit.UI.Models;

namespace Writtit.Data
{
    public class EFPagesRepository:IPageRepository
    {
        WrittitUIContext db = new WrittitUIContext();
        public List<Page> GetAllPages()
        {
            return db.Pages.ToList();
        }

        public Page GetPageByID(int? pageID)
        {
            return db.Pages.Find(pageID);
        }

        public void AddNewPage(Page page)
        {
            db.Pages.Add(page);
            db.SaveChanges();
        }

        public void UpdatePage(Page page)
        {
            db.Entry(page).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeletePage(Page page)
        {
            db.Pages.Remove(page);
            db.SaveChanges();
        }
    }
}