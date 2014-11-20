using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace BGProcess
{
    static class NGA
    {
        public class DailyScrapeWall : IProcess
        {
            public void Process()
            {
                string contentStr = "app_id=1001&access_uid=663649&access_token=939dcf0af778d19fd87e17956f3ee309&t=1416489181&sign=8dfef11472f388005831ffc044a61c0f&send_ua=";
                byte[] _contentByte = Encoding.ASCII.GetBytes(contentStr);

                HttpWebRequest request = HttpWebRequest.Create("http://nga.178.com/app_api.php?__lib=checkin&__act=dosign&__ngaClientChecksum=d8e2a96aeef183cda62a288bc5b332531416489181") as HttpWebRequest;
                request.Method = "Post";
                request.Host = "nga.178.com";
                request.Accept = "application/json, text/javascript, */*";
                request.Referer = "http://nga.178.com/misc/checkin_token/index.html?app_id=1001&access_uid=663649&access_token=939dcf0af778d19fd87e17956f3ee309&t=1416489181&sign=8dfef11472f388005831ffc044a61c0f&__ngaClientChecksum=d8e2a96aeef183cda62a288bc5b332531416489181";
                request.UserAgent = "NGA_skull/1.5(iPhone 4S;iOS 8.1.1)";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = contentStr.Length;
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                request.Headers.Add("Accept-Language", "en-us");
                request.Headers.Add("Accept-Encoding", "gzip, deflate");

                CookieContainer cookieContainer = new CookieContainer();
                cookieContainer.Add(new Cookie("_i", "VhGk92S105mlSm3BzAqt8ec90ZoAmj9%2FYhgy7m%2FCl8jxc88R61XllFO5M2wWtslW_3484afdd30a64206ffb235803fdea330_1414326208", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("lastpath", "/app_api.php?__lib=post&__act=list", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("lastvisit", "1416488890", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("ngacn0comInfoCheckTime", "1416488500", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("ngacn0comUserInfo", "%25B7%25A2%25C1%25CB%25B5%25C4%25B7%25E7%25D7%25D0%09%25E5%258F%2591%25E4%25BA%2586%25E7%259A%2584%25E9%25A3%258E%25E4%25BB%2594%0942%0942%09%09-20%09-525%091%090%090%098_-450", "/", "17wo.cn"));
                cookieContainer.Add(new Cookie("ngacn0comUserInfoCheck", "ea50c44c0fccc66092c6a0b3347f9b5e", "/", "17wo.cn"));

                request.CookieContainer = cookieContainer;

                using (Stream s = request.GetRequestStream())
                {
                    s.Write(_contentByte, 0, _contentByte.Length);
                }

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
