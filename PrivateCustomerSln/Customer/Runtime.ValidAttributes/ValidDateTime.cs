using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Runtime.ValidAttributes
{
    public class ValidDateTime : Attribute, IValidRuler
    {
        public bool IsValid(object obj)
        {
            if (obj == null)
            {
                return true;
            }
            else
            {
                DateTime temp;
                if (DateTime.TryParse(obj.ToString().Trim(), out temp))
                {
                    return temp >= DateTime.MinValue && temp <= DateTime.MaxValue;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
