using System;

namespace _09_DateTime
{
    public class DateTimeWrapper : IDateTime
    {
        public DateTime Now { get { return DateTime.Now; } }
    }
}
