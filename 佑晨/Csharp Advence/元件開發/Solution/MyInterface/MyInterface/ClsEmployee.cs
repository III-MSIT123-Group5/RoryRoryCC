using System;

namespace MyInterface
{
    public enum JobTitle
    {
        Manager,
        Engineer,
        Tester,
    }

    internal class ClsEmployee: IComparable<ClsEmployee>
    {
        public string EmpName { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public JobTitle EmpTitle { get; set; }

        public int CompareTo(ClsEmployee other)
        {
           if(this.Salary > other.Salary)
            {
                return 1;
            }
           else if(this.Salary < other.Salary)
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }

        public override string ToString()
        {
            return "Employee Name: " + this.EmpName;
        }

    }
}