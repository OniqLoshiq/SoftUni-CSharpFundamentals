using Logger.Model.Interfaces;
using System.Globalization;

namespace Logger.Model.Models.Layouts
{
    public class SimpleLayout : ILayout, IFormatable
    {
        const string dateFormat = "M/d/yyyy h:mm:ss tt";

        public string Format => "{0} - {1} - {2}";

        public string GetLayoutOutput(ILog log)
        {
            string result = string.Format(this.Format, log.Date.ToString(dateFormat, CultureInfo.InvariantCulture), log.ReportLevel, log.Message);

            return result;
        }
    }
}
