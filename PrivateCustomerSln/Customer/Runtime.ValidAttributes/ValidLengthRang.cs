using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Runtime.ValidAttributes
{
    public class ValidLengthRang : Attribute, IValidRuler
    {
        public int MinLen { get; private set; }
        public int MaxLen { get; private set; }
        public ValidLengthRang(int min, int max)
        {
            this.MinLen = min;
            this.MaxLen = max;
        }
        public bool IsValid(object obj)
        {
            if (obj == null)
            {
                return true;
            }
            int len = obj.ToString().Trim().Length;
            return len >= this.MinLen && len <= this.MaxLen;
        }
    }
}
