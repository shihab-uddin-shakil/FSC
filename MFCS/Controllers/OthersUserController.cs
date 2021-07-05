using MFCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MFCS.Controllers
{
    [Authorize(Roles ="Admin")]
    public class OthersUserController : Controller
    {
        // GET: OthersUser
        MFCSEntities context = new MFCSEntities();
        public ActionResult Index()
        {
            var users = context.Users.ToList();

            return View(users);
        }
        public ActionResult Edit(int Id)
        {
            var user = context.Users.FirstOrDefault(e => e.Id == Id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            var use = context.Users.FirstOrDefault(e => e.Id == user.Id);
            context.Entry(use).CurrentValues.SetValues(user);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Details(int Id)
        {
            var user = context.Users.FirstOrDefault(e => e.Id == Id);
            return View(user);
        }
        public ActionResult Delete(int Id)
        {
            var user = context.Users.FirstOrDefault(e => e.Id == Id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Delete(User user)
        {
            var use = context.Users.FirstOrDefault(e => e.Id == user.Id);
            context.Users.Remove(use);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}