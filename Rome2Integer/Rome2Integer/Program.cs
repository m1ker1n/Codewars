using System;
using System.Linq;
using System.Collections.Generic;

namespace Rome2Integer
{
    public class RomanNumerals
    {
        static int[] integers = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        static string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        public static string ToRoman(int n)
        {
            if (n >= 4000 || n <= 0) return "NO MORE ROM";

            string result = "";
            int num = n;

            for (int index = 0; index < integers.Length && num > 0; index++ )
            {
                int quotient = num / integers[index];
                int modulo = num % integers[index];

                for (int i = 0; i < quotient; i++) result += symbols[index];

                num = modulo;
            }

            return result;
        }

        public static int FromRoman(string romanNumeral)
        {
            string temp = new string(romanNumeral);
            int result = 0;

            var integersAndSymbols = integers.Zip(symbols,
                                                 (first, second) => new
                                                 {
                                                     integer = first,
                                                     symbol = second
                                                 });

            var collection = from item in integersAndSymbols
                             orderby item.symbol.Length descending
                             select item;
            
            while (temp.Length>=2)
            {
                string sub1 = temp.Substring(0, 1);
                string sub2 = temp.Substring(0, 2);

                foreach(var item in collection)
                {
                    if (sub2.Equals(item.symbol))
                    {
                        result += item.integer;
                        temp = temp.Remove(0, 2);
                        break;
                    }

                    if(sub1.Equals(item.symbol))
                    {
                        result += item.integer;
                        temp = temp.Remove(0, 1);
                        break;
                    }
                }
            }

            if (temp.Length == 0) return result;

            if (temp.Length == 1)
            {
                string sub1 = temp.Substring(0, 1);
                foreach(var item in collection)
                {
                    if(sub1.Equals(item.symbol))
                    {
                        result += item.integer;
                        temp = temp.Remove(0, 1);
                        return result;
                    }
                }
            }

            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i<4001; i++)
                Console.WriteLine($"{i} = {RomanNumerals.ToRoman(i)}");
            Console.WriteLine(RomanNumerals.FromRoman("MMMCM"));
        }
    }
}
