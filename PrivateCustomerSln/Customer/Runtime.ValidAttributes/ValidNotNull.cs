using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Runtime.ValidAttributes
{
    public class ValidNotNull : Attribute, IValidRuler
    {
        public bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            string text = value as string;
            return text == null || text.Trim().Length != 0;
        }
    }
}
