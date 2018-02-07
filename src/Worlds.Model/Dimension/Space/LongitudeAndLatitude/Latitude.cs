using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Model.Dimension.Space.LongitudeAndLatitude
{
    /// <summary>
    /// 纬度
    /// </summary>
    public class Latitude : YuanUnit
    {
        public Latitude()
        {

        }

        public Latitude(decimal value) : base(value)
        {
        }

        #region 隐式转换
        /// <summary>
        /// 自定义 隐式转换
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Latitude(Decimal value)
        {
            return new Latitude(value);
        }
        #endregion
    }
}
