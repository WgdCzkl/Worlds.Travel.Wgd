using IndividualWorlds.Service.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worlds.Model.Civilization.Areas;
using Worlds.Model.Civilization.DailyLife;
using Worlds.Model.Dimension.Space;
using Worlds.Model.Dimension.Time;
using Worlds.Model.Macroscopic.CivilizedCreation;
using Worlds.Trave.Repository.Common.Helper;
using Worlds.Travel.Web.Controllers.Base;
using Worlds.Travel.Web.Infrastructures;
using Worlds.Travel.Web.Models.ComeTo;

namespace Worlds.Travel.Web.Controllers
{
    public class ComeToController : BaseComeToWorldsController
    {
        public ComeToController(IPlanetWorldService planetWorldService) : base(planetWorldService)
        {
        }

        /// <summary>
        /// 降临到星系
        /// </summary>
        /// <returns></returns>
        public ActionResult ComeToGalaxy()
        {
            var area = XmlHelper.XML2LTByFilePaht<YuanArea>(@"Earth\2017.96_14.42\China\ShanghaiCity\YangpuDistrict\Areas.xml").FirstOrDefault();

            var lc = new List<YuanRoad>();
            lc.Add(new YuanRoad("政立路"));
            lc.Add(new YuanRoad("政学路"));
            lc.Add(new YuanRoad("淞沪路"));
            area.Roads = lc;
            string str = XmlHelper.T2XML<YuanArea>(area);

            ComeToGalaxyViewModel vm = new ComeToGalaxyViewModel();
            vm.Galaxys = base.OpenGalaxys;
            return View(vm);
        }

        /// <summary>
        /// 降临到星球
        /// </summary>
        /// <returns></returns>
        public ActionResult ComeToPlanet(string galaxyKey)
        {

            SessionHelper.Add<Galaxy>(WebConstants.SESSION_KEY_COME_TO_GALAXY, base.OpenGalaxys.Find(g => g.Key == galaxyKey));
            ComeToPlanetViewModel vm = new ComeToPlanetViewModel();
            vm.Planets = base.OpenPlanets;
            return View(vm);
        }

        /// <summary>
        /// 降临时间
        /// </summary>
        /// <returns></returns>
        public ActionResult ComeToPlanetTime(string planetKey)
        {
            SessionHelper.Add<Planet>(WebConstants.SESSION_KEY_COME_TO_PLANET, base.OpenPlanets.Find(g => g.Key == planetKey));
            ComeToPlanetTimeViewModel vm = new ComeToPlanetTimeViewModel();
            vm.PlanetTimes = base.OpenPlanetTimes;
            return View(vm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="planetTiemKeyName"></param>
        /// <returns></returns>
        public ActionResult SelectedPlanetTime(string planetTiemKeyName)
        {
            SessionHelper.Add<PlanetTime>(WebConstants.SESSION_KEY_COME_TO_PLANET_TIME, base.OpenPlanetTimes.Find(g => g.KeyName == planetTiemKeyName));
            SessionHelper.Add<List<YuanArea>>(WebConstants.SESSION_KEY_COME_TO_OPEN_PLANET_AREAS, GetNewOpenAreas());
            ComeToAreaViewModel vm = new ComeToAreaViewModel();
            vm.Areas = base.OpenAreas;
            return View("ComeToArea", vm);
        }

        /// <summary>
        /// 降临到区域
        /// </summary>
        /// <param name="planetTiemKeyName"></param>
        /// <returns></returns>
        public ActionResult ComeToArea(string areaKeyName)
        {
            var currArea = base.OpenAreas.Find(a => a.Name.KeyName == areaKeyName);
            if (currArea == null)
            {
                return View("SceneSelection", "Home");
            }
            base.AddSelectedAreas(currArea);

            SessionHelper.Add<YuanArea>(WebConstants.SESSION_KEY_COME_TO_PLANET_AREA, currArea);
            SessionHelper.Add<List<YuanArea>>(WebConstants.SESSION_KEY_COME_TO_OPEN_PLANET_AREAS, GetNewOpenAreas());

            ComeToAreaViewModel vm = new ComeToAreaViewModel();
            vm.CurrArea = base.CurrArea;
            vm.Areas = base.OpenAreas;

            if (vm.IsOpenArchitectures)
            {
                SessionHelper.Add<List<YuanArchitecture>>(WebConstants.SESSION_KEY_COME_TO_OPEN_AREA_ARCHITECTURE, vm.Architectures);
            }

            if (vm.IsOpenRoads)
            {
                SessionHelper.Add<List<YuanRoad>>(WebConstants.SESSION_KEY_COME_TO_OPEN_PLANET_ROADS, vm.Roads);
            }
            return View(vm);

        }

        /// <summary>
        /// 降临到建筑
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public ActionResult ComeToArchitecture(string keyName)
        {

            ComeToArchitectureViewModel vm = new ComeToArchitectureViewModel();
            vm.CurrArchitecture = base.OpenArchitectures.Find(a => a.Name.KeyName == keyName);
            SessionHelper.Add<List<YuanStorey>>(WebConstants.SESSION_KEY_COME_TO_OPEN_PLANET_STOREYS, vm.Storeys);
            return View(vm);
        }

        /// <summary>
        /// 降临到楼层
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public ActionResult ComeToStorey(string keyName)
        {
            ComeToStoreyViewModel vm = new ComeToStoreyViewModel();
            vm.CurrStorey = base.OpenStoreys.Find(a => a.Name.KeyName == keyName);
            return View(vm);
        }

        /// <summary>
        /// 降临到路
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public ActionResult ComeToRoad(string keyName)
        {
            ComeToRoadViewModel vm = new ComeToRoadViewModel();
            vm.CurrRoad = base.OpenRoads.Find(a => a.Name.KeyName == keyName);
            return View(vm);
        }

        /// <summary>
        /// 降临到世界
        /// </summary>
        /// <param name="planetKey"></param>
        /// <returns></returns>
        public ActionResult ComeToWorld(string planetKey)
        {
            ComeToWorldViewModel vm = new ComeToWorldViewModel();
            vm.CurrArea = base.CurrArea;
            return View(vm);
        }

    }
}