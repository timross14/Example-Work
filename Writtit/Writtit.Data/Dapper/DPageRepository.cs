using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Writtit.Models;

namespace Writtit.Data.Dapper
{
    public class DPageRepository:IPageRepository
    {
        public List<Page> GetAllPages()
        {
            using (
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Writtit"].ConnectionString)
                )
            {
                return cn.Query<Page>("SELECT * FROM Pages p").ToList();
            }
        }

        public Page GetPageByID(int? pageID)
        {
            using (
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Writtit"].ConnectionString)
                )
            {
                return cn.Query<Page>("SELECT * FROM Pages p " +
                                      "WHERE p.PageID = @pageid", new {pageid = pageID}).FirstOrDefault();
            }
        }

        public void AddNewPage(Page page)
        {
            using (
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Writtit"].ConnectionString)
                )
            {
                var p = new DynamicParameters();
                p.Add("@Title",page.Title);
                p.Add("@Content",page.Content);
                p.Add("@IsHidden", 0);
                p.Add("@IsHome", page.IsHome);

                cn.Execute("INSERT INTO Pages (Title,Content,IsHidden, IsHome) " +
                           "VALUES (@Title, @Content,@IsHidden, @IsHome)", p);
            }
        }

        public void UpdatePage(Page page)
        {
            using (
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Writtit"].ConnectionString)
                )
            {
                var p = new DynamicParameters();

                p.Add("@pageid", page.PageID);
                p.Add("@Content", page.Content);
                p.Add("@Title", page.Title);

                cn.Execute("UPDATE Pages " +
                           "SET Content = @Content, " +
                           "Title = @Title " +
                           "WHERE PageID = @pageid", p);
            }
        }

        public void DeletePage(Page page)
        {
            using (
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Writtit"].ConnectionString)
                )
            {
                cn.Execute("UPDATE Pages " +
                           "SET IsHidden = 1 " +
                           "WHERE PageID = @pageid", new {pageid = page.PageID});
            }
        }
    }
}