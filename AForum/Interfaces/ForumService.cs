using AForum.Areas.Identity.Data;
using AForum.Core.Entities;
using AForum.Data;
using AForum.Models;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForum.Interfaces
{
    public class ForumService : IForum
    {
        private readonly AForumContext _context;
        public ForumService(AForumContext context)
        {
            _context = context;
        }

        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums.ToList();
        }

        public IEnumerable<AForumUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Forum GetById(int id)
        {
            return _context.Forums.Where(f => f.Id == id).FirstOrDefault();
             
        }

        public Task UpdateForumDescription(int id, string description)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumTitle(int id, string title)
        {
            throw new NotImplementedException();
        }
    }
}
