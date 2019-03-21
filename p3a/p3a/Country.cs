using System;
using System.Xml.Serialization;

namespace p3a
{
    [Serializable]
    public class Country
    {
        [XmlElement(Order = 1)]
        public string name;

        [XmlIgnore]
        public string code;

        [XmlElement(Order = 6)]
        public string continent;

        [XmlElement(Order = 5, ElementName = "peopleNumber")]
        public int population;

        [XmlElement(Order = 2)]
        public int area;

        [XmlElement(Order = 3)]
        public int coastline;

        [XmlElement(Order = 4)]
        public string currency;

        public Country()
        { }

        public Country(string name, string code, string continent, int population, int area, 
            int coastline, string currency)
        {
            this.name = name;
            this.code = code;
            this.continent = continent;
            this.population = population;
            this.area = area;
            this.coastline = coastline;
            this.currency = currency;
        }
    }
}
