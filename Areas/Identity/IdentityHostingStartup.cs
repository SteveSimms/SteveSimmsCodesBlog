using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SteveSimmsCodesBlog.Data;
using SteveSimmsCodesBlog.Models;

[assembly: HostingStartup(typeof(SteveSimmsCodesBlog.Areas.Identity.IdentityHostingStartup))]
namespace SteveSimmsCodesBlog.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}