using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class PeperDecorator:PizzaDecorator
    {
        public PeperDecorator(IPizza pizza) : base(pizza)
        {
            
        }


        public override String doPizza()
        {
            String type = iPizza.doPizza();
            return type + addPepper();
        }
        private String addPepper()
        {
            return "+ Pepper";
        }
    }
}
