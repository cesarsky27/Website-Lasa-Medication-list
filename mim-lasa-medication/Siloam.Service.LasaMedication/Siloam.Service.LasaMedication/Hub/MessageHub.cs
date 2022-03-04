using Siloam.Service.LasaMedication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


namespace Siloam.Service.LasaMedication.Hub
{
    public class MessageHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public Task SendMessage(MessageNotification messageNotification)
        {
            return Clients.All.InvokeAsync("Send", messageNotification);
        }
    }
}
