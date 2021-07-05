using MFCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MFCS.Controllers
{
    public class SellProductController : Controller
    {
        // GET: SellProduct
        MFCSEntities context = new MFCSEntities();
        public ActionResult Index()
        {
            var sproducts = context.Sell_Products.ToList();
            return View(sproducts);
        }

        public ActionResult Details(int Id)
        {
            var spr = context.Sell_Products.FirstOrDefault(e => e.Id == Id);
            return View(spr);
        }
    }
}