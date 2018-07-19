using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class ChickenPizza:IPizza
    {
        public string doPizza()
        {
            return "I am chicken pizza";
        }
    }
}
