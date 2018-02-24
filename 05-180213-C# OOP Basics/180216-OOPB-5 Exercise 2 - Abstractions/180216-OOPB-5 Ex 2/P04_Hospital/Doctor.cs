using System;
using System.Collections.Generic;
using System.Text;


public class Doctor
{
    string name;
    List<string> patients;

    public string Name { get => name; set => name = value; }
    public List<string> Patients { get => patients; set => patients = value; }

    public Doctor(string name)
    {
        this.name = name;
        this.patients = new List<string>();
    }
}
