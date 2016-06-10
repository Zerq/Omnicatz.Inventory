using DYMO.Label.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Omnicatz.Inventory.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {




            //Omnicatz.Inventory.Data.Context db = new Omnicatz.Inventory.Data.Context();


 
            //var boxA = new Models.Inventory() { Name = "Box A" };
            //var boxB = new Models.Inventory() { Name = "Box B" , Items= new System.Collections.Generic.List<Models.Item>() { boxA } };
            //db.Inventories.Add(boxA);
            //db.Inventories.Add(boxB);
            //db.SaveChanges();


            //var x = db.Inventories.ToList();

             

            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}