using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Runtime.UIAttributes
{
    public class UIListControlType : Attribute
    {
        private Endic_ShowControlType controlType = Endic_ShowControlType.文本;
        public Endic_ShowControlType ControlType
        {
            get { return controlType; }
            set { controlType = value; }
        }
    }
}
