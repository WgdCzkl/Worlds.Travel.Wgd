using IndividualWorlds.Service.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worlds.Model;
using Worlds.Model.Civilization.Areas;
using Worlds.Model.Civilization.DailyLife;
using Worlds.Model.Dimension.Space;
using Worlds.Model.Dimension.Time;
using Worlds.Model.Dimension.Volume;
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

            CoordinateTwo two = new CoordinateTwo(1M, 2M);
            var s = BzStringExtensions<CoordinateTwo>.GetBzString(two);

            YuanRoom room = new YuanRoom("702");
            var list = new List<YuanCivilizedCreation>();
            list.Add(new YuanCivilizedCreation("床"));
            list.Add(new YuanCivilizedCreation("柜子"));
            list.Add(new YuanCivilizedCreation("椅子"));
            list.Add(new YuanCivilizedCreation("电脑"));
            room.InitSubCivilizedCreations(list);
            string str = XmlHelper.T2XML<YuanRoom>(room);

            ComeToGalaxyViewModel vm = new ComeToGalaxyViewModel();
            vm.Galaxys = base.ComeToModels.Galaxy.Opens;

            return View(vm);
        }

        /// <summary>
        /// 降临到星球
        /// </summary>
        /// <returns></returns>
        public ActionResult ComeToPlanet(string galaxyKey)
        {
            base.UpdateComeToModels(ComeToModels.SetCurrGalaxy(galaxyKey));
            ComeToPlanetViewModel vm = new ComeToPlanetViewModel();
            vm.Planets = base.ComeToModels.Planet.Opens;
            return View(vm);
        }

        /// <summary>
        /// 降临时间
        /// </summary>
        /// <returns></returns>
        public ActionResult ComeToPlanetTime(string planetKey)
        {
            base.UpdateComeToModels(ComeToModels.SetCurrPlanet(planetKey));
            ComeToPlanetTimeViewModel vm = new ComeToPlanetTimeViewModel();
            vm.PlanetTimes = base.ComeToModels.PlanetTime.Opens;
            return View(vm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="planetTiemKeyName"></param>
        /// <returns></returns>
        public ActionResult SelectedPlanetTime(string planetTiemKeyName)
        {
            base.UpdateComeToModels(ComeToModels.SetCurrPlanetTimeByKeyName(planetTiemKeyName));
            base.UpdateComeToModels(ComeToModels.UpdateArea(GetNewOpenAreas(ComeToModels.AreaPaths)));

            ComeToAreaViewModel vm = new ComeToAreaViewModel();
            vm.Areas = base.ComeToModels.Area.Opens;
            return View("ComeToArea", vm);
        }

        /// <summary>
        /// 降临到区域
        /// </summary>
        /// <param name="planetTiemKeyName"></param>
        /// <returns></returns>
        public ActionResult ComeToArea(string areaKeyName)
        {
            base.UpdateComeToModels(ComeToModels.SetCurrArea(areaKeyName));
            base.UpdateComeToModels(ComeToModels.UpdateOpenAreas(GetNewOpenAreas(ComeToModels.AreaPaths)));

            if (ComeToModels.Area.Curr == null)
            {
                return View("SceneSelection", "Home");
            }

            ComeToAreaViewModel vm = new ComeToAreaViewModel();
            vm.CurrArea = base.ComeToModels.Area.Curr;
            vm.Areas = base.ComeToModels.Area.Opens;


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
            vm.CurrArchitecture = base.ComeToModels.Architectur.Opens.Find(a => a.Name.KeyName == keyName);
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
            vm.CurrStorey = base.ComeToModels.Storey.Opens.Find(a => a.Name.KeyName == keyName);
            return View(vm);
        }

        /// <summary>
        /// 降临到套房
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public ActionResult ComeToSuite(string keyName)
        {
            ComeToSuiteViewModel vm = new ComeToSuiteViewModel();
            vm.CurrSuite = base.ComeToModels.Suite.Opens.Find(a => a.Name.KeyName == keyName);
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
            vm.CurrRoad = base.ComeToModels.Road.Opens.Find(a => a.Name.KeyName == keyName);
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
            vm.CurrArea = base.ComeToModels.Area.Curr;
            return View(vm);
        }

    }
}