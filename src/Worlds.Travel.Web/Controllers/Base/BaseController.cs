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
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            var request = filterContext.HttpContext.Request;
            try
            {
       
                if (request.IsDataTableJsRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 200;
                    filterContext.Result = Json(new
                    {
                        draw = request["draw"],
                        recordsTotal = 0,
                        recordsFiltered = 0,
                        data = "",
                        error = filterContext.Exception.Message
                    });
                }
                else if (request.IsAjaxRequest() || request.IsFileUploadRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 200;
                    filterContext.Result = ToJson(false, filterContext.Exception.Message);
                }
                else
                {
                    filterContext.HttpContext.Response.StatusCode = 200;
                    filterContext.Result = new ContentResult() { Content = filterContext.Exception.Message };
                }
                filterContext.ExceptionHandled = true;
            }
            catch (Exception)
            {

            }

        }

        /// <summary>
        /// 返回json对象
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected JsonResult ToJson(bool success, string message = null)
        {
            return Json(new { success = (success ? 1 : 0), message = (success ? (string.IsNullOrWhiteSpace(message) ? "成功" : message) : (string.IsNullOrWhiteSpace(message) ? "失败" : message)) });
        }

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

    public static class RequestExtensions
    {
        public static bool IsJsonRequest(this HttpRequestBase request)
        {
            //return string.Equals(request["format"], "json");
            return true;
        }

        public static bool IsDataTableJsRequest(this HttpRequestBase request)
        {
            return string.Equals(request["format"], "datatablejs");
        }

        public static bool IsFileUploadRequest(this HttpRequestBase request)
        {
            return request.Files != null && request.Files.Count > 0;
        }
    }
}