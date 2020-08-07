using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AForum.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AForumUser class
    public class AForumUser : IdentityUser
    {
        public string UserDescription { get; set; }
        public string ProfileImage { get; set; }
        public int Rating { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public DateTime MemberSince { get; set; }
    }
}
