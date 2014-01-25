using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSignalRTest.Models
{
    public class UserOnlineModel
    {
        public UserOnlineModel(string name, string ip)
        {
            Name = name;
            Ip = ip;
        }

        public UserOnlineModel()
        {
            Id = System.Guid.NewGuid().ToString();
        }

        public string Ip { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
    }
}