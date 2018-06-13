using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Civilization.Passport;
using Worlds.Model.Games;
using Worlds.Travel.Infrastructure.ServiceProxy;

namespace Worlds.Travel.AccountService
{
    public interface IAccountService
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="idNumber">ID</param>
        /// <param name="passWorld">密码</param>
        /// <returns></returns>
        Response<UserModel> GetUserModel(string idNumber, string passWorld);

        Response<CosmicPassport> GetCosmicPassport(string idNumber, string passWorld);

        Response<CosmicPassport> GetCosmicPassportByUserName(string userName, string passWorld);
    }
}
