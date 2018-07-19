using LinQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinQ.Controllers
{
    public class LinqController : Controller
    {
        int[] numbers = { 2, 3, 9, 6, 16, 15, 7 };

        public ActionResult Evens()
        {
            //var evens = from n in numbers
            //            where n % 2 == 0
            //            select n;
            var evens = numbers
                .Where(n => n % 2 == 0)
                .Select(n => n);
            return View(evens);
        }

        public ActionResult Objects()
        {
            //var evens = from n in numbers
            //            where n % 2 == 0
            //            let r = 1.0 * n / numbers.Sum()
            //            orderby n
            //            select new NumberInfo
            //            {
            //                Value = n,
            //                Rate = r
            //            };
            var evens = numbers
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .Select(n => new NumberInfo
                {
                    Value = n,
                    Rate = 1.0 * n / numbers.Sum()
                });
            return View(evens);
        }

        public ActionResult Report()
        {
            var evens = from n in numbers
                        group n by n % 2 into g
                        select new ReportInfo
                        {
                            Group = g.Key,
                            Count = g.Count(),
                            Sum = g.Sum(),
                            Min = g.Min(),
                            Max = g.Max(),
                            Avg = g.Average()
                        };

            return View(evens);
        }
    }
}