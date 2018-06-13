using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Civilization.Shapes;


namespace Worlds.Model.Macroscopic.CivilizedCreation
{

    /// <summary>
    /// 文明造物
    /// </summary>
    public class YuanCivilizedCreation : Yuan
    {
        public YuanCivilizedCreation()
        {

        }

        public YuanCivilizedCreation(YuanName name)
        {
            Name = name;
        }
        public YuanCivilizedCreation(YuanName name, YuanShape shape)
        {
            Name = name;

        }


        public string KeyName
        {
            get
            {
                return Name.KeyName;
            }
        }

        /// <summary>
        /// 外形
        /// </summary>
        public YuanShape Shape { get; set; }


        /// <summary>
        /// 子造物
        /// </summary>
        public List<YuanCivilizedCreation> SubCivilizedCreations { get; set; }


        public void InitSubCivilizedCreations(List<YuanCivilizedCreation> civilizedCreations)
        {
            this.SubCivilizedCreations = civilizedCreations;
        }
    }
}
