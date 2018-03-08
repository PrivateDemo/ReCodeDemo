using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
namespace Customer.Utility
{
    public static class ComboboxUtility
    {
        /// <summary>
        /// 把枚举特性（类型：属性的特性）解析为集合
        /// 结果集合元素：Id为枚举value，Text为枚举描述
        /// 创建者：王子敬
        /// 创建时间：2018-03-08
        /// </summary>
        /// <param name="t">属性为枚举的特性</param>
        /// <returns>集合(Id=value,Text=text)</returns>
        public static ObservableCollection<dynamic> GetEnDicCombobox(System.Reflection.PropertyInfo t)
        {
            try
            {
                if (t.PropertyType.IsEnum)
                {
                    Array ar = t.PropertyType.GetEnumValues();//获取枚举值
                    ObservableCollection<dynamic> dics = new ObservableCollection<dynamic>();
                    for (int i = 0; i < ar.Length; i++)
                    {
                        var temp = ar.GetValue(i);
                        int tempid = Convert.ToInt32(temp);
                        string temptext = temp.ToString();

                        dics.Add(new { Id = tempid, Text = temptext });
                    }
                    return dics;
                }
                else
                {
                    return new ObservableCollection<dynamic>();
                }
            }
            catch
            {
                return new ObservableCollection<dynamic>();
            }
        }

        /// <summary>
        /// 把枚举类型解析成集合
        /// 创建者：王子敬
        /// 创建时间：2016-04-27
        /// 最新修改：2016-04-27
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <returns>集合</returns>
        public List<DTO_ComboboxItem> GetEnDicCombobox<T>() where T : struct
        {
            try
            {
                List<DTO_ComboboxItem> dics = new List<DTO_ComboboxItem>();
                foreach (int index in Enum.GetValues(typeof(T)))
                {
                    dics.Add(new DTO_ComboboxItem() { Id = index, Text = Enum.GetName(typeof(T), index) });
                }
                return dics;
            }
            catch
            {
                return new List<DTO_ComboboxItem>();
            }
        }
        /// <summary>
        /// 查询枚举值的枚举描述
        /// 创建者：王子敬
        /// 创建时间：2016-04-27
        /// </summary>
        /// <typeparam name="N">数据源枚举</typeparam>
        /// <param name="i">值</param>
        /// <returns>字典描述内容</returns>
        public string GetContent<N>(int i) where N : struct
        {
            try
            {
                return Enum.GetName(typeof(N), i);
            }
            catch
            { return string.Empty; }
        }
        /// <summary>
        /// 查询枚举描述的枚举值
        /// 创建者：王子敬
        /// 创建时间：2016-04-27
        /// </summary>
        /// <typeparam name="P">数据源枚举</typeparam>
        /// <param name="content">名称</param>
        /// <returns>值</returns>
        public int GetValue<P>(string content) where P : struct
        {
            try
            {
                return (int)Enum.Parse(typeof(P), content);
            }
            catch
            { return -1; }
        }
    }
}
