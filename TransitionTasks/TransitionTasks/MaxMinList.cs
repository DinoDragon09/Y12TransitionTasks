using System;
using System.Collections.Generic;

namespace TransitionTasks
{
    internal class MaxMinList : ITask
    {
        public void Run()
        {
            List<float> numbers = new List<float>();

            while (true)
            {
                float input = GetInput();

                numbers.Add(input);
                numbers.Sort();

                Console.WriteLine($"Min: {numbers[0]} Max: {numbers[numbers.Count - 1]}");
            }
        }

        static float GetInput()
        {
            float input = 0f;
            bool validInput = false;

            while (!validInput)
            {
                validInput = true;
                Console.Write("Please enter a number: ");

                try
                {
                    input = float.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("That is not a valid number \n");
                    validInput = false;
                }
            }

            return input;
        }
    }
}
