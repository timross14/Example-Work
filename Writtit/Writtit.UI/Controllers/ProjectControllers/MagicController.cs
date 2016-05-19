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
    public class MagicController : ApiController
    {
        public List<Tag> Get()
        {
            var ops = new WrittitOperations();
            return ops.GetTagFrequency().OrderByDescending(m => m.Frequency).Take(5).ToList();
        }
    }
}
