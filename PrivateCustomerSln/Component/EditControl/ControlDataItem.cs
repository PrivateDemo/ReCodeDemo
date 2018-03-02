using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;
using Customer.Runtime.UIAttributes;
namespace Component.EditControl
{
    /// <summary>
    /// 作为新增或编辑时，用户输入的条目
    /// 根据数据类型或业务需求，以不同控件获取输入
    /// </summary>
    public class ControlDataItem : INotifyPropertyChanging
    {
        #region 基本属性
        public Visibility VisibleNotNull { get; set; }//必填提示符的可见性
        public string DisplayName { get; set; }//显示名称
        public object Source { get; set; }//绑定数据源（只有集合控件才有效，例如下拉菜单）
        public EnDic_EditControlType ControlType { get; set; }//控件的类型

        private object currentValue = null;
        public object CurrentValue//当前输入值，如果是选择性控件，则是当前选项
        {
            get { return currentValue; }
            set
            {
                if (this.currentValue != value)
                {
                    this.currentValue = value;
                    this.Notify("CurrentValue");
                }
            }
        }
        public int OrderBy { get; set; }//显示次序

        #endregion

        //==============解析对应的属性
        public string PropertyName { get; set; }//预加载时，对应的属性名称

        //===============实现通知接口

        public event PropertyChangingEventHandler PropertyChanging;
        void Notify(string name)
        {
            if (this.PropertyChanging != null)
            {
                this.PropertyChanging(this, new PropertyChangingEventArgs(name));
            }
        }
    }
}
