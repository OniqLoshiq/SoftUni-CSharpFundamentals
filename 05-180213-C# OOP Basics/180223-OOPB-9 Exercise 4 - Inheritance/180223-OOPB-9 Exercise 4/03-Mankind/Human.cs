using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class Human
{
    private string firstName;
    private string lastName;

    protected string FirstName
    {
        get { return firstName; }
        set
        {
            CheckNameUppercase(value, "firstName");
            CheckNameLength(value, 4, "firstName");
            firstName = value;
        }
    }

    protected string LastName
    {
        get { return lastName; }
        set
        {
            CheckNameUppercase(value, "lastName");
            CheckNameLength(value, 3, "lastName");
            lastName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    private static void CheckNameUppercase(string name, string property)
    {
        if (!char.IsUpper(name[0]))
            throw new ArgumentException($"Expected upper case letter! Argument: {property}");
    }

    private static void CheckNameLength(string name, int length, string property)
    {
        if (name.Length < length)
            throw new ArgumentException($"Expected length at least {length} symbols! Argument: {property}");
    }

}
