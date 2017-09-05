using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Model
{
    public class Yuan
    {
        public Yuan()
        {
            ID = Guid.NewGuid();
        }
        /// <summary>
        /// ID 唯一标识
        /// </summary>
        public Guid ID { get; set; }


        public string Key
        {
            get
            {
                if (ID == Guid.Empty)
                {
                    return "";
                }
                return ID.ToString();
            }
        }

        /// <summary>
        /// 可见等级
        /// </summary>
        private Decimal VisibleGrade { get; set; }

        /// <summary>
        /// 可见等级范围
        /// </summary>
        private int VisibleGradeRange { get; set; }


        /// <summary>
        /// /重新加载
        /// </summary>
        /// <param name="visibleGradeRange"></param>
        public void Reload(int visibleGradeRange)
        {

        }
    }
}
