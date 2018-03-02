using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Component.ShowMessage
{
    public class CustomerShowMessage : UserControl
    {
        public CustomerMessageData MessageInfo
        {
            get { return (CustomerMessageData)GetValue(MessageInfoProperty); }
            set { SetValue(MessageInfoProperty, value); }
        }
        public static readonly DependencyProperty MessageInfoProperty =
            DependencyProperty.Register("MessageInfo", typeof(CustomerMessageData), typeof(CustomerShowMessage), new PropertyMetadata(new CustomerMessageData(EnDic_MessageType.对话框, "系统提示", string.Empty, null), MessageChange));

        static void MessageChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (e == null || d == null)
                {
                    return;
                }

                CustomerMessageData data = (CustomerMessageData)e.NewValue;
                if (string.IsNullOrEmpty(data.TitleInfo) || string.IsNullOrEmpty(data.MessageInfo))
                {
                    return;
                }
                switch (data.MessageType)
                {
                    case EnDic_MessageType.对话框:
                        MessageBoxButton btn = MessageBoxButton.OK;
                        //ModernDialog.ShowMessage(data.MessageInfo, data.TitleInfo, btn, LoginWindow.currentmainwindow);
                        if (data.MainWindow == null)
                        {
                            ModernDialog.ShowMessage(data.MessageInfo, data.TitleInfo, btn);
                        }
                        else
                        {
                            ModernDialog.ShowMessage(data.MessageInfo, data.TitleInfo, btn, data.MainWindow);
                        }
                        break;
                    case EnDic_MessageType.浮出:
                        TaskbarNotifier noti = new TaskbarNotifier(data.TitleInfo, data.MessageInfo);
                        noti.Show();
                        break;
                    case EnDic_MessageType.忽视此消息:
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }
    }
}
