using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;//判断数据类型

namespace Customer.Utility
{
    public static class DeepCopyUtility
    {
        /// <summary>
        /// 完全替换
        /// 新集合没有的元素会从旧集合删除
        /// 新集合的单个元素，没有的属性，旧集合会设置为null
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="oldList">旧集合</param>
        /// <param name="newList">新集合</param>
        public static void SetValue<T>(ObservableCollection<T> oldList, ObservableCollection<T> newList)
        {
            //获取新的数据行数和旧的数据行数
            int newcount = newList.Count(), oldcount = oldList.Count();
            //先处理公共部分，一定会替换的
            int len = newcount > oldcount ? newcount : oldcount;
            for (int i = 0; i < len; i++)
            {
                if (i >= newcount)
                {
                    oldList.Remove(oldList[newcount]);//ItemSource删除1个元素，索引会减小1，再用i，会超出边界
                }
                else if (i >= oldcount)
                {
                    oldList.Add(newList[i]);
                }
                else
                {
                    SetValue<T>(oldList[i], newList[i]);
                }
            }
        }
        /// <summary>
        /// 完全替换
        /// 旧实例中如果有超出新实例范围的属性，置为null
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="oldObject">旧实例</param>
        /// <param name="newObject">新实例</param>
        public static void SetValue<T>(T oldObject, T newObject)
        {
            //用list的数据，替换ItemSource
            foreach (var item in oldObject.GetType().GetProperties())
            {
                var va = newObject.GetType().GetProperty(item.Name);
                if (va != null)
                {
                    var temp = va.GetValue(newObject);
                    item.SetValue(oldObject, temp);
                }
                else
                {
                    item.SetValue(oldObject, null);
                }
            }
        }
        /// <summary>
        /// 完全替换
        /// 旧实例中如果有超出新实例范围的属性，置为null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="oldObject"></param>
        /// <param name="newObject"></param>
        public static void SetValue<T, U>(T oldObject, U newObject)
        {
            //用list的数据，替换ItemSource
            foreach (var item in oldObject.GetType().GetProperties())
            {
                var va = newObject.GetType().GetProperty(item.Name);
                if (va != null)
                {
                    var temp = va.GetValue(newObject);
                    item.SetValue(oldObject, temp);
                }
                else
                {
                    item.SetValue(oldObject, null);
                }
            }
        }

        /// <summary>
        /// 尝试替换
        /// 新集合没有的元素会从旧集合删除（此点和完全替换相同）
        /// 新集合的单个元素，没有的属性，旧集合不变
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="oldList">旧集合</param>
        /// <param name="newList">新集合</param>
        public static void TrySetValue<T>(ObservableCollection<T> oldList, ObservableCollection<T> newList)
        {
            //获取新的数据行数和旧的数据行数
            int newcount = newList.Count(), oldcount = oldList.Count();
            //先处理公共部分，一定会替换的
            int len = newcount > oldcount ? newcount : oldcount;
            for (int i = 0; i < len; i++)
            {
                if (i >= newcount)
                {
                    oldList.Remove(oldList[newcount]);//ItemSource删除1个元素，索引会减小1，再用i，会超出边界
                }
                else if (i >= oldcount)
                {
                    oldList.Add(newList[i]);
                }
                else
                {
                    TrySetValue<T>(oldList[i], newList[i]);
                }
            }
        }
        /// <summary>
        /// 尝试替换
        /// 新实例中没有值的属性，不做修改
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="oldObject">旧实例</param>
        /// <param name="newObject">新实例</param>
        public static void TrySetValue<T>(T oldObject, T newObject)
        {
            //用list的数据，替换ItemSource
            foreach (var item in oldObject.GetType().GetProperties())
            {
                var va = newObject.GetType().GetProperty(item.Name);
                if (va != null)
                {
                    var temp = va.GetValue(newObject);
                    if (temp != null)
                    {
                        item.SetValue(oldObject, temp);
                    }
                }//如果没有，则不处理
            }
        }
        /// <summary>
        /// 尝试替换
        /// 旧实例中如果有超出新实例范围的属性，置为null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="oldObject"></param>
        /// <param name="newObject"></param>
        public static void TrySetValue<T, U>(T oldObject, U newObject)
        {
            //用list的数据，替换ItemSource
            foreach (var item in oldObject.GetType().GetProperties())
            {
                var va = newObject.GetType().GetProperty(item.Name);
                if (va != null)
                {
                    var temp = va.GetValue(newObject);
                    if (temp != null)
                    {
                        item.SetValue(oldObject, temp);
                    }
                }
            }
        }

        /// <summary>
        /// 修改时的特殊赋值
        /// 不修改key主键
        /// 属性不存在，不修改
        /// 属性值为null，旧实例属性也置为null
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="oldList">旧集合</param>
        /// <param name="newList">新集合</param>
        public static void ModifySetValue<T>(ObservableCollection<T> oldList, ObservableCollection<T> newList)
        {
            //获取新的数据行数和旧的数据行数
            int newcount = newList.Count(), oldcount = oldList.Count();
            //先处理公共部分，一定会替换的
            int len = newcount > oldcount ? newcount : oldcount;
            for (int i = 0; i < len; i++)
            {
                if (i >= newcount)
                {
                    oldList.Remove(oldList[newcount]);//ItemSource删除1个元素，索引会减小1，再用i，会超出边界
                }
                else if (i >= oldcount)
                {
                    oldList.Add(newList[i]);
                }
                else
                {
                    ModifySetValue<T>(oldList[i], newList[i]);
                }
            }
        }
        /// <summary>
        /// 修改时的特殊赋值
        /// 不修改key主键
        /// 属性不存在，不修改
        /// 属性值为null，旧实例属性也置为null
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="oldObject">旧实例</param>
        /// <param name="newObject">新实例</param>
        public static void ModifySetValue<T>(T oldObject, T newObject)
        {
            //用list的数据，替换ItemSource
            foreach (var item in oldObject.GetType().GetProperties())
            {
                var l1 = item.GetCustomAttributes(typeof(KeyAttribute), true);
                KeyAttribute p1 = l1.Count() > 0 ? l1[0] as KeyAttribute : null;

                if (p1 == null)//只能为不是key的值赋值
                {
                    var va = newObject.GetType().GetProperty(item.Name);
                    if (va != null)//只处理有的属性
                    {
                        var temp = va.GetValue(newObject);
                        item.SetValue(oldObject, temp);//只要属性能对应，无论是否是null，都需要赋值
                    }
                }

            }
        }
        /// <summary>
        /// 修改时的特殊赋值
        /// 不修改key主键
        /// 属性不存在，不修改
        /// 属性值为null，旧实例属性也置为null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="oldObject"></param>
        /// <param name="newObject"></param>
        public static void ModifySetValue<T, U>(T oldObject, U newObject)
        {
            //用list的数据，替换ItemSource
            foreach (var item in oldObject.GetType().GetProperties())
            {
                var l1 = item.GetCustomAttributes(typeof(KeyAttribute), true);
                KeyAttribute p1 = l1.Count() > 0 ? l1[0] as KeyAttribute : null;

                if (p1 == null)//只能为不是key的值赋值
                {
                    var va = newObject.GetType().GetProperty(item.Name);
                    if (va != null)
                    {
                        var temp = va.GetValue(newObject);
                        item.SetValue(oldObject, temp);
                    }
                }
            }
        }
    }
}
