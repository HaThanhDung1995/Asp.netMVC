using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataSharing.Utils
{
    public class HitCounter
    {
        static Dictionary<String, int> counters = new Dictionary<String, int>();
        public static void Hit(String Url)
        {
            if (counters.ContainsKey(Url))
            {
                counters[Url]++;
            }
            else
            {
                counters[Url] = 1;
            }
        }

        public static Dictionary<String, int> Counters
        {
            get
            {
                return counters;
            }
        }
    }
}