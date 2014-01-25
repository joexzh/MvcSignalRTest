using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MvcSignalRTest
{
    public class CanvasHub : Hub
    {
        public void MoveTo(string canvasTmpData)
        {
            HttpContext.Current.Application["canvasData"] +=
                HttpContext.Current.Application["canvasData"] == null ? canvasTmpData : "," + canvasTmpData;
            Clients.Others.MoveTo(canvasTmpData);
        }

        public void ClearRect(string canvasTmpData)
        {
            HttpContext.Current.Application["canvasData"] +=
                HttpContext.Current.Application["canvasData"] == null ? canvasTmpData : "," + canvasTmpData;
            Clients.Others.ClearRect(canvasTmpData);
        }

        public void LineTo(string canvasTmpData)
        {
            HttpContext.Current.Application["canvasData"] +=
                HttpContext.Current.Application["canvasData"] == null ? canvasTmpData : "," + canvasTmpData;
            Clients.Others.LineTo(canvasTmpData);
        }
    }
}