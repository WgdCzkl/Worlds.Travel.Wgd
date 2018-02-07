using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worlds.Model.Dimension.Space.LongitudeAndLatitude;
using Worlds.Model.Dimension.Volume;

namespace Worlds.Model.Civilization.Shapes
{
    /// <summary>
    /// 外形
    /// </summary>
    public class YuanShape : Yuan
    {
        public YuanShape()
        {

        }

        public YuanShape(PlanetCoordinates c, List<CoordinateThree> points)
        {
            CenterPointCoordinates = c;
            BoundaryPoints = points;
        }


        /// <summary>
        /// 中心点坐标
        /// </summary>
        public PlanetCoordinates CenterPointCoordinates { get; set; }


        /// <summary>
        /// 
        /// </summary>
        private List<PlanetCoordinates> _boundaryCoordinatePoints = null;
        /// <summary>
        /// 边界坐标值集合
        /// </summary>
        public List<PlanetCoordinates> BoundaryCoordinatePoints
        {
            get
            {
                if (_boundaryCoordinatePoints != null)
                    return _boundaryCoordinatePoints;
                else
                {
                    List<PlanetCoordinates> points = new List<PlanetCoordinates>();
                    foreach (var item in BoundaryPoints)
                    {
                        points.Add(CenterPointCoordinates.GetNewPlanetCoordinates(item));
                    }
                    _boundaryCoordinatePoints = points;
                    return _boundaryCoordinatePoints;
                }
            }
        }

        /// <summary>
        /// 边界点集合
        /// </summary>
        public List<CoordinateThree> BoundaryPoints { get; set; }

        /// <summary>
        /// 自定义 隐式转换
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator YuanShape(PlanetCoordinates value)
        {
            return new YuanShape() { CenterPointCoordinates = value };
        }

        /// <summary>
        /// 自定义 隐式转换
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator YuanShape(Tuple<PlanetCoordinates, List<CoordinateThree>> Coordinates)
        {
            return new YuanShape(Coordinates.Item1, Coordinates.Item2);
        }
    }
}
