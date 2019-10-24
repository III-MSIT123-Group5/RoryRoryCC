using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BussinessSystem_MVC.ViewModels
{
    public class LoginViewModels
    {
        [Required(ErrorMessage ="{0}不可為空白。")]
        [Display(Name = "帳號")]
        [EmailAddress]
        public string Account { get; set; }

        [Required(ErrorMessage = "{0}不可為空白。")]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [Display(Name = "記住我?")]
        public bool RememberMe { get; set; }
    }
}