using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;
namespace SteveSimmsCodesBlog;
 interface IBlogEmailSender : IEmailSender
{
   Task SendContactEmailAsync(string emailFrom, string name, string subject, string htmlMessage);
}