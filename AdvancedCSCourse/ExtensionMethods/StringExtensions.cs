using System;
using System.Linq;

namespace ExtensionMethods
{
    public static class StringExtensions { //extending class + 'Extensions'
        public static string Shorten(this string str, int numberOfWords) { //this + type of extending + param name, and after your own parameters
            if (numberOfWords < 0)
                throw new ArgumentOutOfRangeException("Number of words must be greater than or equal to 0.");

            if (numberOfWords == 0)
                return "";

            var words = str.Split(' '); //to split each word

            if (words.Length <= numberOfWords)
                return str;

            return string.Join(" ", words.Take(numberOfWords)) + "...";
        }
    } 
}

// we could use our normal namespace (ExtensionMethods), but to use this class outside the project, we would nesse to type using ExtensionMethods.Extensions; 
//for example, the trick is to put namespace System, and this class is imported automatically, Microsoft advertise to use Extension Methods just when strictly necessary

// we cant extend from string because it is a sealed class, but we can pass it out