using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using System.Threading;

namespace Chat
{
    [HubName("progress")]
    public class ProgressHub : Hub
    {
        public int count = 1;

        public static void SendMessage(string msg, int count)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();
            hubContext.Clients.All.sendMessage(string.Format(msg), count);
        }

        public void SendMessage(string msg)
        {
            ProgressStart();
            Clients.Caller.sendMessage(string.Format(msg), count);
        }

        private void ProgressStart()
        {
            Task.Run(() =>
            {
                for (int i = 1; i <= 100; i++)
                {
                    Thread.Sleep(500);
                    var sendTxt = i != 100 ? "処理中..." : "処理完了！";
                    SendMessage(sendTxt, i);
                }
            });
        }
    }
}