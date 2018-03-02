using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Runtime.ValidAttributes
{
    public interface IValidRuler
    {
        bool IsValid(object obj);
    }
}
