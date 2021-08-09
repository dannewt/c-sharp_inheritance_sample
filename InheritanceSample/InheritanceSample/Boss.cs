using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceSample
{
    class Boss : Employee
    {
        public bool HasCompanyCar { get; set; }

        public List<Employee> Reports { get; set; }

        public Boss(string name, int salary):base(name,salary)
        {
            this.HasCompanyCar = false;
            this.Name = name;
            this.Salary = salary;
            this.Reports = new List<Employee>();
        }

        public void GiveCompanyCar()
        {
            this.HasCompanyCar = true;
            this.Salary += 10000;
        }

        public void RevokeCompanyCar()
        {
            this.HasCompanyCar = false;
        }

        public void ManageEmployees(List<Employee> employeeList)
        {
            float weeklyTimeManaging = 0;
            foreach (Employee employee in employeeList)
            {
                if (employee is Trainee)
                    weeklyTimeManaging += 0.25f;
                else
                    weeklyTimeManaging += 0.1f;
            }
            if (weeklyTimeManaging > 1)
                weeklyTimeManaging = 1;
            this.Revenue = Convert.ToInt32(150000f * (1f - weeklyTimeManaging));
        }

        public override void GenerateRevenue()
        {
            this.ManageEmployees(this.Reports);
        }

    }
}
