using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment1_Model_A00972836;
using System.Data.Entity;

namespace Assignment1_A00972836.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            NorthwindEntities ctx = new NorthwindEntities();
            //DbSet<Region> regions = ctx.Regions;
            IEnumerable<Region> regionList = (from c in ctx.Regions select c);

            return View(regionList);
        }
    }
}