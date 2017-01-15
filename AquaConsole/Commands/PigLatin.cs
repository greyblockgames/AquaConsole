using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.Commands
{
    class PigLatin : ICommand
    {
        public string Command
        {
            get
            {
                return "piglatin";
            }
        }

        public string HelpText
        {
            get
            {
                return "converts a sentence into piglatin";
            }
        }

        public void CommandMethod(string[] p)
        {
            string text = string.Empty;
            for (int i = 0; i < p.Length; i++)
            {              
                text = text + " " + p[i];
            }

            Console.WriteLine(text.TrimStart());
            PluginAPI.Utility.Wait(2f);
            Console.WriteLine(text.TrimStart().Split(' ')
         .Select(word => word.SkipWhile(c => !c.IsVowel()).Concat(word.TakeWhile(c => c.IsVowel())))
         .Select(word => word.Concat((word.Last().IsVowel() ? "way" : "ay").ToCharArray()))
         .Select(word => string.Concat(word))
         .Join(' '));
        }
    }

    static class Extensions
    {
        public static IEnumerable<char> ToCharsWithStartingVowelLast(this string word)
        {
            return "aeiouy".Contains(word[0])
                ? word.Skip(1).Concat(word.Take(1))
                : word.ToCharArray();
        }
        public static IEnumerable<char> WithEnding(this IEnumerable<char> word, string ending)
        {
            return word.Concat(ending.ToCharArray());
        }
        public static string Join(this IEnumerable<IEnumerable<char>> words, char separator)
        {
            return string.Join(separator.ToString(), words.Select(word => string.Concat(word)));
        }
               
        public static bool IsVowel(this char c)
        {
            long x = (long)(char.ToUpper(c)) - 64;
            if (x * x * x * x * x - 51 * x * x * x * x + 914 * x * x * x - 6894 * x * x + 20205 * x - 14175 == 0) return true;
            else return false;
        }
    }
}

