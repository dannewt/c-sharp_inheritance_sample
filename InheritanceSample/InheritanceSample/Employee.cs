using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceSample
{
    class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Revenue { get; set; }


        public Employee(string name, int salary)
        {
            this.Name = name;
            this.Salary = salary;
            this.Revenue = 0;
        }

        public void Work()
        {
            Console.WriteLine("Employee: " + this.Name + " is working.");
        }

        public void Pause()
        {
            Console.WriteLine("Employee: " + this.Name + " is paused.");
        }

        public virtual void GenerateRevenue()
        {
            this.Revenue = 150000;
        }

    }
}
