using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
namespace Customer.Runtime.ValidAttributes
{
    public class ValidFile : Attribute, IValidRuler
    {
        public bool IsValid(object obj)
        {
            if (obj == null)
            {
                return true;
            }
            else
            {
                return File.Exists(obj.ToString().Trim());
            }
        }
    }
}
