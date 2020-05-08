using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GC_MVCCountriesLab
{
    //COUNTRY MODEL
    //ENUMERATOR "Continent"
    enum Continent
        {
        Africa,
        [Description("North America")] NorthAmerica,
        [Description("South America")] SouthAmerica,
        Asia,
        Australia,
        Europe,
        Antarctica
        }
    //CLASS DELCARATION
    class Country
    {
        //FIELDS
        //PROPERTIES
        public string Name { get; set; }
        public Continent Continent { get; set; }
        public List<string> Colors { get; set; }
        //CLASS CONSTRUCTORS
        public Country(string name, Continent continent, List<string> colors)
        {
            Name = name;
            Continent = continent;
            Colors = colors;
        }
        //DEFAULT CONSTRUCTOR
        public Country() { }
    }
}
