using Logger.Model.Interfaces;
using System;
using System.Globalization;

namespace Logger.Model.Models.Layouts
{
    public class XmlLayout : ILayout, IFormatable
    {
        const string dateFormat = "M/d/yyyy h:mm:ss tt";

        public string Format => "<log>" + Environment.NewLine +
                                    "\t<date>{0}</date>" + Environment.NewLine +
                                    "\t<level>{1}</level>" + Environment.NewLine +
                                    "\t<message>{2}</message>" + Environment.NewLine +
                                "</log>" + Environment.NewLine;

        public string GetLayoutOutput(ILog log)
        {
            string result = string.Format(this.Format, log.Date.ToString(dateFormat, CultureInfo.InvariantCulture), log.ReportLevel, log.Message);

            return result;
        }
    }
}
