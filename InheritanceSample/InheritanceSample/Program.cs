using System;
using System.Collections.Generic;

namespace InheritanceSample
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                //Ask for user input for boss information and create boss instance
                List<Employee> employeeList = new List<Employee>();
                string bossName = NameInput("Manager");
                int bossSalary = SalaryInput("Manager");
                Boss boss = new Boss(bossName, bossSalary);
                employeeList.Add(boss);

                //Check to see if the user would like to give the boss a car
                bool validCarInput = false;
                //check for correct input conditions
                while (!validCarInput)
                {
                    Console.WriteLine("Should the boss have a company car? (Yes or No)");
                    string carInput = Console.ReadLine();
                    carInput = carInput.ToLower();
                    if (carInput == "yes" && !validCarInput)
                    {
                        boss.GiveCompanyCar();
                        Console.WriteLine($"{boss.Name} was given a 2015 Ford Focus");
                        validCarInput = true;
                    }
                    if (carInput == "no" && !validCarInput)
                    {
                        boss.RevokeCompanyCar();
                        Console.WriteLine($"{boss.Name} was not given a car... poor {boss.Name} :(");
                        validCarInput = true;
                    }
                }


                //Allow the user to input new employees and add them to an employee list
                bool inputComplete = false;
                //check to ensure the user did not mean to finish the program
                while (!inputComplete)
                {
                    Console.WriteLine("Enter 1 to create a standard employee, enter 2 to create a trainee, and enter 3 to finish creating employees");
                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        string employeeName = NameInput("Employee");
                        int employeeSalary = SalaryInput("Employee");
                        Employee employee = new Employee(employeeName, employeeSalary);
                        employeeList.Add(employee);
                        boss.Reports.Add(employee);
                    }
                    if (input == "2")
                    {
                        string traineeName = NameInput("Trainee");
                        int traineeSalary = SalaryInput("Trainee");
                        Trainee trainee = new Trainee(traineeName, traineeSalary);
                        employeeList.Add(trainee);
                        boss.Reports.Add(trainee);
                    }
                    if (input == "3")
                    {
                        inputComplete = true;
                    }
                }

                int revenue = GenerateGrossRevenue(employeeList);
                int expenses = GenerateExpenses(employeeList);
                int netProfit = revenue - expenses;

                Console.WriteLine($"The Employees Created {revenue} in revenue");
                Console.WriteLine($"The Employees Used {expenses} in expenses");
                Console.WriteLine($"This left the business with {netProfit} in profit");

                bool validBreakdown = false;
                while (!validBreakdown)
                {
                    Console.WriteLine("Enter 1 to see a breakdown of the employees, enter 'exit' exit");

                    string breakdown = Console.ReadLine().ToLower();
                    if (breakdown == "1")
                    {
                        foreach (Employee employee in employeeList)
                        {
                            Console.WriteLine($"Employee: {employee.Name} generated {employee.Revenue} in revenue, and was paid {employee.Salary}");
                        }
                        validBreakdown = true;
                    }
                    if (breakdown == "exit")
                        Environment.Exit(0);
                }

                Console.WriteLine("Press any button to leave the game");
                Console.ReadLine();
                Environment.Exit(0);
            }

            









        }

        /// <summary>
        /// Creates and validates name for the employee currently being created
        /// </summary>
        /// <param name="position">Input the Position of the Employee</param>
        /// <returns>Returns the Name of the Employee Created</returns>
        private static string NameInput(string position)
        {
            bool validName = false;
            string name = null;
            Console.WriteLine($"Enter {position} Name:");
            //check for correct input conditions
            while (string.IsNullOrEmpty(name))
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine($"{position} name can't be empty! Please enter again...");
                }
                else
                {
                    name = input;
                    validName = true;
                }
            }

            return name;
        }

        /// <summary>
        /// Creates and validates a salary for the employee currently being created
        /// </summary>
        /// <param name="position">Input the Position of the Employee</param>
        /// <returns>Returns the salary of the Employee Created</returns>
        private static int SalaryInput(string position)
        {
            bool validSalary = false;
            int salary = 0;
            while (!validSalary)
            {
                Console.WriteLine($"Enter {position} Salary: (as integer)");
                string input = Console.ReadLine();
                validSalary = int.TryParse(input, out salary);
            }
            return salary;
        }

        /// <summary>
        /// Compile the Gross Revenue created by the employee list
        /// </summary>
        /// <param name="employeeList">The list of employees created</param>
        /// <returns>integer of the company revenue</returns>
        private static int GenerateGrossRevenue(List<Employee> employeeList)
        {
            int grossRevenue = 0;
            foreach (Employee employee in employeeList)
            {
                employee.GenerateRevenue();
                grossRevenue += employee.Revenue;
            }

            return grossRevenue;
        }

        /// <summary>
        /// Compiles the expenses incurred by the employee list
        /// </summary>
        /// <param name="employeeList">The list of employees created</param>
        /// <returns>integer of the company expenses</returns>
        private static int GenerateExpenses(List<Employee> employeeList)
        {
            int expenses = 0;
            foreach(Employee employee in employeeList)
            {
                //multiply salary by an overhead multiplier of 1.35
                expenses += Convert.ToInt32((employee.Salary * 135) / 100);
            }

            return expenses;
        }

    }
}
