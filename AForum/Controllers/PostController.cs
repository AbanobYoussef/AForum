using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AForum.Areas.Identity.Data;
using AForum.Core.Entities;
using AForum.Core.Interfaces;
using AForum.Helpers;
using AForum.Models.Post;
using AForum.Models.Reply;
using Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AForum.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly IForum _forumService;
        private readonly IPostFormatter _postFormatter;
        private readonly IApplicationUser _userService;

        private static UserManager<AForumUser> _userManager;

        public PostController(IPost postService, IForum forumService, IApplicationUser userService, UserManager<AForumUser> userManager, IPostFormatter postFormatter)
        {
            _postService = postService;
            _forumService = forumService;
            _userManager = userManager;
            _postFormatter = postFormatter;
            _userService = userService;
        }

        public IActionResult Index(int id)
        {

            var post = _postService.GetById(id);

            var replies = GetPostReplies(post).OrderBy(reply => reply.Date);

            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImage,
                AuthorRating = post.User.Rating,
                Date = post.Created,
                PostContent = post.Content,
                Replies = replies,
                ForumId = post.forum.Id,
                ForumName = post.forum.Title
            };

            return View(model);
        }

        private IEnumerable<PostReplyModel> GetPostReplies(Post post)
        {


            return post.Replies.Select(reply => new PostReplyModel
            {
                Id = reply.Id,
                AuthorName = reply.User.UserName,
                AuthorId = reply.User.Id,
                AuthorImageUrl = reply.User.ProfileImage,
                AuthorRating = reply.User.Rating,
                Date = reply.Created,
            });
        }

        public IActionResult Create(int id)
        {
            
            // note id here is Forum.Id
            var forum = _forumService.GetById(id);

            var model = new NewPostModel
            {
                ForumName = forum.Title,
                ForumId = forum.Id,
                AuthorName = User.Identity.Name,
                ForumImageUrl = forum.ImageUrl
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user =  _userManager.FindByIdAsync(userId).Result;
            var post = BuildPost(model, user);

            await _postService.Add(post);
            await _userService.BumpRating(userId, typeof(Post));

            return RedirectToAction("Index", "Forum", new { id = model.ForumId });
        }


        public Post BuildPost(NewPostModel post, AForumUser user)
        {
            var now = DateTime.Now;
            var forum = _forumService.GetById(post.ForumId);

            return new Post
            {
                Title = post.Title,
                Content = post.Content,
                Created = now,
                forum = forum,
                User = user,
                IsArchived = false
            };
        }
    }
}
