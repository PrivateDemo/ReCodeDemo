using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.PageState
{
    public enum EnDic_PageState
    {
        默认状态 = 1,//可以针对默认做特殊处理
        等待状态 = 2,//页面忙，显示等待提示
        空闲状态 = 3,//页面正常状态
        首次加载中 = 4,//第一次加载数据
        查询中 = 5,//正在等待查询返回结果
        查询结束 = 6,//查询结束
        修改中 = 7,//正在等待修改的返回结果
        修改结束 = 8,//修改成功之后
        删除中 = 9,//处理删除等待返回结果
        删除完毕 = 10//删除成功之后
    }
}
