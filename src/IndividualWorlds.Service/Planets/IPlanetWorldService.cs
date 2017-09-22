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

namespace IndividualWorlds.Service.Planets
{
    public interface IPlanetWorldService
    {
        PlanetWorld GetPlanetWorld(PlanetSpaceTime planetSpaceTime);

        List<Galaxy> GetOpenGalaxys();

        List<PlanetTime> GetOpenPlanetTimes(string planetKey);

        List<YuanArea> GetOpenYuanAreas(string path);

        PlanetWorldOpenInfoDTO GetOpenInfoByPlanetKey(string planetKey);
    }
}
