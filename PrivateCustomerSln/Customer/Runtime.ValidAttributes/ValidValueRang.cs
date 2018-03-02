using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Runtime.ValidAttributes
{
    public class ValidValueRang : Attribute, IValidRuler
    {
        public double MinValue { get; private set; }
        public double MaxValue { get; private set; }
        public ValidValueRang(double min, double max)
        {
            this.MinValue = min;
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
                return value >= this.MinValue && value <= this.MaxValue;
            }
            else
            {
                return false;
            }
        }
    }
}
