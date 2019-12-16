using BusinessSystemMVC_Admin_page_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessSystemMVC_Admin_page_.ViewModels
{
    public class BulletinBoardEmployeeViewModel
    {

        public BulletinBoard BulletinBoardData
        {
            get; set;
        }

        public Employee EmployeesCollection
        {
            get; set;
        }


    }
}