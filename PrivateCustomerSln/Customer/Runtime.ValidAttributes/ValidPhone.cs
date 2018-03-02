using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Runtime.ValidAttributes
{
    public class ValidPhone : Attribute, IValidRuler
    {
        public bool IsValid(object obj)
        {
            if (obj == null)
            {
                return true;
            }
            else
            {
                if (obj.ToString().Trim().Length < 8)
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
