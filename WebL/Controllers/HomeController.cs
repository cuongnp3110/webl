﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebL.Models;

namespace WebL.Controllers
{
    public class HomeController : Controller
    {
        private WebLEntities db = new WebLEntities();

        // GET: webls
        public ActionResult Index()
        {
            return View(db.webls.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}