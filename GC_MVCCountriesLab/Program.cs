using System;
using System.Collections.Generic;

namespace GC_MVCCountriesLab
{
    class Program
    {
        static void Main(string[] args)
        {
            CountryController countryController = new CountryController();
            countryController.WelcomeAction();
        }
    }
}
