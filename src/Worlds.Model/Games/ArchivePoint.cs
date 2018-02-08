using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Civilization.Symbolizes;

namespace Worlds.Model.Games
{
    /// <summary>
    /// 存档点
    /// </summary>
    public class ArchivePoint : Yuan
    {
        public ArchivePoint()
        {
            ComeToInfo = new ComeToModels();
        }

        /// <summary>
        /// 名称
        /// </summary>
        public YuanName Name { get; set; }

        /// <summary>
        /// 降临信息
        /// </summary>
        public ComeToModels ComeToInfo { get; set; }
    }
}
