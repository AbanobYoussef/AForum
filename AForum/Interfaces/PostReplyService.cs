using AForum.Core.Entities;
using AForum.Core.Interfaces;
using AForum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForum.Interfaces
{
    public class PostReplyService : IPostReply
    {
        private readonly AForumContext _context;

        public PostReplyService(AForumContext context)
        {
            _context = context;
        }

        public PostReply GetById(int id)
        {
            return _context.PostReplies.First(r => r.Id == id);
        }

        public async Task Delete(int id)
        {
            var reply = GetById(id);
            _context.Remove(reply);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(int id, string message)
        {
            var reply = GetById(id);
            await _context.SaveChangesAsync();
            _context.Update(reply);
            await _context.SaveChangesAsync();
        }

        PostReply IPostReply.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
