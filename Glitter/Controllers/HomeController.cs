using AspNetCoreHero.ToastNotification.Abstractions;
using Glitter.Models;
using Glitter.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Glitter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMailService mailService;
        private readonly INotyfService toastNotification;
        private readonly IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger, IMailService mailService, INotyfService toastNotification, IConfiguration configuration)
        {
            _logger = logger;
            this.mailService = mailService;
            this.toastNotification = toastNotification;
            this.Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View(new MessageViewModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(MessageViewModel message)
        {
            if (!ModelState.IsValid)
            {
                toastNotification.Custom("Ops,, Something went wrong. Please try again.",
                    backgroundColor: "#b8c99d");
                return BadRequest(ModelState);
            }
            else
            {
                List<Interest>? list = Configuration.GetSection("Interests").Get<List<Interest>>();
                //List<SelectListItem> selectLists = [.. list!.Select(i =>
                //                        new SelectListItem(text: i.Text, value: i.Id))];
                string interestSeg = "I'm  Interested in: ";
                foreach (var item in list!)
                {
                    if (message.Interests!.Contains(item.Id))
                    {
                        interestSeg += item.Text + ", ";
                    }
                }
                await mailService.ReceiveEmailAsync(new MailData
                {
                    ClientId = message.Email,
                    ClientName = message.Name,
                    Subject = "ContactUsMsg-" + message.Subject,
                    Body = message.Content + Environment.NewLine +
                                          interestSeg + Environment.NewLine +
                      message.PhoneNumber + Environment.NewLine +
                      DateTime.Today.Date.ToString("dd / MMMM / yyyy")
                });
                toastNotification.Custom("Your Message has been Received",
                    backgroundColor: "--old-lavender-7");
                return Ok();
            }
        }
    }
}
