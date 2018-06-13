using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Civilization.Passport;


namespace Worlds.Model.Games
{
    public class UserModel : Yuan
    {
        public UserModel()
        {
            ArchivePoints = new List<ArchivePoint>();
        }


        /// <summary>
        /// 护照
        /// </summary>
        public CosmicPassport CosmicPassport { get; set; }

        /// <summary>
        /// 存档点
        /// </summary>
        public List<ArchivePoint> ArchivePoints { get; set; }

    }
}
