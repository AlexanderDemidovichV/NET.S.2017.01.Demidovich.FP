using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ORM;

namespace MvcPL.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var ctx = new EntityModel())
            {
                var query = ctx.Fields;
                //var count = query.Count();
            }
            return View();
        }
    }
}