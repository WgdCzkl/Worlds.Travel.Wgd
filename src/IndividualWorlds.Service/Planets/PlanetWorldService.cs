using PlanetWorlds.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Civilization.Areas;
using Worlds.Model.Civilization.Symbolizes;
using Worlds.Model.Dimension.SpaceTime;
using Worlds.Trave.Repository.Common.Helper;

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
         
            var areas = XmlHelper.XML2LTByFilePaht<YuanArea>(@"Earth\China\Shanghai\Areas.xml");
            string xml = XmlHelper.LT2XML<YuanArea>(areas);
            PlanetWorld planetWorld = new PlanetWorld() { Areas = areas };


            return planetWorld;
        }


    }
}