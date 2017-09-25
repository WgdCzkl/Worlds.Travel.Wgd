using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Worlds.Model.Civilization.Areas;
using Worlds.Model.Macroscopic.CivilizedCreation;

namespace Worlds.Travel.Web.Models.ComeTo
{
    public class ComeToAreaViewModel
    {
        public YuanArea CurrArea { get; set; }

        public Boolean IsComeToArea
        {
            get
            {
                return CurrArea != null;
            }
        }

        public List<YuanArea> Areas { get; set; }

        public Boolean IsOpenAreas
        {
            get
            {
                return Areas != null && Areas.Count > 0;
            }
        }

        public List<YuanArchitecture> Architectures
        {
            get
            {
                if (IsComeToArea)
                    return CurrArea.Architectures;
                return null;
            }
        }

        public Boolean IsOpenArchitectures
        {
            get
            {
                return Architectures != null && Architectures.Count > 0;
            }
        }



        /// <summary>
        /// 道路
        /// </summary>
        public List<YuanRoad> Roads
        {
            get
            {
                if (IsComeToArea)
                    return CurrArea.Roads;
                return null;
            }
        }

        public Boolean IsOpenRoads
        {
            get
            {
                return Roads != null && Roads.Count > 0;
            }
        }
    }
}