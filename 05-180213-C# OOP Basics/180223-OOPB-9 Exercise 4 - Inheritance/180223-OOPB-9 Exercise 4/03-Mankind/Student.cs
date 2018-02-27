using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Student:Human
{
    private string facultyNymber;

    public string FacultyNymber
    {
        get { return facultyNymber; }
        private set
        {
            if (value.Length < 5 || value.Length > 10 || !value.All(char.IsLetterOrDigit))
                throw new ArgumentException("Invalid faculty number!");
            facultyNymber = value;
        }
    }

    public Student(string firstName, string lastName,string facultyNymber) :base(firstName, lastName)
    {
        FacultyNymber = facultyNymber;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"First Name: {FirstName}")
            .AppendLine($"Last Name: {LastName}")
            .AppendLine($"Faculty number: {FacultyNymber}");
        return sb.ToString();
    }
}
