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
    public class EFTagsRepository: ITagRepository
    {
        WrittitUIContext db = new WrittitUIContext();

        public List<Tag> ReadAllTags()
        {
            return db.Tags.ToList();
        }

        public List<Tag> ReadTagByPostID(int? postID)
        {
            return db.Posts.ToList().FirstOrDefault(p => p.PostID == postID).Tags;
        }

        public Tag ReadTagByID(int? tagID)
        {
            return db.Tags.Find(tagID);
        }

        public int WriteNewTag(Tag tag)
        {
            db.Tags.Add(tag);
            db.SaveChanges();
            return 1;
        }

        public void UpdateTag(Tag tag, Post post)
        {
            db.Entry(tag).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteTag(Tag tag)
        {
            db.Tags.Remove(tag);
            db.SaveChanges();
        }

        public List<Tag> ReadAllTagsFrequency()
        {
            throw new NotImplementedException();
        }
    }
}
