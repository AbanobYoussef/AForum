using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForum.Models.Forum
{
    public class DeleteForumModel
    {
        public int ForumId { get; set; }
        public string ForumName { get; set; }
        public int UserId { get; set; }
    }
}
