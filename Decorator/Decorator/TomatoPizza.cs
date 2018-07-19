using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class TomatoPizza:IPizza
    {
        public string doPizza()
        {
            return "I am tomato pizza";
        }
    }
}
