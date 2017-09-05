using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worlds.Model.Civilization.Passport;
using Worlds.Travel.Web.Infrastructures;

namespace Worlds.Travel.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        public CosmicPassport CurrPassport
        {
            get
            {
                var passrort = SessionHelper.Get<CosmicPassport>(WebConstants.SESSION_KEY_COSMIC_PASSPORT);
                if (passrort == null)
                {
                    passrort = new CosmicPassport();
                }
                return passrort;
            }
        }
    }
}