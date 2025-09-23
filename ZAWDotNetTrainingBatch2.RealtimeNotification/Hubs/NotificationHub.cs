﻿using Microsoft.AspNetCore.SignalR;
namespace ZAWDotNetTrainingBatch2.RealtimeNotification.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendAnnouncement(string title,string content)
        {
            await Clients.All.SendAsync("ReceiveAnnouncement", title, content);
        }
    }
}
