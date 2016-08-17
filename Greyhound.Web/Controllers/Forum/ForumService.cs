using GreyHound.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Greyhound.Web.Controllers.Forum
{
    public class ForumService : IForumService
    {
        private readonly GreyHoundContext _dbContext;

        public ForumService()
        {
            _dbContext = new GreyHoundContext();
        }

        public ForumService(GreyHoundContext context)
        {
            _dbContext = context;
        }
    }
}