using IndividualWorlds.Service.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worlds.Model.Civilization.Areas;
using Worlds.Model.Dimension.Space;
using Worlds.Model.Dimension.Time;
using Worlds.Model.Games;
using Worlds.Model.Macroscopic.CivilizedCreation;
using Worlds.Travel.Web.Infrastructures;
using Worlds.Travel.Web.Infrastructures.Factorys;

namespace Worlds.Travel.Web.Controllers.Base
{
    public class BaseComeToWorldsController : BaseController
    {
        protected readonly IPlanetWorldService _planetWorldService;

        public BaseComeToWorldsController(IPlanetWorldService planetWorldService
            )
        {
            _planetWorldService = planetWorldService;
        }

        /// <summary>
        /// 获取降临的信息
        /// </summary>
        public ComeToModels CurrComeToModels
        {
            get
            {
                return ComeToModelFactory.CurrComeToModels;
            }
        }

    }
}