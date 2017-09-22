using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Worlds.Model.Macroscopic.CivilizedCreation;

namespace Worlds.Travel.Web.Models.ComeTo
{
    public class ComeToArchitectureViewModel
    {
        public YuanArchitecture CurrArchitecture { get; set; }

        public List<YuanStorey> Storeys { get { return CurrArchitecture.SubStoreys; } }

    }
}