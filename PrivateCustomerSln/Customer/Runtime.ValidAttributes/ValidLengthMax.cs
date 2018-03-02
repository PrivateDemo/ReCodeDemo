using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Runtime.ValidAttributes
{
    public class ValidLengthMax : Attribute, IValidRuler
    {
        public int MaxLen { get; private set; }
        public ValidLengthMax(int max)
        {
            this.MaxLen = max;
        }
        public bool IsValid(object obj)
        {
            if (obj == null)
            {
                return true;
            }
            int len = obj.ToString().Trim().Length;
            return len <= this.MaxLen;
        }
    }
}
