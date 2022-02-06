using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Decode_the_Morse_code
{
    class MorseCodeDecoder
    {
        public static string Decode(string morseCode)
        {
            string trimmed = morseCode.Trim(new char[] { ' ' });

            List<string> letters = new List<string>();  //was just string. But this "SOS" decode as 1 sym
            string result = "";

            Regex letterRgx = new Regex(@"([.|-])+");
            Regex spaceRgx = new Regex(@"[   | ]+");

            MatchCollection letterMatches = letterRgx.Matches(trimmed);
            MatchCollection spaceMatches = spaceRgx.Matches(trimmed);

            foreach (Match letMatch in letterMatches)
            {
                letters.Add(MorseCode.Get(letMatch.Value));
            }

            Console.WriteLine("letters=" + letters);

            int ind = 0;
            foreach (Match spMatch in spaceMatches)
            {
                result += letters[ind];
                if (spMatch.Value == "   ") result += " ";
                Console.WriteLine(result + $" {ind} + |{spMatch.Value}|");
                ind++;
            }
            Console.WriteLine();
            for (; ind < letters.Count; ind++)
            {
                result += letters[ind];
                Console.WriteLine(result);
            }

            return result;
        }
    }
}
