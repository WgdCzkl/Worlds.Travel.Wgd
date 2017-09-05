using IndividualWorlds.Model;
using PlanetWorlds.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worlds.Travel.Web.Infrastructures;

namespace Worlds.Travel.Web.Controllers.Base
{
    public class BaseWorldController : BaseController
    {
        public HumanWorld CurrWorld
        {
            get
            {
                return SessionHelper.Get<HumanWorld>(WebConstants.SESSION_KEY_WORLD);
            }
        }


        public PlanetWorld CurrPlanetWorld
        {
            get
            {
                return CurrWorld.OutsideWorld;
            }
        }
    }
}