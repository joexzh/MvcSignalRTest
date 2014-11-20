using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BGProcess
{
    static class Wo
    {
        public class CheckIn : IProcess
        {
            public void Process()
            {
                HttpWebRequest request = HttpWebRequest.Create("http://17wo.cn/SignIn!checkin.action?checkIn=true&rnd=5634") as HttpWebRequest;
                request.Method = "Get";
                request.Host = "17wo.cn";
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Referer = "http://17wo.cn/SignIn.action";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                request.Headers.Add("Accept-Language", "en-US,en;q=0.7,zh-Hans;q=0.3");
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                //request.Headers.Add("Connection", "Keep-Alive");

                CookieContainer cookieContainer = new CookieContainer();
                cookieContainer.Add(new Cookie("CNZZDATA3082302", "cnzz_eid%3D1433975702-1416157995-%26ntime%3D1416290344", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("cookie_user_id", "9965918", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("JSESSIONID", "B3B2D86A6D705367F7E46CC3F959662E", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("sessionid", "B3B2D86A6D705367F7E46CC3F959662E", "/", "17wo.cn"));

                request.CookieContainer = cookieContainer;
                try
                {
                    var result = request.GetResponse();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public class FlowRedPacket : IProcess
        {
            public void Process()
            {
                HttpWebRequest request = HttpWebRequest.Create("http://17wo.cn/FlowRedPacket!LuckDraw.action?pageName=earnflow&_=1416160826663") as HttpWebRequest;
                request.Method = "Get";
                request.Host = "17wo.cn";
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Referer = "http://17wo.cn/FlowRedPacket.action?pageName=earnflow";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
                //request.Headers.Add("Connection", "Keep-Alive");
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                request.Headers.Add("Accept-Language", "en-US,en;q=0.7,zh-Hans;q=0.3");
                request.Headers.Add("Accept-Encoding", "gzip, deflate");

                CookieContainer cookieContainer = new CookieContainer();
                cookieContainer.Add(new Cookie("CNZZDATA3082302", "cnzz_eid%3D1433975702-1416157995-%26ntime%3D1416157995", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("userCenter", "2014-11-17", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("cookie_user_id", "9965918", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("JSESSIONID", "90448E8FFC296643FD16AFB146656018", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("sessionid", "90448E8FFC296643FD16AFB146656018", "/", "17wo.cn"));

                request.CookieContainer = cookieContainer;
                try
                {
                    var result = request.GetResponse();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public class GetRedPacket:IProcess
        {

            public void Process()
            {
                HttpWebRequest request = HttpWebRequest.Create("http://17wo.cn/FlowRedPacket!LuckDraw.action?pageName=&355") as HttpWebRequest;
                request.Method = "Get";
                request.Host = "17wo.cn";
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Referer = "http://17wo.cn/FlowRedPacket.action";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
                //request.Headers.Add("Connection", "Keep-Alive");
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                request.Headers.Add("Accept-Language", "en-US,en;q=0.7,zh-Hans;q=0.3");
                request.Headers.Add("Accept-Encoding", "gzip, deflate");

                CookieContainer cookieContainer = new CookieContainer();
                cookieContainer.Add(new Cookie("cookie_user_id", "9965918", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("sessionid", "0E4011772FA235F4CBBECB0C7FBDD9E6", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("JSESSIONID", "DE096C878DA9809D805169BDBA71ABA9", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("CNZZDATA3082302", "cnzz_eid%3D1044351208-1411800539-http%253A%252F%252Fwww.baidu.com%252F%26ntime%3D1416498020", "/", "17wo.cn"));

                request.CookieContainer = cookieContainer;
                try
                {
                    var result = request.GetResponse();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public class DiamondsRedCon : IProcess
        {

            public void Process()
            {
                HttpWebRequest request = HttpWebRequest.Create("http://17wo.cn/DiamondFlow!changeStatusOfDiamonds.action?diamondButton=red-con") as HttpWebRequest;
                request.Method = "Get";
                request.Host = "17wo.cn";
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Referer = "http://17wo.cn/DiamondFlow.action?aId=85";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
                //request.Headers.Add("Connection", "Keep-Alive");
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                request.Headers.Add("Accept-Language", "en-US,en;q=0.7,zh-Hans;q=0.3");
                request.Headers.Add("Accept-Encoding", "gzip, deflate");

                CookieContainer cookieContainer = new CookieContainer();
                cookieContainer.Add(new Cookie("CNZZDATA3082302", "cnzz_eid%3D1433975702-1416157995-%26ntime%3D1416290344", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("cookie_user_id", "9965918", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("JSESSIONID", "B3B2D86A6D705367F7E46CC3F959662E", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("sessionid", "B3B2D86A6D705367F7E46CC3F959662E", "/", "17wo.cn"));

                request.CookieContainer = cookieContainer;
                try
                {
                    var result = request.GetResponse();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public class DiamondsGreenCon : IProcess
        {

            public void Process()
            {
                HttpWebRequest request = HttpWebRequest.Create("http://17wo.cn/DiamondFlow!changeStatusOfDiamonds.action?diamondButton=green-con") as HttpWebRequest;
                request.Method = "Get";
                request.Host = "17wo.cn";
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Referer = "http://17wo.cn/DiamondFlow.action?aId=85";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
                //request.Headers.Add("Connection", "Keep-Alive");
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                request.Headers.Add("Accept-Language", "en-US,en;q=0.7,zh-Hans;q=0.3");
                request.Headers.Add("Accept-Encoding", "gzip, deflate");

                CookieContainer cookieContainer = new CookieContainer();
                cookieContainer.Add(new Cookie("CNZZDATA3082302", "cnzz_eid%3D1433975702-1416157995-%26ntime%3D1416290344", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("cookie_user_id", "9965918", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("JSESSIONID", "B3B2D86A6D705367F7E46CC3F959662E", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("sessionid", "B3B2D86A6D705367F7E46CC3F959662E", "/", "17wo.cn"));

                request.CookieContainer = cookieContainer;
                try
                {
                    var result = request.GetResponse();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public class DiamondsYellowCon : IProcess
        {

            public void Process()
            {
                HttpWebRequest request = HttpWebRequest.Create("http://17wo.cn/DiamondFlow!changeStatusOfDiamonds.action?diamondButton=yellow-con") as HttpWebRequest;
                request.Method = "Get";
                request.Host = "17wo.cn";
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Referer = "http://17wo.cn/DiamondFlow.action?aId=85";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
                //request.Headers.Add("Connection", "Keep-Alive");
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                request.Headers.Add("Accept-Language", "en-US,en;q=0.7,zh-Hans;q=0.3");
                request.Headers.Add("Accept-Encoding", "gzip, deflate");

                CookieContainer cookieContainer = new CookieContainer();
                cookieContainer.Add(new Cookie("CNZZDATA3082302", "cnzz_eid%3D1433975702-1416157995-%26ntime%3D1416290344", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("cookie_user_id", "9965918", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("JSESSIONID", "B3B2D86A6D705367F7E46CC3F959662E", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("sessionid", "B3B2D86A6D705367F7E46CC3F959662E", "/", "17wo.cn"));

                request.CookieContainer = cookieContainer;
                try
                {
                    var result = request.GetResponse();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

    }
}
