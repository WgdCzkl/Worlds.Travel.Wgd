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

namespace Worlds.Travel.Web.Controllers.Base
{
    public class BaseComeToWorldsController : BaseController
    {
        private readonly IPlanetWorldService _planetWorldService;

        public BaseComeToWorldsController(IPlanetWorldService planetWorldService
            )
        {
            _planetWorldService = planetWorldService;
        }

        /// <summary>
        /// 获取降临的信息
        /// </summary>
        public ComeToModels ComeToModels
        {
            get
            {
                var model = SessionHelper.Get<ComeToModels>(WebConstants.SESSION_KEY_COME_TO_MODEL);
                if (model == null)
                {
                    model = new ComeToModels();
                }
                return model;
            }
        }

        /// <summary>
        /// 更新降临的信息
        /// </summary>
        /// <param name="comeToModels"></param>
        public ComeToModels UpdateComeToModels(ComeToModels comeToModels)
        {
            SessionHelper.Add<ComeToModels>(WebConstants.SESSION_KEY_COME_TO_MODEL, comeToModels);
            return comeToModels;
        }


        public List<YuanArea> GetNewOpenAreas(string path)
        {
            return _planetWorldService.GetOpenYuanAreas(path);
        }

    }
}