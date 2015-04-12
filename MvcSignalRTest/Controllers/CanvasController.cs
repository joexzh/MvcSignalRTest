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

        [HttpGet]
        public ActionResult Index()
        {
            List<Canvas> canvasList = _db.Canvas.ToList();
            return View(canvasList);
        }

        [HttpPost]
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

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var content = _db.Canvas.Find(id);
            return View(content);
        }

        [HttpPut]
        public int Update(Canvas canvas)
        {
            Canvas canvas2Change = new Canvas {Id = canvas.Id};

            _db.Canvas.Attach(canvas2Change);

            SetProp(canvas, canvas2Change);

            return _db.SaveChanges();

        }

        private void SetProp(Canvas origin, Canvas target)
        {
            if (origin.Name != null)
            {
                target.Name = origin.Name;
            }

            if (origin.Content != null)
            {
                target.Content = origin.Content;
            }
        }
    }
}
