using System;
using System.Collections.Generic;

namespace Valid_Parentheses
{
    public class Parentheses
    {
        public static bool ValidParentheses(string input)
        {
            string filtered = "";
            foreach (char c in input)
            {
                if (c == '(' || c == ')') filtered += c;
            }

            Stack<char> stack = new Stack<char>();
            foreach (char c in filtered)
            {
                char peek;
                var peekSuccess = stack.TryPeek(out peek); //check if it is empty
                if (peekSuccess)
                {
                    if (c == peek) stack.Push(c); //if same => push, they can't destroy each other
                    else if (peek == '(') stack.Pop(); //can destroy. because we have ')' and peek is '('
                    else stack.Push(c); //can't destroy. They different, but wrong order ")("
                }
                else stack.Push(c); //was empty, so just pushed it
            }

            return (stack.Count == 0);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Parentheses.ValidParentheses(")(((("));
        }
    }
}
