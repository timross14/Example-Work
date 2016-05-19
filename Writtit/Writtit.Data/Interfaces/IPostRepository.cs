using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writtit.Models;

namespace Writtit.Data
{
    public interface IPostRepository
    {
        List<Post> GetAllPosts();

        Post GetPostByID(int? postID);

        int AddNewPost(Post post);

        void UpdatePost(Post post);

        void DeletePost(Post post);
    }
}