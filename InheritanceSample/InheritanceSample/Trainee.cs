using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceSample
{
    class Trainee : Employee
    {
        public Trainee(string name, int salary) : base(name, salary)
        {
            this.Name = name;
            this.Salary = salary;
            this.Revenue = 0;
        }

        public override void GenerateRevenue()
        {
            this.Revenue = 75000;
        }
    }
}
