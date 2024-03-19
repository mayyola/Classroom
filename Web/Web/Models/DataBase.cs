using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.Odbc;

namespace Web.Models
{
    public class DataBase
    {
        private static string id = "root";
        private static string password = "nsysuee1!";
        private static string database = "classroom";
        private string connString = string.Empty;
        public MySqlConnection conn;
        public DataBase()
        {
            connString = "server=127.0.0.1;port=3306;user id=" + id + ";password=" + password + ";database=" + database + ";charset=utf8;SSL Mode=none;";
            conn = new MySqlConnection(connString);
        }
    }
}