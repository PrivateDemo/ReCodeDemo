using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Component.ShowMessage
{
    /// <summary>
    /// 自定义的消息数据类型
    /// </summary>
    public class CustomerMessageData
    {
        public CustomerMessageData(EnDic_MessageType ty, string title, string info, Window mainWindow)
        {
            this.MessageType = ty;
            this.TitleInfo = title;
            this.MessageInfo = info;
            this.SendTime = DateTime.Now;
            this.MainWindow = mainWindow;//当前的主窗体
        }
        /// <summary>
        /// 消息类型
        /// </summary>
        public EnDic_MessageType MessageType { get; set; }
        /// <summary>
        /// 消息标题
        /// </summary>
        public string TitleInfo { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MessageInfo { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime { get; set; }
        /// <summary>
        /// 提示窗口的父窗体
        /// </summary>
        public Window MainWindow { get; set; }
    }
}
