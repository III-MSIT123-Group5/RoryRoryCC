using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyInterface
{
    interface IAnimals
    {
        void MakeNoise();
        string SSSS();
    }

    class Cat : IAnimals
    {
        public void MakeNoise()
        {
            Debug.WriteLine("貓貓");
        }

        public string SSSS()
        {
            throw new NotImplementedException();
        }
    }

    class Dog : IAnimals , IDisposable
    {
        public void Dispose()
        {
            MessageBox.Show("Dispose");
        }

        public void MakeNoise()
        {
            Debug.WriteLine("阿狗");
        }

        public string SSSS()
        {
            return "sssdf";
        }
    }

    interface I1
    {
        void TEST1(int I , int X  );
    }
    interface I2
    {
        void TEST2();
    }

    class SevrelInterface : I1, I2
    {
        public void TEST1(int I, int X)
        {
            throw new NotImplementedException();
        }

        public void TEST2()
        {
            throw new NotImplementedException();
        }
    }
}
