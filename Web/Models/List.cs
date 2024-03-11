using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class List
    {
        public string cdate { get; set; }
        public string cplace { get; set; }
        public string cname { get; set; }
        public string pname { get; set; }
 
        
    }
    public class ListSec
    {
        public string cdate { get; set; }
        public string cplace { get; set; }
        public string cname { get; set; }
        public string pname { get; set; }

    }
    public class AllList
    {
        public List<List> Lists { get; set; }
        public List<ListSec> ListSecs { get; set;}

    }
}