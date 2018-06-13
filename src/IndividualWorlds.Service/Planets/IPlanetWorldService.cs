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

namespace IndividualWorlds.Service.Planets
{
    public interface IPlanetWorldService
    {
        /// <summary>
        /// 获取星球世界
        /// </summary>
        /// <param name="planetSpaceTime"></param>
        /// <returns></returns>
        PlanetWorld GetPlanetWorld(PlanetSpaceTime planetSpaceTime);

        /// <summary>
        /// 获取开放星系
        /// </summary>
        /// <returns></returns>
        List<Galaxy> GetOpenGalaxys();

        /// <summary>
        /// 获取开放时间
        /// </summary>
        /// <param name="planetKey"></param>
        /// <returns></returns>
        List<PlanetTime> GetOpenPlanetTimes(string planetKey);

        /// <summary>
        /// 获取开放区域
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        List<YuanArea> GetOpenYuanAreas(string path);

        /// <summary>
        /// 获取开放楼层
        /// </summary>
        /// <returns></returns>
        List<YuanStorey> GetOpenYuanStoreys(string path);

        /// <summary>
        /// 获取开放套房
        /// </summary>
        /// <returns></returns>
        List<YuanSuite> GetOpenYuanSuites(string path);

        /// <summary>
        /// 获取开发信息根据星球Key
        /// </summary>
        /// <param name="planetKey"></param>
        /// <returns></returns>
        PlanetWorldOpenInfoDTO GetOpenInfoByPlanetKey(string planetKey);
    }
}
