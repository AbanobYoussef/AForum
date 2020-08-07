using AForum.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForum.Core.Interfaces
{
    public interface IApplicationUser
    {
        AForumUser GetById(string id);
        IEnumerable<AForumUser> GetAll();

         Task IncrementRating(string id);
        Task Add(AForumUser user);
        Task Deactivate(AForumUser user);
        Task SetProfileImage(string id, Uri uri);
        Task BumpRating(string userId, Type type);
    }
}
