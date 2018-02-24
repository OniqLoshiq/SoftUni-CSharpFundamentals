using System;
using System.Collections.Generic;
using System.Text;

public class DateModifier
{
    double dateDifference;

    public double DateDifference
    {
        set { this.dateDifference = value; }
        get { return dateDifference; }
    }

    public double GetDateDifference(string firstDate, string secondDate)
    {
        DateTime date1 = DateTime.ParseExact(firstDate, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
        DateTime date2 = DateTime.ParseExact(secondDate, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);

        DateDifference = (date1 - date2).TotalDays;

        return Math.Abs(DateDifference);

    }
}
