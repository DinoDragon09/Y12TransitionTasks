using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransitionTasks
{
    internal class CheckPalindrome : ITask
    {
        public void Run()
        {
            Console.WriteLine(Check(GetInput()) ? "That is a palindrome" : "That is not a palindrome");

            Console.ReadLine();
        }

        static bool Check(string input) => (input == string.Join("", input.Reverse()));

        static string GetInput()
        {
            Console.WriteLine("Please enter something: ");
            return Console.ReadLine();
        }
    }
}
