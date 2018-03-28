using Logger.Model.Interfaces;
using Logger.Model.Models;
using System;
using System.Globalization;

namespace Logger.Model.Factories
{
    public class LogFactory
    {
        const string dateFormat = "M/d/yyyy h:mm:ss tt";

        public ILog CreateLog(string[] args)
        {
            string reportType = args[0];
            string date = args[1];
            string message = args[2];

            DateTime dateTime = DateTime.ParseExact(date, dateFormat, CultureInfo.InvariantCulture);

            if (!Enum.TryParse(typeof(ReportLevel), reportType, true, out object reportLevelObj))
            {
                throw new ArgumentException("Invalid Report Level!");
            }

            ILog log = new Log(dateTime, message, (ReportLevel)reportLevelObj);

            return log;
        }
    }
}
