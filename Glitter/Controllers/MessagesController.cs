using AspNetCoreHero.ToastNotification.Abstractions;

using Glitter.Models;
using Glitter.Services;

using Microsoft.AspNetCore.Mvc;

using System.Xml.Linq;

namespace Glitter.Controllers
{  
    public class MessagesController : Controller
    {
        private readonly IMailService mailService;
        private readonly INotyfService toastNotification;

        public MessagesController(IMailService mailService, INotyfService toastNotification)
        {
            this.mailService = mailService;
            this.toastNotification = toastNotification;
        }
        

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MessageViewModel message)
        {
            if (!ModelState.IsValid)
            {
                toastNotification.Error("Ops,, Something went wrong. Please try again.");
                return BadRequest(ModelState);
            }
            else
            {
                //message
                //{
                //    Email = message.Email,
                //    Content = message.Content,
                //    PhoneNumber = message.PhoneNumber,
                //    Name = message.Name,
                //    TimeSend = DateTime.Now,
                //};
                await mailService.ReceiveEmailAsync(new MailData
                {
                    ToId = message.Email,
                    ToName = message.Name,
                    Subject = "CotactUsMsg" + message.Name,
                    Body = message.Content + Environment.NewLine + message.PhoneNumber,
                });
                toastNotification.Success("Your Message has been Received");
                return Ok();
            }
        }                        
    }
}
