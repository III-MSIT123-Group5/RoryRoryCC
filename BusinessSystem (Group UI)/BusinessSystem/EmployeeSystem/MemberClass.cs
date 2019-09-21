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
        BusinessDataBaseEntities dbcontext = new BusinessDataBaseEntities();
        private string m_Account, m_EmployeeName;
        public string errorstring { get; private set; }

        public string Account        //Account屬性
        {
            get
            {
                return m_Account;
            }
            set
            {
                if (this.checkAccount(value) == false)
                {
                    errorstring = "帳號已有,請輸入其他帳號";
                }
                else if (string.IsNullOrEmpty(value))
                {
                    errorstring = "請輸入帳號";
                }
                else
                {
                    errorstring = null;
                    m_Account = value;
                }
            }
        }

        public string EmployeeName
        {
            get
            {
                return m_EmployeeName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    errorstring = "請輸入帳號";
                }
                else
                {
                    errorstring = null;
                    m_EmployeeName = value;
                }

            }
        }

        private bool checkAccount(string @account)    //方法：檢查帳號是否重覆 true:允許使用 false:重覆
        {
            var q = from ac in dbcontext.Accounts 
                    where ac.account1  == @account
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
        //
        //存取登入者姓名 (Kai)

        public string EmpAcount { get; set; }

        public bool namebool { get; set; }
        
    }
}
