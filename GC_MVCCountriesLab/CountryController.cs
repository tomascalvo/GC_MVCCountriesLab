using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
namespace GC_MVCCountriesLab
{
    //CLASS DECLARATION
    class CountryController
    {
        //FIELDS
        //PROPERTIES
        public List<Country> CountryDb { get; set; } = new List<Country>()
        {
            new Country("Bolivia", Continent.SouthAmerica, new List<string> { "red", "yellow", "green" }),
            new Country("Switzerland", Continent.Europe, new List<string> { "red", "white"}),
            new Country("Ethiopia", Continent.Africa, new List<string> {"blue", "green", "yellow", "red"}),
            new Country("Bahamas", Continent.NorthAmerica, new List<string> { "aquamarine", "gold", "black" })
        };
        //CONSTRUCTORS
        public CountryController() { }
        //METHODS
        public void CountryAction(Country selectedCountry)
        {
            CountryView countryView = new CountryView(selectedCountry);
            countryView.Display();
        }
        public void WelcomeAction()
        {
            CountryListView countryListView = new CountryListView(CountryDb);
            Console.WriteLine("Hello, welcome to The Country App.\n");
            bool loop = true;
            do
            {
                //Console.WriteLine("Entered the do... while loop.");
                Console.WriteLine("Please enter a country from the following list: ");
                countryListView.Display();
                //Console.WriteLine("Displayed the countrylist.");
                if (ValidationLoop("a selection", CountryDb, out int index))           
                {
                    //Console.WriteLine("A valid country selection has been entered.");
                    CountryAction(CountryDb[index]);
                }
                loop = AskYesOrNo("\nWould you like to learn about another country?");
            }
            while (loop);
            Console.WriteLine("Thanks for visiting Country List View. Come again!");
        }
        public static bool ValidateWRegEx(string valueDescription, string regExString, string input)
        {
            Regex regEx = new Regex($@"{regExString}");

            if (regEx.IsMatch(input))
            {
                //Console.WriteLine($"{input} is a {valueDescription}.");
                return true;
            }
            else
            {
                //Console.WriteLine($"{input} is not a {valueDescription}.");
                return false;
            }
        }
        public static bool ValidationLoop(string valueDescription, List<Country> list, out int index)
        {
            //This validation loop overload is intended for use when a user must select from a numbered list of options. This overload accepts a string parameter "valueDescription" which is concatenated into the user prompt for specificity. This overload accepts a List<> parameter "list" which provides the acceptable range of integers from which the user may choose. This overload returns boolean value "true" if the user input is indeed an integer within the index range of the list, and "false" if not. This overload also returns an int "index", which equals the user input minus 1.
            //This validation loop references the method "ValidateWRegEx."
            bool valid = false;
            string input = null;
            int counter = 0;
            string regEx = "\\b[1-" + $"{list.Count()}" + "]\\b";
            while (!valid && counter <= 2)
            {
                Console.WriteLine($"Enter {valueDescription} (#1-{list.Count()}): ");
                input = Console.ReadLine().Trim();
                if (ValidateWRegEx(valueDescription, regEx, input))
                {
                    index = int.Parse(input) - 1;
                    valid = true;
                    return true;
                }
                else
                {
                    Console.WriteLine($"Invalid entry. {2 - counter} attempts remaining.");
                    counter++;
                }
            }
            index = -1;
            return false;
        }
        public static bool AskYesOrNo(string question)
        {
            bool loop = true;
            int counter = 0;
            while (loop && counter < 3)
            {
                Console.WriteLine(question);
                string response = Console.ReadLine().ToLower();
                Regex yesTrue = new Regex(@"\b((y(es)?)|\b(t(rue)?))\b");
                Regex noFalse = new Regex(@"\b((n(o)?)|(f(alse)?))\b");
                try
                {
                    if (yesTrue.IsMatch(response))
                    {
                        loop = false;
                        return true;
                    }
                    if (noFalse.IsMatch(response))
                    {
                        loop = false;
                        return false;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid entry. {2 - counter} attempts remaining.");
                        counter++;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Response attempts exhausted.");
                }
            }
            return false;
        }
    }
}
