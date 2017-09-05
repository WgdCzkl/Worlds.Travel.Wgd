using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worlds.Travel.Web.Controllers.Base;
using Worlds.Travel.Web.Models.Worlds;

namespace Worlds.Travel.Web.Controllers
{
    public class WorldsController : BaseWorldController
    {
        //降临到世界
        public ActionResult ComeToWorld()
        {
            ComeToWorldViewModel vm = new ComeToWorldViewModel();

            vm.Areas = CurrPlanetWorld.Areas;
            return View(vm);
        }

        public ActionResult ComeToArea(string areaKey = "c85a085c-40e5-44dc-a16a-b1f74208ea37")
        {
            ComeToAreaViewModel vm = new ComeToAreaViewModel();
            vm.CurrArea = CurrPlanetWorld.Areas.FirstOrDefault(a => a.Key == areaKey);
            return View();
        }
    }
}