using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Civilization.Passport;
using Worlds.Model.Civilization.Symbolizes;

namespace Worlds.Model.Games
{
    public class UserModel : Yuan
    {
        public UserModel()
        {
            ArchivePoints = new List<ArchivePoint>();
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public YuanName Name { get; set; }

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
