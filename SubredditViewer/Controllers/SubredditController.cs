using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SubredditViewer.Models;

namespace SubredditViewer.Controllers
{
    public class SubredditController : Controller
    {
        private readonly RedditDal RD = new RedditDal();
        public IActionResult Subreddit(string Subreddit)
        {
            //string output = RD.GetAPIJson("aww");
            //ViewBag.Test = output;

            List<RedditPost> rpl = RD.GetPostList(Subreddit);
            return View(rpl);
        }
    }
}
