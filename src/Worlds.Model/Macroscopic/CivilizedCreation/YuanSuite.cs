using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Civilization.Symbolizes;

namespace Worlds.Model.Macroscopic.CivilizedCreation
{
    /// <summary>
    /// 套房
    /// </summary>
    public class YuanSuite : YuanCivilizedCreation
    {
        public YuanSuite()
        {

        }
        public YuanSuite(YuanName name) : base(name)
        {

        }

        public List<YuanRoom> Rooms { get; set; }
    }
}
