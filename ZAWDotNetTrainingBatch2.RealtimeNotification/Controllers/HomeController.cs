using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using ZAWDotNetTrainingBatch2.RealtimeNotification.Hubs;
using ZAWDotNetTrainingBatch2.RealtimeNotification.Models;

namespace ZAWDotNetTrainingBatch2.RealtimeNotification.Controllers
{
 
        public class HomeController : Controller
        {

            private readonly IHubContext<NotificationHub> _hubContext;

            public HomeController(IHubContext<NotificationHub> hubContext)
            {
                _hubContext = hubContext;
            }

            public IActionResult Index()
            {
                return View();
            }

            public IActionResult Privacy()
            {
                return View();
            }

            public async Task<IActionResult> SendAnnouncement(string title, string content)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveAnnouncement", title, content);
                return Ok();
            }
        }
    }
    
