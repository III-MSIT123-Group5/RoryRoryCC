﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace BusinessSystemMVC_Admin_page_.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }

        [Display(Name = "員工編號")]
        public int EmployeeID { get; set; }

        [Display(Name = "員工姓名")]
        public string EmpoyeeName { get; set; }

        [Display(Name = "帳號")]
        public string Account { get; set; }

        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        private string _gendername;
        [Display(Name = "性別")]
        public string Gender
        {
            get
            {
                string gn = "男";
                switch (_gendername)
                {
                    case "M":
                        gn = "男";
                        break;
                    case "F":
                        gn = "女";
                        break;
                }
                return gn;
            }
            set
            {
                _gendername = value;
            }
        }

        [Display(Name = "生日")]
        public DateTime BirthDay { get; set; }

        [Display(Name = "雇用日期")]
        public DateTime HireDay { get; set; }

        [Display(Name = "辦公室")]
        public string OfficeName { get; set; }

        [Display(Name = "部門")]
        public string DepartmentName { get; set; }

        [Display(Name = "組別")]
        public string GroupID { get; set; }

        [Display(Name = "職位名稱")]
        public string PositionID { get; set; }

        [Display(Name = "直系主管")]
        public string ManagerID { get; set; }

        [Display(Name = "在職狀態")]
        public bool Employed { get; set; }

        [Display(Name = "個人照片")]
        public string Photo { get; set; }
        [Display(Name = "特休剩餘時數")]
        public int SpecialLeaves { get; set; }
        [Display(Name = "事假剩餘時數")]
        public int PersonalLeaves { get; set; }
        [Display(Name = "病假剩餘時數")]
        public int SickLeaves { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密碼")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認新密碼")]
        [Compare("NewPassword", ErrorMessage = "新密碼與確認密碼不相符。")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "目前密碼")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密碼")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認新密碼")]
        [Compare("NewPassword", ErrorMessage = "新密碼與確認密碼不相符。")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "電話號碼")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "代碼")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "電話號碼")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}