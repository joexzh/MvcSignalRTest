using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcSignalRTest.Models;

namespace MvcSignalRTest.Controllers
{
    public class CanvasController : Controller
    {
        SignalrDbEntities db = new SignalrDbEntities();
        //
        // GET: /Canvas/

        public ActionResult Index()
        {
            List<Canvas> canvasList = db.Canvas.ToList();
            return View("Canvas", canvasList);
        }

        public List<Canvas> AddCanvas(string name, string content)
        {
            Canvas canvas = new Canvas()
            {
                Name = name,
                Content = content
            };
            db.Canvas.Add(canvas);
            db.SaveChanges();

            //after adding, return canvas list
            return db.Canvas.Select(u => u).ToList();
        }
    }
}
