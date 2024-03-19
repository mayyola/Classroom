using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Member
    {
        /*public string Id { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }*/
        [DisplayName("帳號")]
        [Required(ErrorMessage = "帳號名稱不可空白")]
        public string Id { get; set; }

        [DisplayName("密碼")]
        [Required]
        public string Password { get; set; }

        [DisplayName("再次輸入密碼")]
        [Required]
        [Compare("Password", ErrorMessage = "輸入密碼必須相同")]
        public string Password2 { get; set; }

        [DisplayName("年齡")]
        [Required]
        [Range(0, 100, ErrorMessage = "年齡必須在0-100之間")]
        public int Age { get; set; }

        [DisplayName("生日")]
        [Required]
        public DateTime Birthday { get; set; }

        [DisplayName("電子信箱")]
        [Required]
        [EmailAddress(ErrorMessage = "Email格式有誤")]
        public string Email { get; set; }
    }
}