using AForum.Areas.Identity.Data;
using AForum.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForum.Core.Interfaces
{
    public interface IPost
    {
        Task Add(Post post);
        Task Archive(int id);
        Task Delete(int id);
        Task EditPostContent(int id, string content);

        Task AddReply(PostReply reply);

        int GetReplyCount(int id);

        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetPostsByUserId(int id);
        IEnumerable<Post> GetPostsByForumId(int id);
        IEnumerable<Post> GetPostsBetween(DateTime start, DateTime end);
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        IEnumerable<AForumUser> GetAllUsers(IEnumerable<Post> posts);
        IEnumerable<Post> GetLatestPosts(int forumId);
        string GetForumImageUrl(int id);
    }
}
