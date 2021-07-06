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
        public ActionResult Index(DateTime from ,DateTime to)
        {
          //  try
          //  {
                var profit = context.Transactions.Sum(e => e.Profit);
                var sold = context.Transactions.Sum(e => e.Sold);
                var buye = context.Transactions.Sum(e => e.Buy);
                var avilable = context.Products.Sum(e => e.Stored);
                ViewBag.tprofit = profit;
                ViewBag.tsold = sold;
                ViewBag.tbuye = buye;
                ViewBag.tavilable = avilable;
               
                // DateTime FromDate = Convert.ToDateTime(collection['Form']);
                var dprofit = context.Transactions.ToList().Where(e =>Convert.ToDateTime(e.Date) >= from && Convert.ToDateTime(e.Date) <= to).Sum(e => e.Profit);
            // ViewBag.dtprofit =from+ "To " + to+". This Dat Total Profit:  "+ dprofit +"Taka";
              ViewBag.dte = from + "To " + to + " History:";
            ViewBag.a = "Total Profit";
            ViewBag.b = "Total Sold";
            ViewBag.c = "Total Bought";
            ViewBag.d = "Taka";
               ViewBag.dtprofit = dprofit;
              var dsold = context.Transactions.ToList().Where(e => Convert.ToDateTime(e.Date) >= from && Convert.ToDateTime(e.Date) <= to).Sum(e => e.Sold);
               ViewBag.dtsale =  dsold;
               var dbuy = context.Transactions.ToList().Where(e => Convert.ToDateTime(e.Date) >= from && Convert.ToDateTime(e.Date) <= to).Sum(e => e.Buy);
                ViewBag.datebuy = dbuy ;


            return View();
         
        }
    }
}
