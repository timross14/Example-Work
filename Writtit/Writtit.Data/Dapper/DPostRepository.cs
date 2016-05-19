using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Writtit.Models;

namespace Writtit.Data.Dapper
{
    public class DPostRepository:IPostRepository
    {
        private readonly string _connection = ConfigurationManager.ConnectionStrings["Writtit"].ConnectionString;

        public List<Post> GetAllPosts()
        {
            List<Post> posts = new List<Post>();
            
            using (SqlConnection cn = new SqlConnection(_connection))
            {
                posts = cn.Query<Post>("SELECT * FROM Posts p").ToList();           
            }
            return posts;

        }

        public Post GetPostByID(int? postID)
        {

            Post post = new Post();

            using (SqlConnection cn = new SqlConnection(_connection))
            {
                post = cn.Query<Post>("SELECT * " +
                                      "FROM Posts p " +
                                      "WHERE p.PostID=@postID", new { postID = postID }).FirstOrDefault();
            }

            return post;
        }

        public int AddNewPost(Post post)
        {
            int postID;

            using (SqlConnection cn = new SqlConnection(_connection))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserEmail", post.UserEmail);
                param.Add("@Company", post.Company);
                param.Add("@Title", post.Title);
                param.Add("@Content", post.Content);
                param.Add("@CategoryID", post.CategoryID);
                param.Add("@DateTime", post.DateTime);
                param.Add("@IsApproved", post.IsApproved);
                param.Add("@IsHidden", post.IsHidden);
                param.Add("@PostID", DbType.Int32, direction: ParameterDirection.Output);

                cn.Execute("CreateNewPost", param, commandType: CommandType.StoredProcedure);
                postID = param.Get<int>("@PostID");
            }

            return postID;
        }

        public void UpdatePost(Post post)
        {
            using (SqlConnection cn = new SqlConnection(_connection))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@IsApproved", post.IsApproved);
                param.Add("@IsHidden", post.IsHidden);
                param.Add("@PostID", post.PostID);

                cn.Execute("UPDATE Posts " +
                           "SET IsApproved = @IsApproved,IsHidden = @IsHidden " +
                           "WHERE PostID = @PostID",param);
            }
        }

        public void DeletePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
