using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Library1
{
    [Serializable]
    [XmlRoot(ElementName = "ProcessedText")]
    public class ProcessedText
    {
        [XmlArrayItem("Inf about thread")]
        public List<TInfo> tInfo { get; set; }
        public ProcessedText() { }
    }
}
