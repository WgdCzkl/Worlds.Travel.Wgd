using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Civilization.Shapes;
using Worlds.Model.Dimension.Space.LongitudeAndLatitude;
using Worlds.Model.Dimension.Volume;

namespace Worlds.Model
{
    public class BzStringExtensions<T>
    {

        public static string GetBzString(T model)
        {
            var t = typeof(T);

            string bzString = string.Empty;
            foreach (var property in GetExportPropertyMaps())
            {
                PropertyInfo pi = typeof(T).GetRuntimeProperty(property.Key);
                bzString += string.Format("{0}{1}{0}", property.Key, pi.GetValue(model, null));
            }

            return string.Format("{0}{1}{0}", typeof(T).Name, bzString);


        }



        #region
        /// <summary>
        /// 获取实体的属性映射
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetExportPropertyMaps()
        {
            Dictionary<string, string> propertyMaps = new Dictionary<string, string>();
            List<Tuple<int, Tuple<string, string>>> list = new List<Tuple<int, Tuple<string, string>>>();
            foreach (PropertyInfo info in typeof(T).GetRuntimeProperties())
            {
                if (!info.GetMethod.IsVirtual)
                {
                    BzStringAttribute columnNameAttr = GetBzStrAttr(info);
                    if (columnNameAttr != null)
                    {
                        if (!string.IsNullOrWhiteSpace(columnNameAttr.SplitStr))
                        {
                            list.Add(new Tuple<int, Tuple<string, string>>(columnNameAttr.Sort, new Tuple<string, string>(info.Name, columnNameAttr.SplitStr)));
                        }
                    }
                }
            }
            list.Sort();
            foreach (var item in list)
            {
                propertyMaps.Add(item.Item2.Item1, item.Item2.Item2);
            }
            return propertyMaps;
        }

        private static BzStringAttribute GetBzStrAttr(PropertyInfo info)
        {
            return (BzStringAttribute)info.GetCustomAttribute(typeof(BzStringAttribute));
        }
        #endregion
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class BzStringAttribute : Attribute
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string SplitStr { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }

    public class BzString<T>
    {
        public BzString(string bz)
        {
            Bz = bz;
            Type = typeof(T);
        }

        public string Bz { get; set; }

        public Type Type { get; set; }


        public override string ToString()
        {
            return Bz;
        }

    }
}
