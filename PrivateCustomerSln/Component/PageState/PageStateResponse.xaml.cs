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

namespace Component.PageState
{
    /// <summary>
    /// 对页面状态进行响应的控件
    /// 需要外部绑定PageState来通知此控件
    /// </summary>
    public partial class PageStateResponse : UserControl
    {
        private static PageStateResponse current;
        /// <summary>
        /// 需要为此属性绑定值
        /// </summary>
        public EnDic_PageState PageState
        {
            get { return (EnDic_PageState)GetValue(PageStateProperty); }
            set { SetValue(PageStateProperty, value); }
        }

        public static readonly DependencyProperty PageStateProperty =
            DependencyProperty.Register("PageState", typeof(EnDic_PageState), typeof(PageStateResponse), new PropertyMetadata(EnDic_PageState.默认状态, PageStateChange));

        private static void PageStateChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d != null && e != null)
            {
                var state = (EnDic_PageState)e.NewValue;
                switch (state)
                {
                    //页面空闲状态，即页面可以执行任何功能
                    case EnDic_PageState.默认状态:
                    case EnDic_PageState.查询结束:
                    case EnDic_PageState.修改结束:
                    case EnDic_PageState.删除完毕:
                    case EnDic_PageState.空闲状态:
                        current.Visibility = Visibility.Collapsed;
                        break;
                    //等待状态，即此时页面提示等待，无法运行该页面任何功能
                    case EnDic_PageState.首次加载中:
                    case EnDic_PageState.查询中:
                    case EnDic_PageState.修改中:
                    case EnDic_PageState.删除中:
                    case EnDic_PageState.等待状态:
                        current.Visibility = Visibility.Visible;
                        break;

                    //默认，是页面空闲的状态
                    default:
                        current.Visibility = Visibility.Collapsed;
                        break;
                }
            }
        }
        public PageStateResponse()
        {
            InitializeComponent();
            current = this;
            current.Visibility = Visibility.Collapsed;
        }
    }
}
