using IndividualWorlds.Model;
using IndividualWorlds.Service.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Dimension.SpaceTime;

namespace IndividualWorlds.Service.Humans
{
    public class HumanWorldService : IHumanWorldService
    {
        private readonly IPlanetWorldService _planetWorldService;
        public HumanWorldService(IPlanetWorldService planetWorldService)
        {
            _planetWorldService = planetWorldService;
        }

        public HumanWorld GetHumanWorld(string PassportNo, PlanetSpaceTime planetSpaceTime)
        {
            HumanWorld world = new HumanWorld();

            world.OutsideWorld = _planetWorldService.GetPlanetWorld(planetSpaceTime);


            return world;
        }
    }
}
