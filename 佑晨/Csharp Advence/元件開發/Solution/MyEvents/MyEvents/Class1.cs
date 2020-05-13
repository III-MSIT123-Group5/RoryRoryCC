using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyEvents
{
    class Class1
    {
        public class Info
        {
            public int Price { get; set; }
        }

        public delegate void MyDelegate(int price);
        public event MyDelegate InvalidPrice;

        public delegate void ClsDelegate(Info info);
        public event ClsDelegate ClsInvalidPrice; 

        public void Test (int Price)
        {
            if(Price < 0)
            {
                this.InvalidPrice.Invoke(Price);
            }
        }

        public void ClsTest(Info info)
        {
            if(info.Price < 0)
            {
                this.ClsInvalidPrice.Invoke(info);
            }
        }

        


    }
}
