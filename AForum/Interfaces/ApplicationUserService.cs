using AForum.Areas.Identity.Data;
using AForum.Core.Entities;
using AForum.Core.Interfaces;
using AForum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForum.Interfaces
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly AForumContext _context;

        public ApplicationUserService(AForumContext context)
        {
            _context = context;
        }

        public async Task Add(AForumUser user)
        {

            _context.Add(user);
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Deactivate(AForumUser user)
        {
            user.IsActive = false;
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public AForumUser GetByName(string name)
        {
            return _context.AForumUser.FirstOrDefault(user => user.UserName == name);
        }

        public IEnumerable<AForumUser> GetAll()
        {
            return _context.AForumUser;
        }

        public AForumUser GetById(string id)
        {
            return _context.AForumUser.FirstOrDefault(user => user.Id == id);
        }

        public async Task IncrementRating(string id)
        {
            var user = GetById(id);
            user.Rating += 1;
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task SetProfileImage(string id, Uri uri)
        {
            var user = GetById(id);
            user.ProfileImage = uri.AbsoluteUri;
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task BumpRating(string userId, Type type)
        {
            var user = GetById(userId);
            var increment = GetIncrement(type);
            user.Rating += increment;
            await _context.SaveChangesAsync();
        }

        private static int GetIncrement(Type type)
        {
            var bump = 0;

            if (type == typeof(Post))
            {
                bump = 3;
            }

            if (type == typeof(PostReply))
            {
                bump = 2;
            }

            return bump;
        }
    }
}
