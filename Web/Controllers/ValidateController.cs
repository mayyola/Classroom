using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ValidateController : Controller
    {
        // GET: Validate
        public ActionResult Index()
        {
            return View();
        }

       //??不用加
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Member member)
        {
            if (!ModelState.IsValid)
            {
                return View(member);

            }
            else
            {
                TempData["Member"] = member;
                return RedirectToAction("Result");
            }
        }
        public ActionResult Result()
        {
            var model = TempData["Member"] as Member; //型別為Member,TempData可以導向一次
            return View(model);
        }
    }
}