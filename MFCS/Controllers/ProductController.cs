using MFCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MFCS.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MFCSEntities context = new MFCSEntities();
        public ActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }

        public ActionResult Details(int Id)
        {
            var pr= context.Products.FirstOrDefault(e => e.Id == Id);
            return View(pr);
        }
    }
}