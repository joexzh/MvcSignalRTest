using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email
{
    using System;
    using System.Data;
    using System.Configuration;
    using System.Net.Mail;
    /**/
    /// <summary>
    /// sendMail 的摘要说明
    /// </summary>
    public class Mail
    {

        /// <summary> 
        /// 发送邮件 For Ex:Mail.Send("zhaoyao@126.com", new string[] { "zhaoyao@126.com", "zyip@qq.com" }, "test attment and mutile receive", false, "body", "mail.126.com", null, null, new string[] { "c:\\sp.txt", "c:\\sp.txt" })
        /// </summary> 
        /// <param name="from">发送人邮件地址</param> 
        /// <param name="to">接收人邮件地址列表</param> 
        /// <param name="subject">邮件主题</param> 
        /// <param name="isBodyHtml">是否是Html</param> 
        /// <param name="body">邮件体</param> 
        /// <param name="smtpHost">SMTP服务器地址,例如:smtp.163.com</param> 
        /// <param name="userName">用户名，不需要身份验证时使用null</param> 
        /// <param name="password">密码，不需要身份验证时使用null</param> 
        /// <param name="attachments">附件地址列表</param> 
        /// <returns>是否成功</returns> 
        public static bool Send(string from, string[] to, string subject, bool isBodyHtml, string body, string smtpHost, string userName, string password, string[] attachments)
        {
            bool isSuccess = true;
            try
            {
                MailMessage mm = new MailMessage();
                mm.From = new MailAddress(from);
                for (int i = 0; i < to.Length; i++)
                {
                    mm.To.Add(new MailAddress(to[i]));
                }
                mm.Subject = subject;
                mm.IsBodyHtml = isBodyHtml;
                mm.Body = body;
                #region 附件
                if (attachments != null)
                {
                    for (int i = 0; i < attachments.Length; i++)
                    {
                        if (System.IO.File.Exists(attachments[i]))
                        {
                            Attachment a = new Attachment(attachments[i]);
                            mm.Attachments.Add(a);
                        }
                    }
                }
                #endregion
                SmtpClient sc = new SmtpClient(smtpHost);
                sc.Host = smtpHost;
                sc.UseDefaultCredentials = false;
                //smtpClient.EnableSsl = true;//如果服务器不支持ssl则报，服务器不支持安全连接 错误 
                if (!(string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password)))
                {
                    sc.Port = 587;
                    sc.EnableSsl = true;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.UseDefaultCredentials = true;//winform中不受影响，asp.net中，false表示不发送身份严正信息 
                    sc.Credentials = new System.Net.NetworkCredential(userName, password);
                }
                sc.Send(mm);
                mm.Dispose();
                sc = null;
                mm = null;
            }
            catch
            {
                isSuccess = false;
            }

            return isSuccess;
        }
    }
}
