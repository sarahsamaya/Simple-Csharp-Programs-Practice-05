using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Assign4_FormWithXML
{
        [XmlRoot("DogList")]
         public class DogList
        {
            [XmlArray("Dogs")]
            [XmlArrayItem("Dog")]
            public List<Dog> Dogs { get; set; }
        }

}
