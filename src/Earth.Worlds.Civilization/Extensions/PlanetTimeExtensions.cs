using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Dimension.Time;

namespace Earth.Worlds.Civilization.Extensions
{
    /// <summary>
    /// 地球 时间 扩展
    /// </summary>
    public static class PlanetTimeExtensions
    {

        public static string ToEarthTime(this PlanetTime pt)
        {
          
            int year = (int)Math.Floor(pt.RevolutionNumber);
            return string.Format("公元{0}年",year);
        }
    }
}
