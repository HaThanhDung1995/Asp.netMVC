using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Validate.Attrs
{
    public class EvenNumberAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            int so = Convert.ToInt32(value);
            if (so % 2 == 0)
            {
                return true;
            }
            return false;
        }
    }
}