using System;

namespace TransitionTasks
{
    internal class Program
    {
        static ITask[] tasks = { new MaxMinList(), new CheckPalindrome(), new Hangman() };

        static void Main(string[] args)
        {
            Console.WriteLine("What would you like to do:\n[0] MaxMinList\n[1] CheckPalindrome\n[2] Hangman\n\nEnter number: ");

            int selection = Int32.Parse(Console.ReadLine());

            switch(selection)
            {
                case 0:
                {
                    tasks[0].Run();
                    break;
                }

                case 1:
                {
                    tasks[1].Run();
                    break;
                }

                case 2:
                {
                    tasks[2].Run();
                    break;
                }
            }
        }
    }

    interface ITask
    {
        void Run();
    }
}
