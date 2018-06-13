using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Model.Dimension.Volume
{
    /// <summary>
    /// 元长度
    /// </summary>
    public class YuanLength : YuanUnit
    {
        public YuanLength()
        {

        }

        public YuanLength(decimal value) : base(value)
        {
        }

        /// <summary>
        /// 自定义 隐式转换
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator YuanLength(Decimal value)
        {
            return new YuanLength(value);
        }
    }
}
