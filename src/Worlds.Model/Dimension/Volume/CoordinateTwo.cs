using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Model.Dimension.Volume
{
    /// <summary>
    /// 二维坐标
    /// </summary>
    [BzString(SplitStr = "EWZB")]
    public class CoordinateTwo
    {
        public CoordinateTwo()
        {

        }

        public CoordinateTwo(YuanLength x, YuanLength y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X坐标
        /// </summary>
        [BzString(SplitStr = "X", Sort = 1)]
        public YuanLength X { get; set; }

        /// <summary>
        /// Y坐标
        /// </summary>
        [BzString(SplitStr = "Y", Sort = 2)]
        public YuanLength Y { get; set; }
    }
}

