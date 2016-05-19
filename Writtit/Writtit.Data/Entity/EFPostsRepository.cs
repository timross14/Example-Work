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
    public class EFPostsRepository: IPostRepository
    {
        private WrittitUIContext db = new WrittitUIContext();

        public List<Post> GetAllPosts()
        {
            return db.Posts.ToList();
        }

        public Post GetPostByID(int? postID)
        {
            return db.Posts.Find(postID);
        }

        public int AddNewPost(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();
            return 1;
        }

        public void UpdatePost(Post post)
        {
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeletePost(Post post)
        {
            db.Posts.Remove(post);
            db.SaveChanges();
        }
    }
}
