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
        /// 把枚举解析为集合
        /// 元素：Id为枚举value，Text为枚举描述
        /// </summary>
        /// <param name="t">枚举</param>
        /// <returns>集合</returns>
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
    }
}
