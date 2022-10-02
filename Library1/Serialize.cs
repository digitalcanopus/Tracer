using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Library1
{
    public class Serialize
    {
        public string JsonSer(ProcessedText text)
        {
            var opt = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(text, opt);
        }

        public string XmlSer(ProcessedText text)
        {
            var Serializer = new XmlSerializer(typeof(ProcessedText));
            StringBuilder strB = new StringBuilder();
            StringWriter strW = new StringWriter(strB);
            Serializer.Serialize(strW, text); 
            return strW.GetStringBuilder().ToString();
        }
    }
}
