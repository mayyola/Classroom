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
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Web.Controllers
{
   
    //[SessionTimeoutAttribute]
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
            ViewBag.date = id;
            string[,] info = new string[param.Section().Length, param.RoomNum().Length];
            string[,] pname = new string[param.Section().Length, param.RoomNum().Length];
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    foreach (char item in dr["classtime"].ToString())
                    {

                        int i = Array.IndexOf(param.Section(), item.ToString());
                        int j = Array.IndexOf(param.RoomNum(), dr["classroom"].ToString());
                        info[i, j] = dr["cname"].ToString();
                        pname[i, j] = dr["pname"].ToString();


                    }

                }
            }
            ViewBag.Info = info;
            ViewBag.Pname = pname;
            
            return View("Index");
        }


        public ActionResult Room(string id)
        {
            
            string[,] info = new string[7, param.Section().Length];
            string[,] pname = new string[7, param.Section().Length]; 
            string FirstDay = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek + (int)DayOfWeek.Monday).ToString("yyyy-MM-dd");
            var DateList = new List<DateList>();
            for (var i = 0; i < 7; i++)
            {

                string mydate = Convert.ToDateTime(FirstDay).AddDays(+i).ToString("yyyy-MM-dd");

                DateList.Add(new DateList { Date= mydate });
                var idformat = mydate.Replace('-', ',');
                DateTime datevalue = DateTime.Parse(idformat);
                var WeekDay = param.WeekDay((int)datevalue.DayOfWeek);
                var sql = @"
               (SELECT cname, classroom,weekday,classtime, pname, uuser FROM loanlist WHERE starttime <= @id AND endtime >= @id AND weekday = @WeekDay AND classroom=@classroom AND status = 'T' order by created_at ASC) 
                UNION
               (SELECT cname, classroom,weekday,classtime, pname, uuser FROM course WHERE starttime <= @id AND endtime >= @id AND weekday = @WeekDay AND classroom=@classroom AND  status = 'T' order by created_at ASC) ";
                MySqlCommand cmd = new MySqlCommand(sql, database.conn);
                cmd.Parameters.AddWithValue("@id", datevalue);
                cmd.Parameters.AddWithValue("@weekday", WeekDay);
                cmd.Parameters.AddWithValue("@classroom", id);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        foreach (char item in dr["classtime"].ToString())
                        {
                         
                            int q = Array.IndexOf(param.Section(),item.ToString());
                            info[i, q] = dr["cname"].ToString();
                            pname[i, q] = dr["pname"].ToString();


                        }
                    }
                }
            }
            ViewBag.Room = id;
            ViewBag.Info = info;
            ViewBag.Pname = pname;
            ViewBag.date = FirstDay;
            ViewBag.weeDate = DateList;
            return View("Room");
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