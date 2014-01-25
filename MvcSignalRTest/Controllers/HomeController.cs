using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace MvcSignalRTest.Controllers
{
    public class HomeController : Controller
    {
        Models.SignalrDbEntities context = new Models.SignalrDbEntities();

<<<<<<< HEAD
        public ActionResult Canvas()
        {
            if (HttpContext.Application["canvasData"] != null)
            {
                ViewBag.canvasData = HttpContext.Application["canvasData"].ToString();
            }
            return View();
        }

=======
>>>>>>> 9148ed9237d3b24c82adaf150dbf882347259e4a
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
            var chatContent = context.ChatContents.OrderByDescending(c => c.CreateDate).Skip(chatContentSkip)
                .Take(chatContentTake).Include(u => u.ChatUsers)
                .Select(c => new { c.ChatUsers.UserName, c.Content, c.CreateDate }).ToList();
            return Json(chatContent);
        }

        public bool ValidateUser(string name)
        {
            foreach (var item in (List<Models.UserOnlineModel>)HttpContext.Application["UserList"])
            {
                if (item.Name == name && item.Ip != Request.UserHostAddress)
                {
                    return false;
                }
            }
            return true;
        }

        public bool ChangeUserName(string oldName, string newName)
        {
            foreach (var item in (List<Models.UserOnlineModel>)HttpContext.Application["UserList"])
            {
                if (item.Name == oldName)
                {
                    var user = context.ChatUsers.FirstOrDefault(u => u.UserName == item.Name);
                    user.UserName = newName;
                    foreach (var _item in (List<Models.UserOnlineModel>)HttpContext.Application["UserList"])
                    {
                        if (_item.Name == oldName)
                        {
                            _item.Name = newName;
                        }
                    }
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool GetUser(string name)
        {
            foreach (var item in (List<Models.UserOnlineModel>)HttpContext.Application["UserList"])
            {
                if (Session["UserId"].ToString() == item.Id)
                {
                    Models.ChatUsers user = context.ChatUsers.FirstOrDefault(u => u.UserName == name);

                    if (user != null)
                    {
                        if (user.IPAddress != Request.UserHostAddress)
                        {
                            user.IPAddress = Request.UserHostAddress;
                        }
                        context.SaveChanges();
                    }
                    else
                    {
                        user = new Models.ChatUsers()
                        {
                            UserName = name,
                            IPAddress = Request.UserHostAddress
                        };
                        context.ChatUsers.Add(user);
                        context.SaveChanges();
                    }
                    user = context.ChatUsers.First(u => u.UserName == name);
                    item.Name = user.UserName;
                    item.Ip = Request.UserHostAddress;
                    return true;
                }
            }
            return false;
        }
    }

}
