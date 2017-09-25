using IndividualWorlds.Service.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worlds.Model.Civilization.Areas;
using Worlds.Model.Dimension.Space;
using Worlds.Model.Dimension.Time;
using Worlds.Model.Macroscopic.CivilizedCreation;
using Worlds.Travel.Web.Infrastructures;

namespace Worlds.Travel.Web.Controllers.Base
{
    public class BaseComeToWorldsController : BaseController
    {
        private readonly IPlanetWorldService _planetWorldService;

        public BaseComeToWorldsController(IPlanetWorldService planetWorldService
            )
        {
            _planetWorldService = planetWorldService;
        }

        public List<Galaxy> OpenGalaxys
        {
            get
            {
                return _planetWorldService.GetOpenGalaxys();
            }
        }

        public Galaxy CurrGalaxy
        {
            get
            {
                return SessionHelper.Get<Galaxy>(WebConstants.SESSION_KEY_COME_TO_GALAXY);
            }
        }

        public List<Planet> OpenPlanets
        {
            get
            {
                return CurrGalaxy.SurroundPlanets;
            }
        }

        public Planet CurrPlanet
        {
            get
            {
                return SessionHelper.Get<Planet>(WebConstants.SESSION_KEY_COME_TO_PLANET);
            }
        }

        public List<PlanetTime> OpenPlanetTimes
        {
            get
            {
                return _planetWorldService.GetOpenPlanetTimes(CurrPlanet.Key);
            }
        }

        public PlanetTime CurrPlanetTime
        {
            get
            {
                return SessionHelper.Get<PlanetTime>(WebConstants.SESSION_KEY_COME_TO_PLANET_TIME);
            }
        }

        public List<YuanArea> OpenAreas
        {
            get
            {
                return SessionHelper.Get<List<YuanArea>>(WebConstants.SESSION_KEY_COME_TO_OPEN_PLANET_AREAS);
            }
        }

        public List<YuanArea> SelectedAreas
        {
            get
            {
                var list = SessionHelper.Get<List<YuanArea>>(WebConstants.SESSION_KEY_COME_TO_SELECTED_PLANET_AREAS);
                return list == null ? new List<YuanArea>() : list;
            }
        }

        public YuanArea CurrArea
        {
            get
            {
                return SessionHelper.Get<YuanArea>(WebConstants.SESSION_KEY_COME_TO_PLANET_AREA);
            }
        }

        public YuanArchitecture CurrArchitecture
        {
            get
            {
                return SessionHelper.Get<YuanArchitecture>(WebConstants.SESSION_KEY_COME_TO_AREA_ARCHITECTURE);
            }
        }

        public List<YuanArchitecture> OpenArchitectures
        {
            get
            {
                return SessionHelper.Get<List<YuanArchitecture>>(WebConstants.SESSION_KEY_COME_TO_OPEN_AREA_ARCHITECTURE);
            }
        }

        public YuanStorey CurrStorey
        {
            get
            {
                return SessionHelper.Get<YuanStorey>(WebConstants.SESSION_KEY_COME_TO_PLANET_STOREY);
            }
        }

        public List<YuanStorey> OpenStoreys
        {
            get
            {
                return SessionHelper.Get<List<YuanStorey>>(WebConstants.SESSION_KEY_COME_TO_OPEN_PLANET_STOREYS);
            }
        }

        public YuanRoad  CurrRoad
        {
            get
            {
                return SessionHelper.Get<YuanRoad>(WebConstants.SESSION_KEY_COME_TO_PLANET_ROAD);
            }
        }

        public List<YuanRoad> OpenRoads
        {
            get
            {
                return SessionHelper.Get<List<YuanRoad>>(WebConstants.SESSION_KEY_COME_TO_OPEN_PLANET_ROADS);
            }
        }

        public void AddSelectedAreas(YuanArea area)
        {
            var list = SelectedAreas;
            list.Add(area);
            SessionHelper.Add<List<YuanArea>>(WebConstants.SESSION_KEY_COME_TO_SELECTED_PLANET_AREAS, list);
        }

        public List<YuanArea> GetNewOpenAreas()
        {
            string path = string.Format(@"{0}\{1}", CurrPlanet.Name.KeyName, CurrPlanetTime.KeyName);
            foreach (var item in SelectedAreas)
            {
                path = string.Format(@"{0}\{1}", path, item.Name.KeyName);
            }
            return _planetWorldService.GetOpenYuanAreas(path);
        }



    }
}