using AForum.Areas.Identity.Data;
using AForum.Core.Entities;
using AForum.Core.Interfaces;
using AForum.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForum.Interfaces
{
    public class PostService : IPost
    {
        private readonly AForumContext _context;

        public PostService(AForumContext context)
        {
            _context = context;
        }

        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task AddReply(PostReply reply)
        {
            _context.PostReplies.Add(reply);
            await _context.SaveChangesAsync();
        }

        public async Task Archive(int id)
        {
            var post = GetById(id);
            post.IsArchived = true;
            _context.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var post = GetById(id);
            _context.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task EditPostContent(int id, string content)
        {
            var post = GetById(id);
            post.Content = content;
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            var query = searchQuery.ToLower();

            return _context.Posts.Where(post =>
                    post.Title.ToLower().Contains(query)
                 || post.Content.ToLower().Contains(query));
        }

        public IEnumerable<AForumUser> GetAllUsers(IEnumerable<Post> posts)
        {
            var users = new List<AForumUser>();

            foreach (var post in posts)
            {
                users.Add(post.User);

                if (!post.Replies.Any()) continue;

                users.AddRange(post.Replies.Select(reply => reply.User));
            }

            return users.Distinct();
        }

        public Post GetById(int id)
        {
            return _context.Posts.Where(post => post.Id == id).FirstOrDefault();
        }

        public string GetForumImageUrl(int id)
        {
            var post = GetById(id);
            return post.forum.ImageUrl;
        }

        public IEnumerable<Post> GetLatestPosts(int count)
        {
            var allPosts = GetAll().OrderByDescending(post => post.Created);
            return allPosts.Take(count);
        }

        public IEnumerable<Post> GetPostsBetween(DateTime start, DateTime end)
        {
            return _context.Posts.Where(post => post.Created >= start && post.Created <= end);
        }

        public IEnumerable<Post> GetPostsByForumId(int id)
        {
            return _context.Forums.Where(forum => forum.Id == id).FirstOrDefault().Posts;

           // First(forum => forum.Id == id) = Where(forum => forum.Id == id).FirstOrDefault()
        }

        public IEnumerable<Post> GetPostsByUserId(int id)
        {
            return _context.Posts.Where(post => post.User.Id == id.ToString());
        }

        public int GetReplyCount(int id)
        {
            return GetById(id).Replies.Count();
        }
    }
}
