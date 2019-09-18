using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        private class Ittem
        {
            public string Name;
            public int Value;
            public Ittem(string name, int value)
            {
            Name = name;Value = value;
            }
            public override string ToString()
            {
                return Name;
            }
        }
    }
}
