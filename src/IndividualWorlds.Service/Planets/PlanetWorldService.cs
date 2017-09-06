using IndividualWorlds.Service.Planets.Dto;
using PlanetWorlds.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Civilization.Areas;
using Worlds.Model.Civilization.Symbolizes;
using Worlds.Model.Dimension.Space;
using Worlds.Model.Dimension.SpaceTime;
using Worlds.Model.Dimension.Time;
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
            List<PlanetTime> list = new List<PlanetTime>();
            list.Add(new PlanetTime(2017.96M, 14.42M));
            var xml = XmlHelper.LT2XML<PlanetTime>(list);


       
            PlanetWorld planetWorld = new PlanetWorld();
            return planetWorld;
        }


        /// <summary>
        /// 获取开放星系列表
        /// </summary>
        /// <returns></returns>
        public List<Galaxy> GetOpenGalaxys()
        {
            return XmlHelper.XML2LTByFilePaht<Galaxy>(@"Galaxys\SolarSystem.xml");
        }

        /// <summary>
        /// 获取开放时间列表
        /// </summary>
        /// <returns></returns>
        public List<PlanetTime> GetOpenPlanetTimes(string planetKey)
        {
            return XmlHelper.XML2LTByFilePaht<PlanetTime>(@"Earth\PlanetTimes.xml");
        }

        /// <summary>
        /// 获取开发区域
        /// </summary>
        /// <param name="planetKeyName">星球KeyName</param>
        /// <param name="planetTimeKeyName">星期时间KeyName</param>
        /// <returns></returns>
        public List<YuanArea> GetOpenYuanAreas(string planetKeyName, string planetTimeKeyName)
        {

            return XmlHelper.XML2LTByFilePaht<YuanArea>(string.Format(@"{0}\{1}\Areas.xml", planetKeyName, planetTimeKeyName));
        }



        public PlanetWorldOpenInfoDTO GetOpenInfoByPlanetKey(string planetKey)
        {
            PlanetWorldOpenInfoDTO openInfo = new PlanetWorldOpenInfoDTO();
            openInfo.PlanetTimes = XmlHelper.XML2LTByFilePaht<PlanetTime>(@"Earth\PlanetTimes.xml");
            return openInfo;
        }

    }
}