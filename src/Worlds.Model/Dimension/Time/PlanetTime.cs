﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Dimension.Space;

namespace Worlds.Model.Dimension.Time
{
    /// <summary>
    /// 行星时间
    /// </summary>
    public class PlanetTime:Yuan
    {
        public PlanetTime()
        {

        }

        public PlanetTime(decimal revolutionNumber, decimal rotationNumber)
        {
            RevolutionNumber = revolutionNumber;
            RotationNumber = rotationNumber;
        }


        /// <summary>
        /// 公转数目
        /// </summary>
        public decimal RevolutionNumber { get; set; }

        /// <summary>
        ///自转数目
        /// </summary>
        public decimal RotationNumber { get; set; }



        public string KeyName { get { return string.Format("{0}_{1}", RevolutionNumber, RotationNumber); } }


        #region ToString
        public override string ToString()
        {
            return string.Format("公转数{0}自转数{1}", RevolutionNumber, RotationNumber);
        }
        #endregion

    }
}
