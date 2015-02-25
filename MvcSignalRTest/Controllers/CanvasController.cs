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
        readonly SignalrDbEntities _db = new SignalrDbEntities();
        //
        // GET: /Canvas/

        public ActionResult Index()
        {
            List<Canvas> canvasList = _db.Canvas.ToList();
            return View("Canvas", canvasList);
        }

        public List<Canvas> AddCanvas(string name, string content)
        {
            Canvas canvas = new Canvas()
            {
                Name = name,
                Content = content
            };
            _db.Canvas.Add(canvas);
            _db.SaveChanges();

            //after adding, return canvas list
            return _db.Canvas.Select(u => u).ToList();
        }
    }
}
