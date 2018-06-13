using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worlds.Model.Civilization.Passport;
using Worlds.Model.Games;
using Worlds.Travel.AccountService;
using Worlds.Travel.Web.Infrastructures;
using Worlds.Travel.Web.Models.Account;

namespace Worlds.Travel.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: Account
        public ActionResult Login()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = _accountService.GetUserModel("9e4c4678-fc02-4ed4-b64d-92f1826d0186", model.Password);
                if (loginResult.IsSuccess)
                {
                    SessionHelper.Add<UserModel>(WebConstants.SESSION_KEY_USER, loginResult.Data);
                    return RedirectToAction("SceneSelection", "Home");
                }
                else
                {
                    ModelState.AddModelError("", loginResult.ResultMsg);
                }
            }

            // 如果执行到这里，发生某项失败，则重新显示窗体
            return View(model);
        }


        
    }
}