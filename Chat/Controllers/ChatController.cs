using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.SignalR;

namespace Chat.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            return View();
        }


        public void SendMessage(string msg, string userName)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();

            context.Clients.All.getMessage(msg, userName);
        }

        public void SendMessageGroup(string msg, string userName, string groupName)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();

            context.Clients.Group(groupName).getMessage(msg, userName);
        }

    }
}
