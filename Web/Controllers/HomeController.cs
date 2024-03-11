using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using MySql.Data;
using Web.Models;
using System.Data.Odbc;
using System.Data;
using Web.Filters;
using Web.Models;
namespace Web.Controllers
{
   
    [SessionTimeoutAttribute]
    public class HomeController : Controller
    {
        DataBase database;
        AuthLogin param;
       
        public HomeController()
        {
            
            param = new AuthLogin();

            database = new DataBase();
            database.conn.Open();
        }
    
        public ActionResult Index()
        {
            return date(DateTime.Now.ToString("yyyy-MM-dd")) as ActionResult;
        }
        [HttpPost]
        public ActionResult Index(FormCollection post)
        {
           // return (post["cdate"]);
           return date(post["cdate"]) as ActionResult;
            
        }

        public ActionResult date(string id)
        {
            var idformat = id.Replace('-', ',');
            DateTime datevalue = DateTime.Parse(idformat);
            var WeekDay = param.WeekDay((int)datevalue.DayOfWeek);
            var sql = @"
            (SELECT cname, classroom, classtime, pname, uuser FROM loanlist WHERE starttime <= @id AND endtime >= @id AND weekday = @WeekDay AND status = 'T' order by created_at ASC) 
             UNION
            (SELECT cname, classroom, classtime, pname, uuser FROM course WHERE starttime <= @id AND endtime >= @id AND weekday = @WeekDay AND status = 'T' order by created_at ASC) ";
            MySqlCommand cmd = new MySqlCommand(sql, database.conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@weekday", WeekDay);
            MySqlDataReader reader = cmd.ExecuteReader();
            ViewBag.date = id;
            string[,] info = new string[param.Section().Length, param.RoomNum().Length];
            string[,] pname = new string[param.Section().Count(), param.RoomNum().Count()];
            while (reader.Read())
            {
                foreach (char item in reader["classtime"].ToString())
                {

                    int i = Array.IndexOf(param.Section(), item.ToString());
                    int j = Array.IndexOf(param.RoomNum(), reader["classroom"].ToString());
                    info[i, j] = reader["cname"].ToString();
                    pname[i, j] = reader["pname"].ToString();


                }

            }
            ViewBag.Info = info;
            ViewBag.Pname = pname;
           
            return View("Index");
        }
        public ActionResult roomtype()
        {

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        ~HomeController()
        {
            database.conn.Close();
        }
       
    }
}