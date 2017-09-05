using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Worlds.Trave.Repository.Common.Helper
{
    public static class XmlHelper
    {
        /// <summary>
        /// 对象到XML-----泛类型
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="pT">对象</param>
        /// <returns>XML</returns>
        public static string T2XML<T>(T pT)
        {
            if (pT == null) return null;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            MemoryStream stream = new MemoryStream();
            XmlTextWriter xtw = new XmlTextWriter(stream, Encoding.UTF8);
            xtw.Formatting = Formatting.Indented;
            try
            {
                serializer.Serialize(stream, pT);
            }
            catch { return null; }

            stream.Position = 0;
            StringBuilder lbreturnStr = new StringBuilder();
            using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    lbreturnStr.Append(line);
                }
            }
            return lbreturnStr.ToString();
        }

        /// <summary>
        /// 对象到XML-----泛类型
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="pLT">泛型集合</param>
        /// <returns>XML</returns>
        public static string LT2XML<T>(List<T> pLT)
        {
            if (pLT == null) return null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            MemoryStream stream = new MemoryStream();
            XmlTextWriter xtw = new XmlTextWriter(stream, Encoding.UTF8);
            xtw.Formatting = Formatting.Indented;
            try
            {
                serializer.Serialize(stream, pLT);
            }
            catch { return null; }

            stream.Position = 0;
            StringBuilder lbreturnStr = new StringBuilder();
            using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    lbreturnStr.Append(line);
                }
            }
            return lbreturnStr.ToString();
        }

        /// <summary>
        /// XML到反序列化到对象----支持泛类型
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="psXML">XML数据</param>
        /// <returns>返回泛型实体</returns>
        public static T XML2T<T>(string psXML)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter sw = new StreamWriter(stream, Encoding.UTF8))
                {
                    sw.Write(psXML);
                    sw.Flush();
                    stream.Seek(0, SeekOrigin.Begin);
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    try
                    {
                        return ((T)serializer.Deserialize(stream));
                    }
                    catch { return default(T); }

                }
            }
        }

        /// <summary>
        /// XML到反序列化到对象----支持泛类型
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="psXML">XML数据</param>
        /// <returns>返回泛型实体</returns>
        public static List<T> XML2LT<T>(string psXML)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter sw = new StreamWriter(stream, Encoding.UTF8))
                {
                    sw.Write(psXML);
                    sw.Flush();
                    stream.Seek(0, SeekOrigin.Begin);
                    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                    try
                    {
                        return ((List<T>)serializer.Deserialize(stream));
                    }
                    catch { return default(List<T>); }

                }
            }
        }


        #region XML读取
        public static string ReadXML(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            return xmlDoc.InnerXml;
        }

        #endregion


        #region 综合
        public static List<T> XML2LTByFilePaht<T>(string path)
        {
            path = string.Format(@"{0}\{1}", XmlDataFileRootDirectory, path);
            return XML2LT<T>(ReadXML(path));
        }
        #endregion


        #region 路径
        /// <summary>
        /// XML 数据文件更目录
        /// </summary>
        public static string XmlDataFileRootDirectory = string.Format("{0}App_Data", System.AppDomain.CurrentDomain.BaseDirectory.Replace("Worlds.Travel.Web", "Worlds.Trave.Repository.Common"));
        #endregion
    }
}
