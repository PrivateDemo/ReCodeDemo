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

namespace Component.EditControl
{
    /// <summary>
    /// MyCombobox.xaml 的交互逻辑
    /// </summary>
    public partial class MyCombobox : UserControl
    {
        public MyCombobox()
        {
            InitializeComponent();

            InitBinding();
        }

        private void InitBinding()
        {
            Binding bd = new Binding();
            bd.Path.Path = "LoginId";
            bd.Mode = BindingMode.TwoWay;
            bd.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            
        }
    }
}
