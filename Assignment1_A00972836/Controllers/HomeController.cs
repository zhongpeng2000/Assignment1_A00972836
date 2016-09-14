using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment1_Model_A00972836;
using System.Data.Entity;
using Assignment1_A00972836.Models;
using System.Data.Entity.Infrastructure;

namespace Assignment1_A00972836.Controllers
{
    public class HomeController : Controller
    {

        private NorthwindEntities ctx = new NorthwindEntities();

        public ActionResult Index()
        {
            //NorthwindEntities ctx = new NorthwindEntities();
            //DbSet<Region> regions = ctx.Regions;
            IEnumerable<Region> regionList = (from c in ctx.Regions select c);
            return View("Index", RegionView.init(regionList));
            
        }
        [HttpPost]
        public ActionResult IndexPost(IEnumerable<RegionView> model, string submitValue,string newRegion)
        {
            IEnumerable<RegionView> modelDel;
            switch (submitValue)
            {
                case "Add":
                    Add(newRegion);
                    break;
                case "Delete":
                    modelDel = model.Where(m => m.isChecked == true);
                    IList<Region> regionListDel = new List<Region>();
                    foreach(RegionView item in modelDel)
                    {
                        regionListDel.Add(item.region);
                    }
                    Delete(regionListDel);
                    break;
                case "Edit":
                    IList<Region> regionListEdit = new List<Region>();
                    foreach (RegionView item in model)
                    {
                        regionListEdit.Add(item.region);
                    }
                    Edit(regionListEdit);
                    break;
                default:
                    //Console.WriteLine("Default case");
                    break;
            }


            IEnumerable<Region> regionList = (from c in ctx.Regions select c);

            return RedirectToAction("Index");
        }

        private int Add(string newRegion)
        {
            Region region = new Region();
            region.RegionDescription = newRegion;
            ctx.Regions.Add(region);
            ctx.SaveChanges();
            return region.RegionID;
        }

        private IEnumerable<int> Delete(IEnumerable<Region> regionList)
        {
            foreach(Region region in regionList)
            {
                ctx.Regions.Attach(region);
                ctx.Regions.Remove(region);
            }
            ctx.SaveChanges();
            return regionList.Select(m => m.RegionID);
        }

        private void Edit(IEnumerable<Region> regionList)
        {

            foreach (Region region in regionList)
            {

                //var regionOld = ctx.Regions.FirstOrDefault(c => c.RegionID == region.RegionID);
                //ctx.Regions.Attach(ctx.Regions.FirstOrDefault(c => c.RegionID == region.RegionID));
                if(region.RegionID != 0 && region.RegionID > 10)
                ctx.Entry(region).State = EntityState.Modified;
             }
            ctx.SaveChanges();
        }
    }
}