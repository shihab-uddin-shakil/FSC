using MFCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MFCS.Controllers
{

    [Authorize(Roles = "Admin")]
    public class ComplainController : Controller
    {
        // GET: Complain
        MFCSEntities context = new MFCSEntities();
        MFCSEntities1 context2 = new MFCSEntities1();
        public ActionResult Index()
        {
           
            var complains = context.Complains.ToList();
            return View(complains);
        }
        public ActionResult Reply()
        {
          //  var cm = context.Complains.FirstOrDefault(e => e.Id == Id);
            return View();
        }
        [HttpPost]
        public ActionResult Reply(ReplyComplain reply)
        {
            context2.ReplyComplains.Add(reply);
            context2.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int Id)
        {
            var com = context.Complains.FirstOrDefault(e => e.Id == Id);
            return View(com);
        }
        public ActionResult Delete(int Id)
        {
            var cm = context.Complains.FirstOrDefault(e => e.Id == Id);
            return View(cm);
        }
        [HttpPost]
        public ActionResult Delete(Complain cn)
        {
            var cmpl= context.Complains.FirstOrDefault(e => e.Id == cn.Id);
            context.Complains.Remove(cmpl);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}