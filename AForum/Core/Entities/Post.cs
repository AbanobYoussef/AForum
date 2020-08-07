using AForum.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForum.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public bool IsArchived { get; internal set; }



        public virtual AForumUser User { get; set; }
        public virtual Forum forum { get; set; }
        public virtual IEnumerable<PostReply> Replies { get; set; }
    }
}
