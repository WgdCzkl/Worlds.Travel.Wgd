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
         
            return View(vm);
        }

        public ActionResult ComeTo()
        {
            PlanetSpaceTime time = null;
            SessionHelper.Add<HumanWorld>(WebConstants.SESSION_KEY_WORLD, _humanWorldService.GetHumanWorld(CurrPassport.PassportNo, time));

            SessionHelper.Add<ComeToModels>(WebConstants.SESSION_KEY_COME_TO_MODEL, new ComeToModels().SetGalaxys(_planetWorldService.GetOpenGalaxys()));
            return RedirectToAction("ComeToGalaxy", "ComeTo");
        }
    }
}