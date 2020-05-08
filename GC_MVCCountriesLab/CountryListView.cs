using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace GC_MVCCountriesLab
{
    //CLASS DECLARATION
    class CountryListView
    {
        //CLASS FIELDS
        //CLASS PROPERTIES
        public List<Country> Countries { get; set; }
        //CLASS CONSTRUCTORS
        public CountryListView(List<Country> countries)
        {
            Countries = countries;
        }
        //CLASS METHODS
        public void Display()
        {
            for (int i = 0; i < Countries.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + Countries[i].Name);
            }
        }
    }
}
