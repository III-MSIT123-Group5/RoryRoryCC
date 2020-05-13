using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class ClsBanking
    {

        public override string ToString()
        {
            return "Cls Banking: " + this.Balance.ToString();
        }


        public static int testt;

        public ClsBanking()
        {

        }

        public ClsBanking(decimal Balance)
        {
            this.Balance = Balance;
        }

        public ClsBanking(string  AccName)
        {
            this.Accont = AccName;
        }

        public ClsBanking(string AccName , decimal Balance)
        {
            this.Accont = AccName;
            this.Balance = Balance;
        }

        ~ClsBanking()
        {
            Debug.WriteLine("~ClsBanking()");
        }

        public void Dispose()
        {

        }

        protected decimal m_Balance;
        public decimal Balance
        {
            get
            {
                return m_Balance;
            }
            set
            {
                if (value > 0) {
                    m_Balance = value;
                }
            }
        }

        public int sss = 0;

        public int P1 { get; set; }
        public string Accont { get; set; }


        private int[] nums = { 100, 200, 3300, 400, 500, 600 };
        public int this[int i]
        {
            get
            {
                if( i < 0 || i >= nums.Length)
                {
                    throw new  IndexOutOfRangeException();  
                   }
                return nums[i];
            }
        }

        public virtual decimal Deposit(decimal money)
        {
            return this.m_Balance += money;
        }

        public decimal Withdraw(decimal money)
        {
            if (m_Balance - money < 0)
            {
                throw new Exception("餘額不足啦");
            }
            return this.m_Balance -= money;
        }


        public void Test()
        {
            int x, y;

            A();
            B();
        }

        private void A()
        {
                    
        }
        private void B()
        {

        }



    }

    class MyPoint
    {
        public MyPoint()
        {

        }
         public MyPoint (int p1)
        {
            this.P1 = p1;
        }
        public MyPoint(int p1, int p2)
        {
            this.P1 = p1;
            this.P2 = p2;
        }
        public MyPoint(int p1,int p2 , int p3)
        {
            this.P1 = p1;
            this.P2 = p2;
            this.P3 = p3;
        }

        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }

        public int Field1;
        public int Field2;

    }


    class ClsAAA
    {
       


    }
}

class staticCLS
{
    internal static  int count = 0;
    public staticCLS()
    {
        count += 1;
    }
    ~staticCLS()
    {
        count -= 1;
    }

   

}
