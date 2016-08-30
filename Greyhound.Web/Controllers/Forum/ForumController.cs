using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Greyhound.Web.Controllers.Forum
{
    [RoutePrefix("api/Forum")]
    public class ForumController : ApiController
    {
        //charles testing
        private readonly IForumService _service;

        public ForumController()
        {
            _service = new ForumService();
        }

        public ForumController(IForumService service)
        {
            _service = service;
        }

    }
}
