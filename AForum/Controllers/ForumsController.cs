﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AForum.Core.Entities;
using AForum.Core.Interfaces;
using AForum.Interfaces;
using AForum.Models;
using AForum.Models.Forum;
using AForum.Models.Post;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace AForum.Controllers
{
    public class ForumsController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _postService;
        public ForumsController(IForum forumService , IPost postService)
        {
            _forumService = forumService;
            _postService = postService;
        }


        public IActionResult Index()
        {
            var forums = _forumService.GetAll()
                .Select(forum=>new ForumListingModel{ 
                    Id=forum.Id,
                    Title=forum.Title,
                    Description=forum.Description
            });

            var model = new ForumIndexModel ()
            {
                ForumList= forums
            };
            return View(model);
        }


        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);
            //  var posts = _postService.GetPostsByForumId(id).ToList();
            var posts = forum.Posts;

            var postListings = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                Forum = BuildForumListing(post),
                Author = post.User.UserName,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                Title = post.Title,
                DatePosted = post.Created.ToString(CultureInfo.InvariantCulture),
                RepliesCount = post.Replies.Count()
            }).OrderByDescending(post => post.DatePosted);

            var model = new TopicResultModel
            {
                Posts = postListings,
                Forum = BuildForumListing(forum)
            };

            return View(model);
        }

        private static ForumListingModel BuildForumListing(Forum forum)
        {
            return new ForumListingModel
            {
                Id = forum.Id,
                ImageUrl = forum.ImageUrl,
                Title = forum.Title,
                Description = forum.Description
            };
        }

        private static ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.forum;
            return BuildForumListing(forum);
        }

       
    }
}
