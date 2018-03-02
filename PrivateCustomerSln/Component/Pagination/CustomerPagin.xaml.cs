using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using FirstFloor.ModernUI.Windows.Controls;

namespace Component.Pagination
{
    /// <summary>
    /// 自定义的下拉框项
    /// </summary>
    public class ComboboxModelItem : INotifyPropertyChanged
    {
        private int id;
        private string text;
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    this.Notify("Id");
                }
            }
        }
        public string Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    this.Notify("Text");
                }
            }
        }

        //实现通知
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    /// <summary>
    /// 自定义的重新加载事件关联
    /// </summary>
    public class ReloadArgs : RoutedEventArgs
    {
        public ReloadArgs(RoutedEvent route, object source)
            : base(route, source)
        {

        }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
    /// <summary>
    /// CustomerPagin.xaml页面的交互逻辑
    /// </summary>
    public partial class CustomerPagin : UserControl, INotifyPropertyChanged
    {
        private static CustomerPagin Current;
        public CustomerPagin()
        {
            InitializeComponent();
            Current = this;
            this.DataContext = this;//前台绑定的数据
        }

        #region 下拉表(每页数量)
        private static ObservableCollection<ComboboxModelItem> ciSource = new ObservableCollection<ComboboxModelItem>();
        //本页的下拉菜单集合
        public ObservableCollection<ComboboxModelItem> ComboboxItemSource
        {
            get
            {
                if (ciSource.Count() == 0)
                {
                    ciSource.Add(new ComboboxModelItem { Id = 10, Text = "10" });
                    ciSource.Add(new ComboboxModelItem { Id = 20, Text = "20" });
                    ciSource.Add(new ComboboxModelItem { Id = 50, Text = "50" });
                    ciSource.Add(new ComboboxModelItem { Id = 100, Text = "100" });

                }
                if (this.SelectedComboboxItem == null)
                {
                    this.SelectedComboboxItem = ciSource[0];
                }
                return ciSource;
            }
        }//observable自动通知

        private ComboboxModelItem selected;
        public ComboboxModelItem SelectedComboboxItem
        {
            get
            {
                return selected;
            }
            set
            {
                this.Size = value.Id;//传给页面信息数量
                if (selected != value)
                {
                    selected = value;
                    this.Notify("SelectedComboboxItem");
                }
            }
        }//combobox自动通知
        #endregion

        #region 前台特有的通知属性
        private int pageNums = 0;
        public int TotalPageCount//总页数
        {
            get { return pageNums; }
            set
            {
                if (this.pageNums != value)
                {
                    this.pageNums = value;
                    this.Notify("TotalPageCount");
                }
            }
        }

        private int scount = 0;
        public int StartCount//开始显示的信息条数
        {
            get { return scount; }
            set
            {
                if (this.scount != value)
                {
                    this.scount = value;
                    this.Notify("StartCount");
                }
            }
        }
        private int ecount = 0;
        public int EndCount//结束显示的信息条数
        {
            get { return ecount; }
            set
            {
                if (this.ecount != value)
                {
                    this.ecount = value;
                    this.Notify("EndCount");
                }
            }
        }

        #endregion

        #region 依赖属性，分页中转作用(包括暴露的命令)
        //默认的总信息量
        public static readonly DependencyProperty TotalInfoCountProperty =
            DependencyProperty.Register("TotalInfoCount", typeof(int), typeof(CustomerPagin), new PropertyMetadata(0, new PropertyChangedCallback(TotalInfoCountChange)));
        /// <summary>
        /// 信息总量的变化，直接引起总页数的变化
        /// 如果总页数没有减少到小于当前页码，则只有总页数变化，其他都保持不变
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="args"></param>
        static void TotalInfoCountChange(DependencyObject dep, DependencyPropertyChangedEventArgs args)
        {
            ReloadUI((int)args.NewValue);
        }
        static void ReloadUI(int count)
        {
            //保证至少有1页（即使没有信息）
            int temppcount = (int)Math.Ceiling(Convert.ToDouble(count) / Convert.ToDouble(Current.Size));
            Current.TotalPageCount = temppcount >= 1 ? temppcount : 1;//赋值并引发通知

            //增加当前页的约束
            if (Current.Page > Current.TotalPageCount)
            {
                Current.Page = Current.TotalPageCount;
            }
            if (Current.Page < 1)
            {
                Current.Page = 1;
            }

            //显示具体信息
            Current.StartCount = Current.Size * (Current.Page - 1) + 1;
            int tempend = Current.Size * Current.Page;
            Current.EndCount = tempend <= Current.TotalInfoCount ? tempend : Current.TotalInfoCount;

            //追加判断
            if (Current.StartCount > Current.EndCount)
            {
                Current.StartCount = Current.EndCount;
            }
        }
        public int TotalInfoCount//通过包装可以读写依赖属性，但xaml页面的绑定不会触发此处的get或set，只有cs页面调用，才会触发get或set
        {
            get { return (int)GetValue(TotalInfoCountProperty); }
            set { SetValue(TotalInfoCountProperty, value); }
        }


        //默认的页码
        public static readonly DependencyProperty PageProperty =
            DependencyProperty.Register("Page", typeof(int), typeof(CustomerPagin), new PropertyMetadata(1, new PropertyChangedCallback(PageChange)));
        public int Page
        {
            get { return (int)GetValue(PageProperty); }
            set { SetValue(PageProperty, value); }
        }
        static void PageChange(DependencyObject dep, DependencyPropertyChangedEventArgs args)
        {
            if ((int)args.NewValue > Current.TotalPageCount)//新的值大于总页数，返回最大页数
            {
                Current.Page = Current.TotalPageCount;
                return;
            }
            if ((int)args.NewValue < 1)
            {
                Current.Page = 1;
            }
            //需要重新加载UI
            ReloadUI(Current.TotalInfoCount);
        }


        //默认的每页信息量
        public static readonly DependencyProperty PageSizeProperty =
            DependencyProperty.Register("Size", typeof(int), typeof(CustomerPagin), new PropertyMetadata(10, new PropertyChangedCallback(SizeChange)));
        public int Size
        {
            get { return (int)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty, value); }
        }
        static void SizeChange(DependencyObject dep, DependencyPropertyChangedEventArgs args)
        {
            if (!args.NewValue.Equals(args.OldValue))
            {
                ReloadUI(Current.TotalInfoCount);
            }
        }

        //刷新页面的命令(外部可绑定实际的刷新命令)
        public static readonly DependencyProperty ReloadCmdProperty =
            DependencyProperty.Register("ReloadCmd", typeof(ICommand), typeof(CustomerPagin), new PropertyMetadata(null));
        public ICommand ReloadCmd
        {
            get { return (ICommand)GetValue(ReloadCmdProperty); }
            set { SetValue(ReloadCmdProperty, value); }
        }

        #endregion

        #region 实现接口INotifyPropertyChanged
        //实现通知接口
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

        #region 处理前台命令的绑定执行

        private void FirstCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.Page > 1;
            e.Handled = true;
        }

        private void FirstCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (this.Page > 1)
            {
                this.Page = 1;//首页，直接到第一页 
                this.ReloadCmd.Execute(null);
            }
            e.Handled = true;
        }

        private void preview_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.Page > 1;
            e.Handled = true;
        }

        private void preview_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (this.Page > 1)
            {
                this.Page -= 1;
                this.ReloadCmd.Execute(null);
            }
            e.Handled = true;
        }

        private void next_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.Page < this.TotalPageCount;
            e.Handled = true;
        }

        private void next_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (this.Page < this.TotalPageCount)
            {
                this.Page += 1;
                this.ReloadCmd.Execute(null);
            }
            e.Handled = true;
        }

        private void last_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.Page < this.TotalPageCount;
            e.Handled = true;
        }

        private void last_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (this.Page < this.TotalPageCount)
            {
                this.Page = this.TotalPageCount;
                this.ReloadCmd.Execute(null);
            }
            e.Handled = true;
        }

        #endregion
    }
}
