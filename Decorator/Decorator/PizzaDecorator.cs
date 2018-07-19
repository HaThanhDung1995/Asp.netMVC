using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class PizzaDecorator
    {
        protected IPizza iPizza;
        public PizzaDecorator(IPizza pizza)
        {
            iPizza = pizza;
        }

        public IPizza ipizza { get; set; }
    }
}
