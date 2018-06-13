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
using Worlds.Model.Games;
using Worlds.Model.Macroscopic.CivilizedCreation;
using Worlds.Trave.Repository.Common.Helper;
using Worlds.Travel.Web.Controllers.Base;
using Worlds.Travel.Web.Infrastructures;
using Worlds.Travel.Web.Infrastructures.Factorys;
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
            List<UserModel> users = new List<UserModel>();
            var user = new UserModel() { Name = "盘古" };
            user.ArchivePoints.Add(new ArchivePoint() { ComeToInfo = CurrComeToModels });
            users.Add(user);
            string str = XmlHelper.LT2XML<UserModel>(users);

            ComeToGalaxyViewModel vm = new ComeToGalaxyViewModel();
            vm.Galaxys = CurrComeToModels.Galaxy.Opens;

            return View(vm);
        }

        /// <summary>
        /// 降临到星球
        /// </summary>
        /// <returns></returns>
        public ActionResult ComeToPlanet(string galaxyKey)
        {
            ComeToModelFactory.ComeToGalaxy(galaxyKey);
            ComeToPlanetViewModel vm = new ComeToPlanetViewModel();
            vm.Planets = CurrComeToModels.Planet.Opens;
            return View(vm);
        }

        /// <summary>
        /// 降临时间
        /// </summary>
        /// <returns></returns>
        public ActionResult ComeToPlanetTime(string planetKey)
        {
            ComeToModelFactory.ComeToPlanet(planetKey);
            ComeToPlanetTimeViewModel vm = new ComeToPlanetTimeViewModel();
            vm.PlanetTimes = base.CurrComeToModels.PlanetTime.Opens;
            return View(vm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="planetTiemKeyName"></param>
        /// <returns></returns>
        public ActionResult SelectedPlanetTime(string planetTiemKeyName)
        {
            ComeToModelFactory.ComeToPlanetTime(_planetWorldService, planetTiemKeyName);
            ComeToAreaViewModel vm = new ComeToAreaViewModel();
            vm.Areas = CurrComeToModels.Area.Opens;
            return View("ComeToArea", vm);
        }

        /// <summary>
        /// 降临到区域
        /// </summary>
        /// <param name="planetTiemKeyName"></param>
        /// <returns></returns>
        public ActionResult ComeToArea(string areaKeyName)
        {
            ComeToModelFactory.ComeToArea(_planetWorldService, areaKeyName);
            if (CurrComeToModels.Area.Curr == null)
            {
                return View("SceneSelection", "Home");
            }

            ComeToAreaViewModel vm = new ComeToAreaViewModel();
            vm.CurrArea = CurrComeToModels.Area.Curr;
            vm.Areas = CurrComeToModels.Area.Opens;


            return View(vm);

        }

        /// <summary>
        /// 降临到建筑
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public ActionResult ComeToArchitecture(string keyName)
        {
            ComeToModelFactory.ComeToArchitecture(keyName);
            ComeToArchitectureViewModel vm = new ComeToArchitectureViewModel();
            vm.CurrArchitecture = CurrComeToModels.Architectur.Curr;
            return View(vm);
        }

        /// <summary>
        /// 降临到楼层
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public ActionResult ComeToStorey(string keyName)
        {
            ComeToModelFactory.ComeToStorey(_planetWorldService, keyName);
            ComeToStoreyViewModel vm = new ComeToStoreyViewModel();
            vm.CurrStorey = base.CurrComeToModels.Storey.Curr;
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
            vm.CurrSuite = base.CurrComeToModels.Suite.Opens.Find(a => a.Name.KeyName == keyName);
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
            vm.CurrRoad = base.CurrComeToModels.Road.Opens.Find(a => a.Name.KeyName == keyName);
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
            vm.CurrArea = base.CurrComeToModels.Area.Curr;
            return View(vm);
        }

    }
}