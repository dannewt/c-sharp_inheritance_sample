using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceSample
{
    class Employee
    {
        private string m_name;
        private int m_salary;
        private int m_revenue;

        public string Name 
        {
            get { return m_name; }
            set { m_name = value; } 
        }
        public int Salary
        {
            get { return m_salary; }
            set { m_salary = value; }
        }
        public int Revenue
        {
            get { return m_revenue; }
            set { m_revenue = value; }
        }


        public Employee(string name, int salary)
        {
            m_name = name;
            m_salary = salary;
            m_revenue = 0;
        }

        public void Work()
        {
            Console.WriteLine("Employee: " + m_name + " is working.");
        }

        public void Pause()
        {
            Console.WriteLine("Employee: " + m_name + " is paused.");
        }

        public virtual void GenerateRevenue()
        {
            m_revenue = 150000;
        }

    }
}
