using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ActionFilter.Filters
{
    public class Log
    {
        static String path = "c:/temp/logs.txt";
        public static void log(String message)
        {
            File.AppendAllText(path, 
                message + " " + DateTime.Now.ToString("HH:mm:ss") + "\r\n");
        }
    }
}