using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Worlds.Model.Civilization.Areas;
using Worlds.Model.Macroscopic.CivilizedCreation;

namespace Worlds.Travel.Web.Models.ComeTo
{
    public class ComeToWorldViewModel
    {


        public YuanArea CurrArea { get; set; }

        public List<YuanArchitecture> Architectures { get { return CurrArea.Architectures; } }
    }
}