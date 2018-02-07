using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Model.Dimension.Space.LongitudeAndLatitude
{
    /// <summary>
    /// 经度
    /// </summary>
    public class Longitude : YuanUnit
    {
        public Longitude()
        {

        }
        public Longitude(decimal value) : base(value)
        {
        }

        #region 隐式转换
        /// <summary>
        /// 自定义 隐式转换
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Longitude(Decimal value)
        {
            return new Longitude(value);
        }
        #endregion
    }
}