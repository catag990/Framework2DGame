using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Framework2DGame
{
    public class LoggingClass
    {

        public void Start()
        {

            Trace.Listeners.Clear();
            TraceSource tc = new TraceSource("Framework Log");

            //Tiene que poder ser opcional los trace listeners, además de poder
            //borrar o añadir otros
            tc.Listeners.Add(new ConsoleTraceListener());
            tc.Listeners.Add(new TextWriterTraceListener("GameLog.txt"));
            tc.Listeners.Add(new XmlWriterTraceListener("log.xml"));






            Trace.AutoFlush = true;
        }
    }
}
