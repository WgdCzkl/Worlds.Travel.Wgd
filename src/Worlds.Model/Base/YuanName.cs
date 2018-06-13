using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Model
{
    /// <summary>
    /// 标志-名称
    /// </summary>
    public class YuanName 
    {
        public YuanName()
        {

        }
        public YuanName(string name)
        {
            Name = name;
            KeyName = name;
        }

        public YuanName(string name,string keyName)
        {
            Name = name;
            KeyName = keyName;
        }

        public string KeyName { get; set; }

        /// <summary>
        /// 全称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public string SimpleName { get; set; }

        /// <summary>
        ///名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 别称
        /// </summary>
        public List<string> NickNames { get; set; }

        /// <summary>
        /// 曾用名
        /// </summary>
        public List<string> UsedNames { get; set; }


        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// 自定义 隐式转换
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator YuanName(string value)
        {
            return new YuanName(value);
        }
    }
}
