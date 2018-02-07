using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Model.Dimension.Volume
{
    public class CoordinateThree
    {
        public CoordinateThree()
        {

        }

        public CoordinateThree(CoordinateTwo x, YuanLength h)
        {
            SubCoordinate = x;
            H = h;
        }

        /// <summary>
        /// X坐标
        /// </summary>
        public YuanLength H { get; set; }

        /// <summary>
        /// 子坐标
        /// </summary>
        public CoordinateTwo SubCoordinate { get; set; }
    }
}

