using AForum.Areas.Identity.Data;
using AForum.Core.Entities;
using AForum.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        Task Create(Forum forum);
        Task Delete(int id);
        Task UpdateForumTitle(int id, string title);
        Task UpdateForumDescription(int id, string description);
        Post GetLatestPost(int forumId);
        IEnumerable<AForumUser> GetActiveUsers(int forumId);
        bool HasRecentPost(int id);
        Task Add(Forum forum);
        Task SetForumImage(int id, Uri uri);
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        IEnumerable<Post> GetFilteredPosts(int forumId, string modelSearchQuery);
    }
}
