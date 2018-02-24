using System;
using System.Collections.Generic;
using System.Text;


public class Department
{
    string name;
    List<string> patients;

    public string Name { get => name; set => name = value; }
    public List<string> Patients { get => patients; set => patients = value; }

    public Department(string name)
    {
        this.name = name;
        this.patients = new List<string>();
    }

    public bool CanAddPatient()
    {
        if(Patients.Count <= 60)
        {
            return true;
        }
        return false;
    }
}

