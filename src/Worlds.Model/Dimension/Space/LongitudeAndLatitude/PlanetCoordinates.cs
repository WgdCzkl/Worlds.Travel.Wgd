using Worlds.Model.Dimension.Volume;

namespace Worlds.Model.Dimension.Space.LongitudeAndLatitude
{
    /// <summary>
    /// 星球坐标系
    /// </summary>
    public class PlanetCoordinates
    {
        public PlanetCoordinates()
        {

        }
        public PlanetCoordinates(decimal lat, decimal lon, decimal height)
        {
            Lat = new Latitude(lat);
            Lon = new Longitude(lon);
            Height = new CenterDistance(height);
        }

        /// <summary>
        /// 经度
        /// </summary>
        public Latitude Lat { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public Longitude Lon { get; set; }

        /// <summary>
        /// 球心距
        /// </summary>
        public CenterDistance Height { get; set; }


        public override string ToString()
        {
            return string.Format("经度{0}纬度{1}球心距{2}", Lat, Lon, Height);
        }

        #region 方法
        public PlanetCoordinates GetNewPlanetCoordinates(CoordinateThree coordinate)
        {
            PlanetCoordinates newPoint = new PlanetCoordinates();
            newPoint.Lat = this.Lat.Value + coordinate.SubCoordinate.X.Value;
            newPoint.Lon = this.Lon.Value + coordinate.SubCoordinate.Y.Value;
            newPoint.Height = this.Height.Value + coordinate.H.Value;
            return newPoint;
        }

        /// <summary>
        /// 自定义 隐式转换
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator PlanetCoordinates(CoordinateThree value)
        {
            return new PlanetCoordinates(value.SubCoordinate.X.Value, value.SubCoordinate.Y.Value, value.H.Value);
        }
        #endregion
    }
}
