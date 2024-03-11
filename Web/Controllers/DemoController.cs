using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using System.Data;

namespace Web.Controllers
{
   
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            ViewBag.name = "黃怡";
            TempData["name"] = "哈哈";
            return RedirectToAction("ShowTempData");
        }

        public ActionResult ShowTempData()
        {
            var student = new Student("A1020163", "黃怡",1);
            var products = new List<Product>();
            products.Add(new Product { Member = 1, Name = "A1020163", PriceP = 10000 });
            products.Add(new Product { Member = 2, Name = "A1020164", PriceP = 20000 });
            var memberinforview = new MemberInfoViewModel();
            memberinforview.Student = student;
            memberinforview.Products = products;
            return View(memberinforview);
        }

        public ActionResult ShowMembers()
        {

            var studentA = new Student { id = "A1020163", name = "黃怡", score = 1 };
            var studentB = new Student { id = "A1020164", name = "曾士華", score = 2 };
            var datalist = new List<Student>() { studentA, studentB };
            return View(datalist);
        }

        public ActionResult ShowShoppingList()
        {
            var studentA = new Student { id = "A1020163", name = "黃怡", score = 1 };
            var products = new List<Product>();
            products.Add(new Product{Member=1,Name="aa",PriceP=10000});
            products.Add(new Product { Member = 2, Name = "bb", PriceP = 30000 });
            var memberinfo = new MemberInfoViewModel(); //最後 class的集結
            memberinfo.Student = studentA;
            memberinfo.Products = products;

            return View(memberinfo);
        }

        [HttpGet]
        public string ShowHelloWorld()
        {
            return "Hello World";
        }
        [HttpGet]
        public string HotDog(string product ,int price)
        {
            return $"商品是:{product}，價格是:{price}";
        }
    }
}