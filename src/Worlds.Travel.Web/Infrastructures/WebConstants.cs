using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Worlds.Travel.Web.Infrastructures
{
    public class WebConstants
    {

        #region Session

        #region Come To
        /// <summary>
        /// 降临的星系
        /// </summary>
        public const string SESSION_KEY_COME_TO_GALAXY = "ComeToGalaxy";

        /// <summary>
        /// 降临的星球
        /// </summary>
        public const string SESSION_KEY_COME_TO_PLANET = "ComeToPlanet";

        /// <summary>
        /// 降临的时间
        /// </summary>
        public const string SESSION_KEY_COME_TO_PLANET_TIME = "ComeToPlanetTime";

        /// <summary>
        /// 降临的区域
        /// </summary>
        public const string SESSION_KEY_COME_TO_PLANET_AREA = "ComeToPlanetArea";

        /// <summary>
        /// 降临的 开放区域列表
        /// </summary>
        public const string SESSION_KEY_COME_TO_OPEN_PLANET_AREAS = "ComeToOpenAreas";
        #endregion

        /// <summary>
        /// 护照信息
        /// </summary>
        public const string SESSION_KEY_COSMIC_PASSPORT = "CosmicPassport";

        /// <summary>
        /// 世界信息
        /// </summary>
        public const string SESSION_KEY_WORLD = "Wrold";



        /// <summary>
        /// 用户信息
        /// </summary>
        public const string SESSION_KEY_USER = "User";

        /// <summary>
        /// 验证错误信息
        /// </summary>
        public const string SESSION_KEY_ERRMSG = "ErrMsg";

        #endregion

        #region Account

        /// <summary>
        /// 登录控制器
        /// </summary>
        public const string CONTROLLER_ACCOUNT = "Account";

        /// <summary>
        /// 登录Action
        /// </summary>
        public const string ACT_ACCOUNT_LOGIN = "Login";

        /// <summary>
        /// 无权限访问页面
        /// </summary>
        public const string ACT_ACCOUNT_NONEACCESS = "NoneAcess";

        #endregion


    }
}