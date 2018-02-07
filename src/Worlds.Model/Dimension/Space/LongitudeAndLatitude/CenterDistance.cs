using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Model.Dimension.Space.LongitudeAndLatitude
{
    /// <summary>
    /// 球心距
    /// </summary>
    public class CenterDistance : YuanUnit
    {
        public CenterDistance()
        {

        }
        public CenterDistance(decimal value) : base(value)
        {
        }

        #region 隐式转换
        /// <summary>
        /// 自定义 隐式转换
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator CenterDistance(Decimal value)
        {
            return new CenterDistance(value);
        }
        #endregion
    }
}
