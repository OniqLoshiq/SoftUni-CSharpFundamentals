using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Animal
{
    private string name;
    private int age;
    private string gender;

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException();
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value.ToString()) || value < 0)
                throw new ArgumentException();
            age = value;
        }
    }

    public string Gender
    {
        get { return gender; }
        private set
        {
            if (value == "Male" || value == "Female")
                gender = value;
            else 
                throw new ArgumentException();
        }
    }

    public Animal()
    {
    }

    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public virtual string ProduceSound()
    {
        return "";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(this.GetType().Name)
            .AppendLine($"{Name} {Age} {Gender}")
            .AppendLine(ProduceSound());

        return sb.ToString();
    }

}
