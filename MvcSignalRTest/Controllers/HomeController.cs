using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MvcSignalRTest.Models;

namespace MvcSignalRTest.Controllers
{
    public class HomeController : Controller
    {
        readonly SignalrDbEntities _context = new SignalrDbEntities();

        public ActionResult Canvas()
        {
            if (HttpContext.Application["canvasData"] != null)
            {
                ViewBag.canvasData = HttpContext.Application["canvasData"].ToString();
            }
            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Chat(string userName)
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<Models.ChatContext>());
            //var userList = HttpContext.Application["userList"];
            //ViewBag.UserCount = ((List<string>)userList).Count();
            //ViewBag.UserList = userList;
            return View();
        }

        public JsonResult LoadChatContent(int chatContentSkip, int chatContentTake)
        {
            var chatContent = _context.ChatContents.OrderByDescending(c => c.CreateDate).Skip(chatContentSkip)
                .Take(chatContentTake).Include(u => u.ChatUsers)
                .Select(c => new { c.ChatUsers.UserName, c.Content, c.CreateDate }).ToList();
            return Json(chatContent);
        }

        public bool ValidateUser(string name)
        {
            return ((List<UserOnlineModel>) HttpContext.Application["UserList"]).All(item => item.Name != name || item.Ip == Request.UserHostAddress);
        }

        public bool ChangeUserName(string oldName, string newName)
        {
            foreach (ChatUsers user in from item in (List<UserOnlineModel>)HttpContext.Application["UserList"] where item.Name == oldName select _context.ChatUsers.FirstOrDefault(u => u.UserName == item.Name))
            {
                if (user != null) user.UserName = newName;
                for (int index = 0;
                    index < ((List<UserOnlineModel>) HttpContext.Application["UserList"]).Count;
                    index++)
                {
                    UserOnlineModel item = ((List<UserOnlineModel>) HttpContext.Application["UserList"])[index];
                    if (item == null) throw new ArgumentNullException("newName");
                    if (item.Name == oldName)
                    {
                        item.Name = newName;
                    }
                }
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool GetUser(string name)
        {
            foreach (var item in (List<UserOnlineModel>)HttpContext.Application["UserList"])
            {
                if (Session["UserId"].ToString() != item.Id) continue;
                ChatUsers user = _context.ChatUsers.FirstOrDefault(u => u.UserName == name);

                if (user != null)
                {
                    if (user.IPAddress != Request.UserHostAddress)
                    {
                        user.IPAddress = Request.UserHostAddress;
                    }
                    _context.SaveChanges();
                }
                else
                {
                    user = new ChatUsers()
                    {
                        UserName = name,
                        IPAddress = Request.UserHostAddress
                    };
                    _context.ChatUsers.Add(user);
                    _context.SaveChanges();
                }
                user = _context.ChatUsers.First(u => u.UserName == name);
                item.Name = user.UserName;
                item.Ip = Request.UserHostAddress;
                return true;
            }
            return false;
        }
    }

}
