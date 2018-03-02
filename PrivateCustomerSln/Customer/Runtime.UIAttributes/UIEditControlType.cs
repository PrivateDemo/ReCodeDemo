using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Runtime.UIAttributes
{
    public class UIEditControlType : Attribute
    {
        private EnDic_EditControlType controlType = EnDic_EditControlType.空;
        public EnDic_EditControlType ControlType
        {
            get { return controlType; }
            set { controlType = value; }
        }

    }
}
