using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TMDT_ver4.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời bạn nhập username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập password")]
        public string Password { get; set; }
    }
}