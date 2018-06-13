using IndividualWorlds.Service.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Worlds.Model.Civilization.Areas;
using Worlds.Model.Games;

namespace Worlds.Travel.Web.Infrastructures.Factorys
{
    public class ComeToModelFactory
    {
        /// <summary>
        /// 获取降临的信息
        /// </summary>
        public static ComeToModels CurrComeToModels
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
        /// 创建降临对象根据开放的星系
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ComeToModels CreateComeToModelsByOpenGalaxys(IPlanetWorldService planetWorldService)
        {
            var model = new ComeToModels().SetGalaxys(planetWorldService.GetOpenGalaxys());
            UpdateComeToModels(model);
            return model;
        }

        /// <summary>
        /// 降临到星球
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static ComeToModels ComeToGalaxy(string key)
        {
            var model = CurrComeToModels.SetCurrGalaxy(key);
            UpdateComeToModels(model);
            return model;
        }

        /// <summary>
        /// 降临到星球
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static ComeToModels ComeToPlanet(string key)
        {
            var model = CurrComeToModels.SetCurrPlanet(key);
            UpdateComeToModels(model);
            return model;
        }

        /// <summary>
        /// 降临到星球时间
        /// </summary>
        /// <param name="planetWorldService"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static ComeToModels ComeToPlanetTime(IPlanetWorldService planetWorldService,string key)
        {
            var model = CurrComeToModels.SetCurrPlanetTimeByKeyName(key);
            model.UpdateArea(planetWorldService.GetOpenYuanAreas(model.Paths));
            UpdateComeToModels(model);
            return model;
        }

        /// <summary>
        /// 降临到区域
        /// </summary>
        /// <param name="planetWorldService"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static ComeToModels ComeToArea(IPlanetWorldService planetWorldService, string key)
        {
            var model = CurrComeToModels.SetCurrArea(key);
            model.UpdateOpenAreas(planetWorldService.GetOpenYuanAreas(model.Paths));
            UpdateComeToModels(model);
            return model;
        }

        /// <summary>
        /// 降临到建筑
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static ComeToModels ComeToArchitecture(string key)
        {
            var model = CurrComeToModels.SetCurrArchitectur(key);
            UpdateComeToModels(model);
            return model;
        }

        /// <summary>
        /// 降临到区域
        /// </summary>
        /// <param name="planetWorldService"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static ComeToModels ComeToStorey(IPlanetWorldService planetWorldService, string key)
        {
            var model = CurrComeToModels.SetCurrStorey(key);
            model.UpdateOpenSuites(planetWorldService.GetOpenYuanSuites(model.Paths));
            UpdateComeToModels(model);
            return model;
        }

        /// <summary>
        /// 更新降临的信息
        /// </summary>
        /// <param name="comeToModels"></param>
        public static ComeToModels UpdateComeToModels(ComeToModels model)
        {
            SessionHelper.Add<ComeToModels>(WebConstants.SESSION_KEY_COME_TO_MODEL, model);
            return model;
        }



    }
}