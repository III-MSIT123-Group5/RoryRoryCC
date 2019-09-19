using BusinessSystemDBEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSystem.EmployeeSystem
{
    class MemberClass
    {
        BusinessDataBaseEntities dbcontext = new BusinessDataBaseEntities () ;
        private string m_Account;
        public string errorstring { get; private set; }

        //public string Account
        //{
        //    get
        //    {

        //    }
        //    set
        //    {
        //        this.m_Account = value;
        //        if (this.checkAccount(this.m_Account))
        //        {

        //        }
        //    }
        //}

        bool checkAccount(string @account)    //方法：檢查帳號是否重覆 true:允許使用 false:重覆
        {
            var q = from ac in dbcontext.Employees
                    where ac.Account == @account
                    select ac;
            if (q.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        }
}
