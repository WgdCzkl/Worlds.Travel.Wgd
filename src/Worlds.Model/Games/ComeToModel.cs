using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Civilization.Areas;
using Worlds.Model.Civilization.Symbolizes;
using Worlds.Model.Dimension.Space;
using Worlds.Model.Dimension.Time;
using Worlds.Model.Macroscopic.CivilizedCreation;

namespace Worlds.Model.Games
{
    /// <summary>
    /// 降临
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ComeToModel<T> where T : Yuan
    {
        public ComeToModel()
        {

        }

        public ComeToModel(List<T> opens)
        {
            Opens = opens;
        }

        /// <summary>
        /// 开放的对象
        /// </summary>
        public List<T> Opens { get; set; }

        public List<T> _selecteds = null;
        /// <summary>
        /// 选择的对象
        /// </summary>
        public List<T> Selecteds
        {
            get
            {
                if (_selecteds == null)
                {
                    _selecteds = new List<T>();
                }
                return _selecteds;
            }
            set
            {
                _selecteds = value;
            }
        }

        /// <summary>
        /// 当前的对象
        /// </summary>
        public T Curr { get; set; }

        public ComeToModel<T> SetCurr(string key)
        {
            this.Curr = Opens.Find(o => o.Key == key);
            this.AddSelected(Curr);
            return this;
        }

        public List<T> AddSelected(T sel)
        {

            Selecteds.Add(sel);
            return Selecteds;
        }
    }

    /// <summary>
    /// 降临对象s
    /// </summary>
    public class ComeToModels : Yuan
    {
        public ComeToModels()
        {

        }

        #region 属性
        /// <summary>
        /// 星系
        /// </summary>
        public ComeToModel<Galaxy> Galaxy { get; set; }

        /// <summary>
        /// 星球
        /// </summary>
        public ComeToModel<Planet> Planet { get; set; }

        /// <summary>
        /// 星球时间
        /// </summary>
        public ComeToModel<PlanetTime> PlanetTime { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public ComeToModel<YuanArea> Area { get; set; }

        public string Paths
        {
            get
            {
                string path = string.Empty;
                if (Planet != null && Planet.Curr != null)
                    path = string.Format(@"{0}", Planet.Curr.Name.KeyName);
                if (PlanetTime != null && PlanetTime.Curr != null)
                    path = string.Format(@"{0}\{1}", path, PlanetTime.Curr.KeyName);
                if (Area != null)
                    foreach (var item in Area.Selecteds)
                    {
                        path = string.Format(@"{0}\{1}", path, item.Name.KeyName);
                    }
                return path;
            }
        }

        /// <summary>
        /// 建筑
        /// </summary>
        public ComeToModel<YuanArchitecture> Architectur { get; set; }

        /// <summary>
        /// 楼层
        /// </summary>
        public ComeToModel<YuanStorey> Storey { get; set; }

        /// <summary>
        /// 套房
        /// </summary>
        public ComeToModel<YuanSuite> Suite { get; set; }

        /// <summary>
        /// 房间
        /// </summary>
        public ComeToModel<YuanRoom> Room { get; set; }

        /// <summary>
        /// 路
        /// </summary>
        public ComeToModel<YuanRoad> Road { get; set; }
        #endregion

        #region 方法
        public ComeToModels SetGalaxys(List<Galaxy> galaxys)
        {
            Galaxy = new ComeToModel<Galaxy>(galaxys);
            return this;
        }

        public ComeToModels SetCurrGalaxy(string key)
        {
            Galaxy.SetCurr(key);
            Planet = new ComeToModel<Planet>(Galaxy.Curr.SurroundPlanets);
            return this;
        }

        public ComeToModels SetCurrPlanet(string key)
        {
            Planet.SetCurr(key);
            PlanetTime = new ComeToModel<PlanetTime>(Planet.Curr.OpenPlanetTimes);
            return this;
        }

        public ComeToModels SetCurrPlanetTimeByKeyName(string key)
        {
            PlanetTime = PlanetTime.SetCurr(key);
            return this;
        }

        public ComeToModels UpdateArea(List<YuanArea> areas)
        {
            Area = new ComeToModel<YuanArea>(areas);
            return this;
        }

        public ComeToModels SetCurrArea(string key)
        {
            this.Area.SetCurr(key);
            return this;
        }

        public ComeToModels UpdateOpenAreas(List<YuanArea> areas)
        {
            Area.Opens = areas;
            return this;
        }

        public ComeToModels SetCurrArchitectur(string key)
        {
            this.Architectur = new ComeToModel<YuanArchitecture>(Area.Curr.Architectures);
            this.Architectur.SetCurr(key);
            return this;
        }

        public ComeToModels SetCurrStorey(string key)
        {
            this.Storey = new ComeToModel<YuanStorey>(Architectur.Curr.SubStoreys);
            this.Storey.SetCurr(key);
            return this;
        }

        public ComeToModels UpdateOpenStoreys(List<YuanStorey> storeys)
        {
            Storey = new ComeToModel<YuanStorey>(storeys);
            return this;
        }

        public ComeToModels UpdateOpenSuites(List<YuanSuite> suites)
        {
            Suite = new ComeToModel<YuanSuite>(suites);
            return this;
        }
        #endregion

    }
}
