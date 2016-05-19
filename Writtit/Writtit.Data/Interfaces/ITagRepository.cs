using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writtit.Models;

namespace Writtit.Data
{
    public interface ITagRepository
    {
        List<Tag> ReadAllTags();

        List<Tag> ReadTagByPostID(int? postID);

        Tag ReadTagByID(int? tagID);

        int WriteNewTag(Tag tag);

        void UpdateTag(Tag tag, Post post);

        void DeleteTag(Tag tag);

        List<Tag> ReadAllTagsFrequency();
    }
}
