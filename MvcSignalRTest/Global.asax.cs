using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BGProcess;
using MvcSignalRTest.Common;

namespace MvcSignalRTest
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        Thread t1;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            Application["UserList"] = new List<Models.UserOnlineModel>();

            //EmailSender sender = new EmailSender();
            //sender.SendMySelf("canvassynctest.apphb.com", "app start");

            ThreadStart start = new ThreadStart(InvokeProcess.Process);
            t1 = new Thread(start);
            t1.Start();
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            Models.UserOnlineModel userInfo = new Models.UserOnlineModel()
            {
                Ip = Request.UserHostAddress
            };
            Session["UserId"] = userInfo.Id;
            Application.Lock();
            ((List<Models.UserOnlineModel>)Application["UserList"]).Add(userInfo);
            Application.UnLock();
        }

        protected void Session_End(Object sender, EventArgs e)
        {
            Application.Lock();
            foreach (var item in (List<Models.UserOnlineModel>)Application["UserList"])
            {
                if (item.Id == Session["UserId"].ToString())
                {
                    ((List<Models.UserOnlineModel>)Application["UserList"]).Remove(item);
                    break;
                }
            }
            Application.UnLock();
        }

        protected void Application_End()
        {
            EmailSender sender = new EmailSender();
            sender.SendMySelf("canvassynctest.apphb.com", "app end");

            t1.Abort();
        }
    }
}