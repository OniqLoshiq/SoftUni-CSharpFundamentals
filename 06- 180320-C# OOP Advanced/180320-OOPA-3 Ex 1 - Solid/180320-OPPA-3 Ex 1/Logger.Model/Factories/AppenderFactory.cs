using Logger.Model.Interfaces;
using Logger.Model.Models;
using Logger.Model.Models.Appenders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Model.Factories
{
    public class AppenderFactory
    {
        public IAppender CreateAppender(string[] args)
        {
            string appenderType = args[0];
            string layoutType = args[1];

            LayoutFactory layoutFactory = new LayoutFactory();
            ILayout layout = layoutFactory.CreateLayout(layoutType);

            IAppender appender = null;

            if(args.Length == 2)
            {
                switch (appenderType)
                {
                    case "ConsoleAppender": appender = new ConsoleAppender(layout); break;
                    case "FileAppender": appender = new FileAppender(layout); break;
                    default:
                        throw new ArgumentException("Invalid Appender Type!");
                }
            }
            else
            {
                string reportType = args[2];

                if (!Enum.TryParse(typeof(ReportLevel), reportType, true, out object reportLevelObj))
                {
                    throw new ArgumentException("Invalid Report Level!");
                }
                ReportLevel reportLevelThreshold = (ReportLevel)reportLevelObj;

                switch (appenderType)
                {
                    case "ConsoleAppender": appender = new ConsoleAppender(layout, reportLevelThreshold); break;
                    case "FileAppender": appender = new FileAppender(layout, reportLevelThreshold); break;
                    default:
                        throw new ArgumentException("Invalid Appender Type!");
                }
            }
            return appender;
        }
    }
}
