using System;
using System.Globalization;
using System.Collections.Generic;
namespace GC_MVCCountriesLab
{
    //CLASS DECLARATION
    class CountryView
    {
        //FIELD(S)
        //PROPERTY(IES)
        public Country DisplayCountry { get; set; }
        //CLASS CONSTRUCTOR(S)
        public CountryView(Country displayCountry)
        {
            DisplayCountry = displayCountry;
        }
        //CLASS METHOD(S)
        public void Display()
        {
            string colorsString = ToCommaSeparatedString(DisplayCountry.Colors);
            Console.WriteLine($"\n{DisplayCountry.Name} is a country in {DisplayCountry.Continent.ToDescription()}. The colors of this country's flag are ");
            PrintConsoleColorsParsedListCommaSeparated(DisplayCountry.Colors);
        }

        public static string ToCommaSeparatedString(List<string> list)
        {
            //Convert all elements in a List<string> to one string with each element separated by comma + whitespace and ending with a period.
            //Console.WriteLine("ToCommaSeparatedString() has been invoked.");
            string output = "";
            for (int i = 0; i < list.Count - 1; i++)
            {
                output = output + list[i];
                if (list.Count > 2)
                {
                    output = output + ", ";
                }
                //Console.WriteLine($"Element #{i + 1} has been concatenated. The value of string output is now \"{output}\"");
            }
            output = output + "and " + list[^1] + ".";
            //Console.WriteLine($"All list elements have been concatenated. The value of string output is now \"{output}\"");
            return output;
        }
        public static void ParseConsoleColor(string color)
        {
            //PARSES A STRING AND SETS THE CONSOLECOLOR TO MATCHING VALUE
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            try
            {
                if (color.ToLower() == ("aquamarine"))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else if (color.ToLower() == "gold")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else
                {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), myTI.ToTitleCase(color));
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
        }
        public static void ParseConsoleColor(List<string> list)
        {
            //PARSES A LIST OF STRINGS AND SETS THE CONSOLECOLOR TO THE LAST MATCHING VALUE
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].ToLower() == ("aquamarine"))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (list[i].ToLower() == "gold")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (list[i].ToLower() == "blue")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    {
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), myTI.ToTitleCase(list[i]));
                    }
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
        }
        public static void PrintConsoleColorsParsedListCommaSeparated(List<string> list)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            for (int i = 0; i < list.Count - 1; i++)
            {
                ParseConsoleColor(list[i]);
                Console.Write(list[i]);
                if (list.Count <= 2)
                {
                    Console.Write(" ");
                }
                else if (list.Count > 2)
                {
                    Console.Write(", ");
                }
                Console.ResetColor();
            }
            Console.WriteLine("and ");
            ParseConsoleColor(list[^1]);
            Console.WriteLine(list[^1] + ".");
            Console.ResetColor();
        }
    }
}
