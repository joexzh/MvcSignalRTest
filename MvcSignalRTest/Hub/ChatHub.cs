using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Data.Entity;
using System.Net;
using System.Web.SessionState;
using System.Web.Services;

namespace MvcSignalRTest
{
    public class ChatHub : Hub
    {
        Models.SignalrDbEntities context = new Models.SignalrDbEntities();

        public void ChangeNameNotice(string oldName, string newName)
        {
            Clients.All.ChangeNameNotice(oldName, newName);
        }

        public void Send(string name, string message)
        {
            Models.ChatUsers chatUser = context.ChatUsers.FirstOrDefault(u => u.UserName == name);
            Models.ChatContents chatContent = new Models.ChatContents()
            {
                Content = message,
                CreateDate = DateTime.Now,
                ChatUsers = chatUser
            };
            context.ChatContents.Add(chatContent);
            context.SaveChanges();
            Clients.All.addNewMessageToPage(name, message, DateTime.Now);
        }

        public void ReflashCount()
        {
            var userList = ((List<Models.UserOnlineModel>)HttpContext.Current.Application["UserList"]);
            int count = userList.Count();
            Clients.All.reflashCount(count, userList);
        }

        public void UserJoinNotice(string userName)
        {
            Clients.All.UserJoinNotice(userName);
        }

        public void ReflashUserList()
        {
            var userList = (List<Models.UserOnlineModel>)HttpContext.Current.Application["UserList"];
            int count = userList.Count();
            Clients.All.ReflashUserList(userList, count);
        }
    }
}