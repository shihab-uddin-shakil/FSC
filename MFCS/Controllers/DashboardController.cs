using MFCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MFCS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
       
        // GET: Dashboard
        MFCSEntities context = new MFCSEntities();
        public ActionResult Index()
        {
            var profit = context.Transactions.Sum(e => e.Profit);
            var sold = context.Transactions.Sum(e => e.Sold);
            var buye = context.Transactions.Sum(e => e.Buy);
            var avilable = context.Products.Sum(e => e.Stored);
            ViewBag.tprofit = profit;
            ViewBag.tsold = sold;
            ViewBag.tbuye = buye;
            ViewBag.tavilable = avilable;
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                var profit = context.Transactions.Sum(e => e.Profit);
                var sold = context.Transactions.Sum(e => e.Sold);
                var buye = context.Transactions.Sum(e => e.Buy);
                var avilable = context.Products.Sum(e => e.Stored);
                ViewBag.tprofit = profit;
                ViewBag.tsold = sold;
                ViewBag.tbuye = buye;
                ViewBag.tavilable = avilable;
                // DateTime FromDate = Convert.ToDateTime(collection['Form']);
                var dprofit = context.Transactions.Where(e => e.Date == collection["Form"] && e.Date == collection["To"]).Sum(e => e.Profit);
                ViewBag.dtprofit ="This Date Profit:  "+ dprofit;

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}