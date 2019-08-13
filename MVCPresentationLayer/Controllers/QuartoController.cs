using MVCPresentationLayer.WEB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPresentationLayer.Controllers
{
    public class QuartoController : BaseController
    {
        // GET: Quarto
        public ActionResult Create()
        {
            return View();
        }
    }
}