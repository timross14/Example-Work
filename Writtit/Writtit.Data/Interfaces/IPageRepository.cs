using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writtit.Models;

namespace Writtit.Data
{
    public interface IPageRepository
    {
        List<Page> GetAllPages();

        Page GetPageByID(int? pageID);

        void AddNewPage(Page page);

        void UpdatePage(Page page);

        void DeletePage(Page page);
    }
}
