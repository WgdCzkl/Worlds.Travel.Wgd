using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Worlds.Model.Macroscopic.CivilizedCreation;

namespace Worlds.Travel.Web.Models.ComeTo
{
    public class ComeToStoreyViewModel
    {
        public YuanStorey CurrStorey { get; set; }

        /// <summary>
        /// 房间
        /// </summary>
        public List<YuanRoom> Rooms { get { return CurrStorey.Rooms; } }

    }
}