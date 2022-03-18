using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SpravaProjektovFirmy
{
    public class Project
    {
        [XmlAttribute]
        public string? id { get; set; }
        public string? Name { get; set; }
        public string? Abbreviation { get; set; }
        public string? Customer { get; set; }
    }
}