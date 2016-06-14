using Microsoft.AspNet.SignalR.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace Conspiratron.Controllers
{
    class ChatWebSocketHandler : WebSocketHandler {
        private static List<ChatWebSocketHandler> _ChatClients = new List<ChatWebSocketHandler>();

        private string userName;

        public ChatWebSocketHandler(string userName) : base(512) {
            this.userName = userName;
        }

        public override void OnOpen() {
            _ChatClients.Add(this);
        }

        public override void OnMessage(string message) {
           _ChatClients.ForEach(n=> n.Send($"{userName}:{message}"));
        }


    }

    async Task ProcessQueue(AspNetWebSocketContext context) {
  
    }

    public class ChatController : ApiController
    {
        // GET: Chat
        public  HttpResponseMessage Get(string username)
        {

            HttpContext.Current.AcceptWebSocketRequest(new ChatWebSocketHandler(username));

            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);


            HttpContext.Current.AcceptWebSocketRequest(ProcessQueue);

            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);



        }
    }
}