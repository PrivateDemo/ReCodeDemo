using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Runtime.ValidAttributes
{
    public class ValidValueMax : Attribute, IValidRuler
    {
        public double MaxValue { get; private set; }
        public ValidValueMax(double min, double max)
        {
            this.MaxValue = max;
        }
        public bool IsValid(object obj)
        {

            if (obj == null)
            {
                return true;
            }
            double value;
            if (double.TryParse(obj.ToString(), out value))
            {
                return value <= this.MaxValue;
            }
            else
            {
                return false;
            }
        }
    }
}
