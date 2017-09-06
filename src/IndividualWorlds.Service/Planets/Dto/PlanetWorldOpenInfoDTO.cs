using System.Collections.Generic;
using Worlds.Model.Civilization.Areas;
using Worlds.Model.Dimension.Time;

namespace IndividualWorlds.Service.Planets.Dto
{
    public class PlanetWorldOpenInfoDTO
    {

        public List<PlanetTime> PlanetTimes { get; set; }

        public List<YuanArea> Areas { get; set; }
    }
}
