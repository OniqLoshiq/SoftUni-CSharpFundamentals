using System;
using System.Collections.Generic;
using System.Text;

public class Worker:Human
{
    const int workDaysPerWeek = 5;

    private decimal weekSalary;
    private decimal hoursPerDay;

    public decimal WeekSalary
    {
        get { return weekSalary; }
        private set
        {
            if (value <= 10)
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            weekSalary = value;
        }
    }

    public decimal HoursPerDay
    {
        get { return hoursPerDay; }
        private set
        {
            if (value < 1 || value > 12)
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            hoursPerDay = value;
        }
    }

    private decimal CalcSalaryPerHour()
    {
        decimal salaryPerHour = 0M;

        salaryPerHour = WeekSalary / workDaysPerWeek / HoursPerDay;

        return salaryPerHour;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"First Name: {FirstName}")
            .AppendLine($"Last Name: {LastName}")
            .AppendLine($"Week Salary: {WeekSalary:f2}")
            .AppendLine($"Hours per day: {HoursPerDay:f2}")
            .AppendLine($"Salary per hour: {CalcSalaryPerHour():f2}");
        return sb.ToString();
    }

    public Worker(string firstName, string lastName, decimal weekSalary, decimal hoursPerDay):base(firstName,lastName)
    {
        WeekSalary = weekSalary;
        HoursPerDay = hoursPerDay;
    }
}
