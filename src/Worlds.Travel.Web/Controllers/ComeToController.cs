using IndividualWorlds.Service.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worlds.Model.Civilization.Areas;
using Worlds.Model.Dimension.Space;
using Worlds.Model.Dimension.Time;
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

            if (base.OpenAreas.Count > 0)
            {
                ComeToAreaViewModel vm = new ComeToAreaViewModel();
                vm.Areas = base.OpenAreas;
                return View(vm);
            }
            else
            {
                ComeToWorldViewModel vm = new ComeToWorldViewModel();
                vm.CurrArea = base.CurrArea;
                return View("ComeToWorld", vm);
            }

        }



        //降临到世界
        public ActionResult ComeToWorld(string planetKey)
        {
            ComeToWorldViewModel vm = new ComeToWorldViewModel();


            return View(vm);
        }









    }
}