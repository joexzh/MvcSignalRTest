using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcSignalRTest.Models
{
    public class UserRepository
    {
        SignalrDbEntities context = new SignalrDbEntities();

        public User GetUserById(int id) {
            try
            {
                return context.User.Find(id) ?? null;
            }
            catch (Exception ex)
            {
                
                throw;
            }
            
        }
    }
}