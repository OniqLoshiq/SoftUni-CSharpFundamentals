using System;
using System.Collections.Generic;
using System.Text;

public class Employee
{
    string name;
    decimal salary;
    string position;
    string department;
    string email;
    int age;

    public Employee(string name, decimal salary, string position, string department)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = "n/a";
        this.age = -1;
    }

    public string Position { get => position; set => position = value; }
    public decimal Salary { get => salary; set => salary = value; }
    public string Name { get => name; set => name = value; }
    public string Department { get => department; set => department = value; }
    public string Email { get => email; set => email = value; }
    public int Age { get => age; set => age = value; }
}
