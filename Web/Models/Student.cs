using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Student
    {
        public string id { get; set; }
        public string name { get; set; }
        public int score { get; set; }
        public Student() //第一個建構子
        {
            id = string.Empty;
            name = string.Empty;
            score = 0;
        }
        public Student(string _id, string _name, int _score) //第二個建構子
        {
            id = _id;
            name = _name;
            score = _score;
        }
        public override string ToString()
        {
            return $"學號:{id}, 姓名:{name}, 分數:{score}.";
        }
    }
    public class Product
    {
        public int Member { get; set; }
        public string Name { get; set; }
        public int PriceP { get; set; }

    }
    public class MemberInfoViewModel
    {
        public Student Student { get; set; }
        public List<Product> Products { get; set; }


    }
}