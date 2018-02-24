using System;
using System.Collections.Generic;
using System.Text;


public class Company
{
    string name;
    string department;
    decimal salay;

    public Company(string name, string department, decimal salay)
    {
        this.name = name;
        this.department = department;
        this.salay = salay;
    }

    public string Name { get => name; set => name = value; }
    public string Department { get => department; set => department = value; }
    public decimal Salay { get => salay; set => salay = value; }
}
