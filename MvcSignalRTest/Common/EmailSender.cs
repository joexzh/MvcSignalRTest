using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Email;
using MvcSignalRTest.Models;

namespace MvcSignalRTest.Common
{
    public class EmailSender
    {
        public string From { get; set; }
        public string[] To { get; set; }
        public string Subject { get; set; }
        public bool IsHtml { get; set; }
        public string Body { get; set; }
        public string SmtpHost { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string[] Attachments { get; set; }

        public EmailSender() { }

        public EmailSender(string from, string[] to, string subject, bool isHtml, string body, string smtpHost, string userName, string password, string[] attachments)
        {
            this.From = from;
            this.To = to;
            this.Subject = subject;
            this.IsHtml = isHtml;
            this.Body = body;
            this.SmtpHost = smtpHost;
            this.UserName = userName;
            this.Password = password;
            this.Attachments = attachments;
        }

        public bool Send()
        {
           return Mail.Send(From, To, Subject, IsHtml, Body, SmtpHost, UserName, Password, Attachments);
        }

        public bool SendMySelf(string subject, string body) {
            UserRepository r = new UserRepository();
            var user = r.GetUserById(1);
            if (user != null)
            {
                this.From = "xiezhenhao@gmail.com";
                this.To = new string[] { "xiezhenhao@gmail.com" };
                this.Subject = subject;
                this.Body = body;
                this.IsHtml = true;
                this.SmtpHost = "smtp.gmail.com";
                this.UserName = user.Name;
                this.Password = user.PWD;

                return Send();
            }

            //this.From = "xiezhenhao@gmail.com";
            //this.To = new string[] { "xiezhenhao@gmail.com" };
            //this.Subject = subject;
            //this.Body = body;
            //this.IsHtml = true;
            //this.SmtpHost = "smtp.gmail.com";
            //this.UserName = "xiezhenhao@gmail.com";
            //this.Password = "Edboyxzhhaha.1";
            //return Send();
            return false;
        }
    }
}