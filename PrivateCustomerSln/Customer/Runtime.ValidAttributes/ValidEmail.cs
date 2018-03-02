using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Runtime.ValidAttributes
{
    public class ValidEmail : Attribute, IValidRuler
    {
        public bool IsValid(object obj)
        {
            if (obj == null)
            {
                return true;
            }
            else
            {
                if (obj.ToString().IndexOf("@") < 1
                    || obj.ToString().IndexOf(".") < 3
                    || obj.ToString().EndsWith("@")
                    || obj.ToString().EndsWith("."))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
