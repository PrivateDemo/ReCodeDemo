using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Utility.HttpUtility
{
    public class WxConfig
    {
        //域名地址
        public static string SERVERURL = string.Empty;// ConfigurationManager.AppSettings["SERVERURL"].ToString();
        //基本开发信息
        public const string APPID = "wx22f8f65fc8a1d5d5";
        public const string APPSECRET = "09b0995c42dcafd0eb3b9ba48d231c33";
        public const string APPTOKEN = "myAccount";
        //微信支付信息
        public const string MCHID = "1386459602";
        public const string KEY = "jcbokOKMjcbokOKMjcbokOKMjcbokOKM";

        //=======【证书路径设置】===================================== 
        /* 证书路径,注意应该填写绝对路径（仅退款、撤销订单时需要）
        */
        public const string SSLCERT_PATH = "cert/apiclient_cert.p12";//false;
        public const string SSLCERT_PASSWORD = "1386459602";//false;



        //=======【支付结果通知url】===================================== 
        /* 支付结果通知回调url，用于商户接收支付结果
        */
        public static string NOTIFY_URL = string.Format("http://{0}/WeiXin/FansPayResult", string.Empty);// ConfigurationManager.AppSettings["SERVERURL"].ToString());

        //=======【商户系统后台机器IP】===================================== 
        /* 此参数可手动配置也可在程序中自动获取
        */
        public const string IP = "120.24.94.225";


        //=======【代理服务器设置】===================================
        /* 默认IP和端口号分别为0.0.0.0和0，此时不开启代理（如有需要才设置）
        */
        public const string PROXY_URL = "http://10.152.18.220:8080";

        //=======【上报信息配置】===================================
        /* 测速上报等级，0.关闭上报; 1.仅错误时上报; 2.全量上报
        */
        public const int REPORT_LEVENL = 1;

        //=======【日志级别】===================================
        /* 日志等级，0.不输出日志；1.只输出错误信息; 2.输出错误和正常信息; 3.输出错误信息、正常信息和调试信息
        */
        public const int LOG_LEVENL = 0;


    }
}
