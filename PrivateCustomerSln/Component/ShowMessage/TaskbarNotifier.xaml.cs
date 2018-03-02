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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Component.ShowMessage
{
    /// <summary>
    /// TaskbarNotifier.xaml 的交互逻辑
    /// </summary>
    public partial class TaskbarNotifier : Window
    {
        public double EndTop { get; set; }
        public TaskbarNotifier(string title, string content)
        {
            InitializeComponent();
            titleLb.Content = title;
            contentTxt.Text = content;

            this.Height = SystemParameters.WorkArea.Height * 0.2;
            this.Width = SystemParameters.WorkArea.Width * 0.15;

            this.Left = SystemParameters.WorkArea.Width - this.Width;
            this.EndTop = SystemParameters.WorkArea.Height - this.Height;
            this.Top = SystemParameters.WorkArea.Height - this.Height;
            BitmapImage imagetemp = new BitmapImage(new Uri("..\\Images\\exitico.png", UriKind.Relative));
            this.imgClose.Source = imagetemp;
        }
        public void Stop()
        {
            Dispatcher.Invoke(() =>
            {
                this.Image_MouseLeftButtonDown(null, null);
            });
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.IsEnabled = false;

            mGrid.OpacityMask = this.Resources["ClosedBrush"] as LinearGradientBrush;
            Storyboard std = this.Resources["ClosedStoryboard"] as Storyboard;
            std.Completed += delegate
            {
                this.Close();
            };

            std.Begin();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WaitToStop();
        }

        public void WaitToStop()
        {
            System.Threading.ParameterizedThreadStart start = new System.Threading.ParameterizedThreadStart(BeginShowMessage);
            System.Threading.Thread th = new System.Threading.Thread(start);
            th.IsBackground = true;//设置为后台线程，主线程关闭，随之关闭
            th.Start();//开始线程
        }
        void BeginShowMessage(object obj)
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
            this.Stop();
        }
    }
}
