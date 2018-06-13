using IndividualWorlds.Model;
using IndividualWorlds.Service.Humans;
using IndividualWorlds.Service.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worlds.Model.Dimension.Space;
using Worlds.Model.Dimension.SpaceTime;
using Worlds.Model.Games;
using Worlds.Travel.Web.Controllers.Base;
using Worlds.Travel.Web.Infrastructures;
using Worlds.Travel.Web.Infrastructures.Factorys;
using Worlds.Travel.Web.Models.Home;

namespace Worlds.Travel.Web.Controllers
{
    public class HomeController : BaseController
    {

        private readonly IHumanWorldService _humanWorldService;
        private readonly IPlanetWorldService _planetWorldService;
        public HomeController(
            IHumanWorldService humanWorldService
            , IPlanetWorldService planetWorldService
            )
        {
            _humanWorldService = humanWorldService;
            _planetWorldService = planetWorldService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SceneSelection()
        {
            SceneSelectionViewModel vm = new SceneSelectionViewModel();
            vm.ArchivePoints = CurrUser.ArchivePoints;
            return View(vm);
        }

        #region 存档点读取
        // GET: Account
        public ActionResult SelectArchivePoint()
        {
            return View();
        }

        #endregion

        /// <summary>
        /// 降临
        /// </summary>
        /// <returns></returns>
        public ActionResult ComeTo()
        {
            PlanetSpaceTime time = null;
            SessionHelper.Add<HumanWorld>(WebConstants.SESSION_KEY_WORLD, _humanWorldService.GetHumanWorld(CurrPassport.PassportNo, time));

            ComeToModelFactory.CreateComeToModelsByOpenGalaxys(_planetWorldService);
            return RedirectToAction("ComeToGalaxy", "ComeTo");
        }
    }
}