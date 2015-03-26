using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chouanard.Controllers
{
    public class ApplicationController : Controller
    {
        public ApplicationController()
        {
            ViewBag.CurrentYear = DateTime.Now.Year.ToString();
            ViewBag.Title = "Chouanard Creative";
        }
    }
}
