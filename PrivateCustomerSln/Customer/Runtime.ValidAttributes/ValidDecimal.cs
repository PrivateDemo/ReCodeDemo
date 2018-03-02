using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Runtime.ValidAttributes
{
    public class ValidDecimal : Attribute, IValidRuler
    {
        public bool IsValid(object obj)
        {
            if (obj == null)
            {
                return true;
            }
            else
            {
                decimal temp;
                return decimal.TryParse(obj.ToString(), out temp);
            }
        }
    }
}
