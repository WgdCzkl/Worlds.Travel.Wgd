using IndividualWorlds.Service.Planets.Dto;
using PlanetWorlds.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Civilization.Areas;
using Worlds.Model.Dimension.Space;
using Worlds.Model.Dimension.SpaceTime;
using Worlds.Model.Dimension.Time;
using Worlds.Model.Macroscopic.CivilizedCreation;
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
        /// 获取开放区域
        /// </summary>
        /// <returns></returns>
        public List<YuanArea> GetOpenYuanAreas(string path)
        {
            return XmlHelper.XML2LTByFilePaht<YuanArea>(string.Format(@"{0}\Areas.xml", path));
        }

        /// <summary>
        /// 获取开放楼层
        /// </summary>
        /// <returns></returns>
        public List<YuanStorey> GetOpenYuanStoreys(string path)
        {
            return XmlHelper.XML2LTByFilePaht<YuanStorey>(string.Format(@"{0}\Storeys.xml", path));
        }

        /// <summary>
        /// 获取开放套房s
        /// </summary>
        /// <returns></returns>
        public List<YuanSuite> GetOpenYuanSuites(string path)
        {
            return XmlHelper.XML2LTByFilePaht<YuanSuite>(string.Format(@"{0}\Suites.xml", path));
        }

        /// <summary>
        /// 获取开发信息根据星球Key
        /// </summary>
        /// <param name="planetKey"></param>
        /// <returns></returns>
        public PlanetWorldOpenInfoDTO GetOpenInfoByPlanetKey(string planetKey)
        {
            PlanetWorldOpenInfoDTO openInfo = new PlanetWorldOpenInfoDTO();
            openInfo.PlanetTimes = XmlHelper.XML2LTByFilePaht<PlanetTime>(@"Earth\PlanetTimes.xml");
            return openInfo;
        }

    }
}