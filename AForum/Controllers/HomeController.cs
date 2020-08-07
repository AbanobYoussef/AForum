using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AForum.Models;
using AForum.Core.Entities;
using AForum.Core.Interfaces;
using AForum.Models.Post;
using AForum.Models.Home;

namespace AForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost _postService;

        public HomeController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndexModel();
            return View(model);
        }

        public HomeIndexModel BuildHomeIndexModel()
        {
            var latest = _postService.GetLatestPosts(10);

            var posts = latest.Select(post => new PostListingModel
            {
                Id = post.Id,
                Title = post.Title,
                Author = post.User.UserName,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                DatePosted = post.Created.ToString(),
                RepliesCount = _postService.GetReplyCount(post.Id),
                ForumName = post.forum.Title,
                ForumImageUrl = _postService.GetForumImageUrl(post.Id),
                ForumId = post.forum.Id
            });

            return new HomeIndexModel()
            {
                LatestPosts = posts
            };

        }


        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Topic", "Forums", new { searchQuery });
        }
    }
}
