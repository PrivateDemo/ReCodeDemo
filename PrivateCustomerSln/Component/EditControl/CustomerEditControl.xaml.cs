using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Customer.Runtime.UIAttributes;
namespace Component.EditControl
{
    /// <summary>
    /// CustomerEditControl.xaml 的交互逻辑
    /// </summary>
    public partial class CustomerEditControl : UserControl
    {
        //当前实例的缓存
        private static CustomerEditControl Current;
        //控件类型(从外传入，判断呈现)
        public EnDic_EditControlType ControlType
        {
            get { return (EnDic_EditControlType)GetValue(ControlTypeProperty); }
            set { SetValue(ControlTypeProperty, value); }
        }
        public static readonly DependencyProperty ControlTypeProperty =
            DependencyProperty.Register("ControlType", typeof(EnDic_EditControlType), typeof(CustomerEditControl), new PropertyMetadata(EnDic_EditControlType.空, new PropertyChangedCallback(TypeChange)));
        static void TypeChange(DependencyObject dep, DependencyPropertyChangedEventArgs args)
        {
            switch ((EnDic_EditControlType)args.NewValue)
            {
                case EnDic_EditControlType.下拉框:
                    break;
                case EnDic_EditControlType.单选框:
                    break;
                case EnDic_EditControlType.复选框:
                    break;
                case EnDic_EditControlType.字典下拉框:
                    MyEnDic mt3 = new MyEnDic();
                    Current.root.AddChild(mt3);
                    break;
                case EnDic_EditControlType.文本框:
                    MyTextbox mt4 = new MyTextbox();
                    Current.root.AddChild(mt4);
                    break;
                case EnDic_EditControlType.时间控件:
                    MyDateTimePicker mt2 = new MyDateTimePicker();
                    Current.root.AddChild(mt2);
                    break;
                case EnDic_EditControlType.空:
                    break;
                case EnDic_EditControlType.选取文件:
                    break;
                case EnDic_EditControlType.选取路径:
                    break;
                default:
                    break;
            }
        }


        //控件值(从内向外，传递结果)
        public object ControlValue
        {
            get { return (object)GetValue(ControlValueProperty); }
            set { SetValue(ControlValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ControlValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ControlValueProperty =
            DependencyProperty.Register("ControlValue", typeof(object), typeof(CustomerEditControl), new PropertyMetadata(null, new PropertyChangedCallback(ValueChange)));

        static void ValueChange(DependencyObject dep, DependencyPropertyChangedEventArgs args)
        {
            string s = args.NewValue.ToString();
        }
        public CustomerEditControl()
        {
            InitializeComponent();
            Current = this;
        }
    }
}
