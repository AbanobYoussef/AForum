using System;
using AForum.Areas.Identity.Data;
using AForum.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AForum.Areas.Identity.IdentityHostingStartup))]
namespace AForum.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AForumContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AForumContextConnection")));

                services.AddDefaultIdentity<AForumUser >(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AForumContext>();



            });
        }
    }
}