using MFCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MFCS.Controllers
{
    public class BuyProductController : Controller
    {
        // GET: BuyProduct
        MFCSEntities context = new MFCSEntities();
        public ActionResult Index()
        {
            var bproducts = context.Buy_Products.ToList();
            return View(bproducts);
        }

        public ActionResult Details(int Id)
        {
            var bpr = context.Buy_Products.FirstOrDefault(e => e.Id == Id);
            return View(bpr);
        }
    }
}