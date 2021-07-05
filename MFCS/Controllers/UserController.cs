using MFCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MFCS.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        MFCSEntities context = new MFCSEntities();
        public ActionResult Index()
        {
            var users = context.Users.ToList();
           
            return View(users);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            DateTime date = new DateTime();
            Transaction tr = new Transaction();
            tr.User_Id = 1;
            tr.Activity = "Register Added";
            tr.Description = user.Name + " Register User Added Successfully";
            tr.Date = date.Day+"/"+date.Month+"/"+date.Year.ToString();
           
            tr.Sold = 0;
            tr.Buy = 0;
            tr.Profit = 110;
            context.Transactions.Add(tr);
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction("Index");
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