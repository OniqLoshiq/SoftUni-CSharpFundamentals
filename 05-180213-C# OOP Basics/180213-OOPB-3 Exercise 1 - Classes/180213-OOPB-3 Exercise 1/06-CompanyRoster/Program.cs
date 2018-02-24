using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();

        int n = int.Parse(Console.ReadLine());

        GetEmplyees(employees, n);

        
        var searchedDepartment = employees.GroupBy(x => x.Department)
                                 .OrderByDescending(x => x.Average(y => y.Salary))
                                 .FirstOrDefault().ToList();


        Console.WriteLine($"Highest Average Salary: {searchedDepartment[0].Department}");

        foreach (var employee in searchedDepartment.OrderByDescending(x => x.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
        }
    }

    private static void GetEmplyees(List<Employee> employees, int n)
    {
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();

            string name = input[0];
            decimal salary = decimal.Parse(input[1]);
            string position = input[2];
            string department = input[3];

            Employee worker = new Employee(name, salary, position, department);

            if (input.Length == 5)
            {
                if (int.TryParse(input[4], out _))
                {
                    worker.Age = int.Parse(input[4]);
                }
                else
                {
                    worker.Email = input[4];
                }
            }
            else if (input.Length == 6)
            {
                worker.Age = int.Parse(input[5]);
                worker.Email = input[4];
            }

            employees.Add(worker);
        }
    }
}
