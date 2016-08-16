using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


namespace Chat
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        /// <summary>
        /// メッセージをクライアントに返すメソッド
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="userName"></param>
        public void SendMessage(string msg, string userName)
        {
            // TODO:グループでメッセージを送るクライアントを絞り込む
            //////var groupName = string.Empty;
            //////Clients.Group(groupName).getMessage(string.Format(msg), userName);

            // HACK:グループでメッセージを送るクライアントを絞り込むができたら消す
            Clients.All.getMessage(string.Format(msg), userName);
                        
        }

        public void AddGroup(string groupName)
        {
            
        }


        public void SendMessageForGroup(string msg, string userName, string groupName)
        {
            Clients.Group(groupName).getMessage(string.Format(msg), userName);
        }


        // 指定されたグループへ参加する
        public void Join(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
        }

        // 指定されたグループから離脱する
        public void Leave(string groupName)
        {
            Groups.Remove(Context.ConnectionId, groupName);
        }

        // 指定されたグループに参加しているクライアントへメッセージを送信する
        public static void SendGroup(string groupName, string text)
        {
            //Clients.Group(groupName).getMessage(text);
        }
    }
}

