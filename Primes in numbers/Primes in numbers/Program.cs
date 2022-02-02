using System;

namespace Primes_in_numbers
{
    public class PrimeDecomp
    {

        public static String factors(int lst)
        {
            int temp = lst;
            int prime = 2;
            int counter;

            String result = "";

            while (temp != 1)
            {
                counter = 0;

                while (temp > 0 && temp % prime == 0)
                {
                    temp /= prime;
                    counter++;
                }

                switch (counter)
                {
                    case 1: result += "(" + prime + ")"; break;
                    case 0: break;
                    default: result += "(" + prime + "**" + counter + ")"; break;
                }

                prime++;
            }

            return result;
        }
    }

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(PrimeDecomp.factors(7775460));
            }
        }
}
