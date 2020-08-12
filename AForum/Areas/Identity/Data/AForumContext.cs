using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AForum.Areas.Identity.Data;
using AForum.Core;
using AForum.Core.Entities;
using AForum.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AForum.Data
{
    
    public class AForumContext : IdentityDbContext<AForumUser>
    {
        
        public AForumContext(DbContextOptions<AForumContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<AForumUser> AForumUser { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostReply> PostReplies { get; set; }



    }
}
