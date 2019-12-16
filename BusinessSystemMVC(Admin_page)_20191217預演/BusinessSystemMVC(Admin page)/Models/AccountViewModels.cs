using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace BusinessSystemMVC_Admin_page_.Models
{
    public static  class EmployeeDetail
    { 
        public static string Name{get;set;}
        public static int EmployeeID { get; set; }
        public static string Account { get; set; }
        public static string Gender { get; set; }
        public static DateTime BirthDay { get; set; }
        public static DateTime HireDay { get; set; }
        public static string OfficeName { get; set; }
        public static int  OfficeID { get; set; }
        public static string DepartmentName { get; set; }
        public static int DepartmentID { get; set; }
        public static string ManagerName { get; set; }
        public static int ManagerID { get; set; }
        public static bool Employed { get; set; }
        public static string PhotoAdress { get; set; }
        public static string GroupName { get; set; }
        public static int GroupID { get; set; }
        public static string PositionName { get; set; }
        public static int PositionID { get; set; }
    }


    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "代碼")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "記住此瀏覽器?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "帳號")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [Display(Name = "記住我?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel     //註冊model    
    {
        [Required(ErrorMessage = "請輸入{0}！")]
        [Display(Name = "員工姓名")]
        public string EmpoyeeName { get; set; }

        [Required(ErrorMessage = "請輸入{0}！")]
        [Display(Name = "帳號")]
        public string Account { get; set; }

        [Required(ErrorMessage = "請輸入{0}！")]
        [StringLength(100, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Password", ErrorMessage = "密碼和確認密碼不相符。")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        [Required(ErrorMessage = "請選擇{0}！")]
        [StringLength(10)]
        [Display(Name = "性別")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "請選擇{0}！")]
        [Display(Name = "生日年份")]
        public int BirthYear { get; set; }

        [Required(ErrorMessage = "請選擇{0}！")]
        [Display(Name = "生日月份")]
        public int BirthMonth { get; set; }

        [Required(ErrorMessage = "請選擇{0}！")]
        [Display(Name = "生日日期")]
        public int BirthDate { get; set; }

        [Required(ErrorMessage = "請選擇{0}！")]
        [DataType(DataType.Date)]
        [Display(Name = "雇用日期")]
        public DateTime HireDay { get; set; }

        [Required(ErrorMessage = "請選擇{0}！")]
        [Display(Name = "辦公室")]
        public int OfficeID { get; set; }

        [Required(ErrorMessage = "請選擇{0}！")]
        [Display(Name = "部門")]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "請選擇{0}！")]
        [Display(Name = "職位名稱")]
        public int PositionID { get; set; }

        [Required(ErrorMessage = "請選擇{0}！")]
        [Display(Name = "直系主管")]
        public int ManagerID { get; set; }

        [Required(ErrorMessage = "請選擇{0}！")]
        [Display(Name = "組別")]
        public int GroupID { get; set; }

        [Required(ErrorMessage = "請選擇{0}！")]
        [Display(Name = "在職狀態")]
        public bool Employed { get; set; }

        [Display(Name = "個人照片")]
        public string Photo { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Password", ErrorMessage = "密碼和確認密碼不相符。")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }
    }
}
