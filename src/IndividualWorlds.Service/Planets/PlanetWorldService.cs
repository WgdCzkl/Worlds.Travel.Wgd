using PlanetWorlds.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Civilization.Areas;
using Worlds.Model.Dimension.SpaceTime;

namespace IndividualWorlds.Service.Planets
{
    public class PlanetWorldService : IPlanetWorldService
    {
        /// <summary>
        /// 获取星球世界
        /// </summary>
        /// <param name="planetNo"></param>
        /// <param name="planetSpaceTime"></param>
        /// <returns></returns>
        public PlanetWorld GetPlanetWorld(PlanetSpaceTime planetSpaceTime)
        {
            var areas =new List<YuanArea>();
            areas.Add(new YuanArea("杨浦区"));
            areas.Add(new YuanArea("宝山区"));
            PlanetWorld planetWorld = new PlanetWorld() {  Areas = areas };


            return planetWorld;
        }


    }
}