using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Worlds.Travel.Infrastructure.Utitily
{
    public class SerializeHelper
    {
        public static string XMLSerialize<T>(object obj)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);
            new XmlSerializer(Activator.CreateInstance<T>().GetType()).Serialize((TextWriter)stringWriter, obj, null);
            stringWriter.Dispose();
            return sb.ToString();
        }

        public static T XMLDeserialize<T>(string xml)
        {
            T obj;
            if (string.IsNullOrEmpty(xml)) return default(T);

            using (StringReader rdr = new StringReader(xml))
            {
                XmlSerializer seri = new XmlSerializer(Activator.CreateInstance<T>().GetType());
                obj = (T)seri.Deserialize(rdr);
            }
            return obj;
        }
        public static string JSONSerialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
        }
        public static T JSONDeserialize<T>(string xml)
        {
            T rtn = JsonConvert.DeserializeObject<T>(xml);
            return rtn;
        }

        public static string XMLDecode(string input)
        {
            //<	->	&lt;
            //>	->	&gt;
            //"	->	&quot;
            //'	->	&apos;
            //&	->	&amp
            if (string.IsNullOrEmpty(input)) return "";
            string output = input.Replace("&lt;", "<").Replace("&gt;", ">");
            return output;
        }


        /// <summary>
        /// JSON字符串格式化
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FormatJsonStr(string str)
        {
            try
            {
                //格式化json字符串
                JsonSerializer serializer = new JsonSerializer();
                TextReader tr = new StringReader(str);
                JsonTextReader jtr = new JsonTextReader(tr);
                object obj = serializer.Deserialize(jtr);
                if (obj != null)
                {
                    StringWriter textWriter = new StringWriter();
                    JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                    {
                        Formatting = Formatting.Indented,
                        Indentation = 4,
                        IndentChar = ' ',
                    };
                    serializer.Serialize(jsonWriter, obj);
                    return textWriter.ToString();
                }
                else
                {
                    return str;
                }
            }
            catch
            {
                return str;
            }
        }
    }
}
