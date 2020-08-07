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
        IEnumerable<AForumUser> GetAllActiveUsers();


        Task Create(Forum forum);
        Task Delete(int id);
        Task UpdateForumTitle(int id, string title);
        Task UpdateForumDescription(int id, string description);
    }
}
