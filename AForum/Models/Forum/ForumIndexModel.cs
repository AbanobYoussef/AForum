using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForum.Models.Forum
{
    public class ForumIndexModel
    {
        public int NumberOfForums { get; set; }
        public IEnumerable<ForumListingModel> ForumList { get; set; }
    }
}
