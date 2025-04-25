using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Framework2DGame.Others
{
    /// <summary>
    /// Logging class to provide logs in all the codes
    /// </summary>
    public class LoggingClass
    {

        private static TraceSource source = new TraceSource("Framework Log");

        static LoggingClass()
        {
            source.Switch = new SourceSwitch("Framework Log Switch", SourceLevels.All.ToString());
        }
        public static TraceSource Source => source;


        /// <summary>
        /// Gives an information log
        /// </summary>
        /// <param name="message">The message in the log</param>
        public static void Information(string message)
        {
            source.TraceEvent(TraceEventType.Information, 707, message);
        }

        /// <summary>
        /// Gives a warning log
        /// </summary>
        /// <param name="message">The message in the log</param>
        public static void Warning(string message)
        {
            source.TraceEvent(TraceEventType.Warning, 707, message);
        }

        /// <summary>
        /// Gives an error log
        /// </summary>
        /// <param name="message">The message in the log</param>
        public static void Error(string message)
        {
            source.TraceEvent(TraceEventType.Error, 707, message);
        }

        /// <summary>
        /// Gives a critical log
        /// </summary>
        /// <param name="message">The message in the log</param>
        public static void Critical(string message)
        {
            source.TraceEvent(TraceEventType.Critical, 707, message);
        }



    }
}