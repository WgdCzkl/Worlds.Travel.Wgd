﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Civilization.Passport;
using Worlds.Travel.Infrastructure.ServiceProxy;

namespace Worlds.Travel.AccountService
{
    public class AccountService : IAccountService
    {
        public Response<CosmicPassport> GetCosmicPassport(string idNumber, string passWorld)
        {
            Response<CosmicPassport> passport = new Response<CosmicPassport>(true, new CosmicPassport() { PassportNo = "4127251992" });
            return passport;
        }

        public Response<CosmicPassport> GetCosmicPassportByUserName(string userName, string passWorld)
        {
            throw new NotImplementedException();
        }


    }
}
