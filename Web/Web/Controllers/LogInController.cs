using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models; //使用Models要加use
using System.Web.Security;

namespace Web.Controllers
{
    public class LogInController : Controller
    {
        // string connString = "server=127.0.0.1;port=3306;user id=root;password=Acuteboy1215;database=mvctest;charset=utf8;";
        //MySqlConnection conn = new MySqlConnection();
        // GET: LogIn
        /* public ActionResult Index()
         {
             //return Content("rrr");
            return View();
         }*/
        public ActionResult signout()
        {
            Session.Abandon();
            return Redirect("/Login/Index");
        }
        public ActionResult Index()
        {
            //return View();
            return PartialView(); //不想套版
        }

        public ActionResult IndexGet()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(FormCollection post)
        {
            nsysusso.get_user_info client = new nsysusso.get_user_info();
            if(post["account"] == string.Empty || post["password"] == string.Empty)
                {
                ViewBag.Msg = "帳號或密碼未填寫";
                ViewBag.Account = post["account"];
                return PartialView();

            }
            else
            {
                string CheckLogin = client.authUser2(post["account"], post["password"], "ENC", "1;2");  //這邊是回傳1或0，應該是string
                bool flag = Convert.ToBoolean(Convert.ToInt32(CheckLogin)); //轉換成bool true or false
                
                if (flag)
                {
                    string CatchName = client.getAttr2(post["account"], post["password"], "ENC", "1;2", "EMPNO;NAME;IDNO;PKIND;GRPNO;UNICOD1;DPT_DESC1;UNICOD2;DPT_DESC2;LEAVE;TITCOD;TITLE;EMAIL;POFTEL");
                    string[] UserArray = CatchName.Split(';');
                
                    if (UserArray.Length == 14)
                    {
                        Session["UID"] = UserArray[0];
                        Session["CNAME"] = UserArray[1];
                        Session["identity"] = UserArray[7];
                        Session["stemail "] = UserArray[12];

                    }
                    else
                    {
                        Session["UID"] = UserArray[0];
                        Session["CNAME"] = UserArray[1];
                        Session["identity"] = UserArray[6];
                        Session["stemail "] = UserArray[13];
                    }
                    
                    return Redirect("/Home/Index"); 

                }
                else
                {
                    ViewBag.Msg = "帳號或密碼錯誤";
                    ViewBag.Account = post["account"];
                    return PartialView();
                }
            }
        }
        public ActionResult Verify(LoginViewModel vm) //string account, string password //FormCollection obj //LoginViewModel vm
        {
            ViewBag.account = vm.Account;
            //account;
            //obj["account"];
            ViewBag.password = vm.Password;
            //password;
            //obj["password"];
            return View();
        }
        [HttpGet]
        public ActionResult VerifyGet(LoginViewModel vm)
        {
           // conn.ConnectionString = connString;
            //if (conn.State != ConnectionState.Open)
              //  conn.Open();
            ViewBag.account = vm.Account;
            ViewBag.password = vm.Password;
            return View();
        }
    }
}