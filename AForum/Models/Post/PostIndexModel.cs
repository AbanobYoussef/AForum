﻿using AForum.Models.Reply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForum.Models.Post
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public int AuthorRating { get; set; }
        public DateTime Date { get; set; }
        public bool IsAuthorAdmin { get; set; }
        public string PostContent { get; set; }
        public int ForumId { get; set; }
        public string ForumName { get; set; }

        public IEnumerable<PostReplyModel> Replies { get; set; }

        
    }
}
