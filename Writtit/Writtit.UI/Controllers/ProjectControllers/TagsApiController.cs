using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Writtit.BLL;
using Writtit.Models;

namespace Writtit.UI.Controllers.ProjectControllers
{
    public class TagsApiController : ApiController
    {
        private WrittitOperations _ops;

        public TagsApiController()
        {
            _ops = new WrittitOperations();
        }
        public List<Tag> GetAllTags()
        {
            return _ops.GetAllTags();
        }

        // GET: api/TagsApi/5
        public Tag GetTagByID(int id)
        {
            return _ops.GetTagByID(id);
        }

        // POST: api/TagsApi
        public void UpdateTag(Tag tag, Post post)
        {
            _ops.UpdateTag(tag, post);
        }

        // PUT: api/TagsApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TagsApi/5
        public void Delete(int id)
        {
        }
    }
}
