using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }

        public void Get(int a)
        {
            this.Age += a;
        }
    }


    class Program
    {
        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            return employees.GroupBy(g => g.Company).Select(g => new
            {
                Company = g.Key,
                Age = Convert.ToInt32(Math.Round(g.Average(g => g.Age)))
            }).ToDictionary(g => g.Company, g => g.Age);
        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            return employees.GroupBy(g => g.Company).Select(g => new
            {
                Company = g.Key,
                Employees = g.Count()
            }).ToDictionary(g => g.Company, g => g.Employees);
        }

        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            return employees.GroupBy(g => g.Company).Select(g => new
            {
                Company = g.Key,
                Oldest = g.OrderByDescending(_ => _.Age).FirstOrDefault()
            }).ToDictionary(g => g.Company, g => g.Oldest);
        }

        static void Main(string[] args)
        {
            int countOfEmployees = int.Parse(Console.ReadLine());

            List<Employee> employees = new();

            for (int i = 0; i < countOfEmployees; i++)
            {
                string str = Console.ReadLine();
                string[] strArr = str.Split(' ');
                employees.Add(new Employee
                {
                    FirstName = strArr[0],
                    LastName = strArr[1],
                    Company = strArr[2],
                    Age = int.Parse(strArr[3])
                });
            }

            //foreach (var emp in AverageAgeForEachCompany(employees))
            //{
            //    Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            //}

            //foreach (var emp in CountOfEmployeesForEachCompany(employees))
            //{
            //    Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            //}

            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }
        }
    }
}
