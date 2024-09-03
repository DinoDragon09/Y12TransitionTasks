using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;

namespace TransitionTasks
{
    internal class Hangman : ITask
    {
        static string word;
        static string progress;
        static int lives;
        static bool playing;

        public void Run()
        {
            word = GetWord();
            string wordCheck = string.Join(" ", word.ToCharArray()) + " ";
            progress = HideLetters(word);
            lives = 5;
            playing = true;

            while (playing)
            {
                Console.WriteLine($"You have {lives} live(s) remaining");
                Console.WriteLine(progress);

                char letter = GetLetter();

                UpdateProgress(letter);

                if (progress == wordCheck)
                {
                    Console.WriteLine(progress);
                    Console.WriteLine("You win!");
                    playing = false;
                } else if (lives <= 0)
                {
                    Console.WriteLine("You lose!");
                    Console.WriteLine($"The word was {word}");
                    playing = false;
                }
            }

            Console.ReadLine();
        }

        static string HideLetters(string word)
        {
            char[] letters = word.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = '_';
            }

            return string.Join(" ", letters);
        }

        static string GetWord()
        {
            Random rnd = new Random();
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            IEnumerable<string> words = File.ReadLines(projectDirectory + "/words.txt");

            string word = Enumerable.ElementAt(words, rnd.Next(0, words.Count()));
            return word;
        }

        static char GetLetter()
        {
            Console.Write("Enter a letter: ");

            string line = Console.ReadLine();
            char letter = line[line.Length - 1];

            return letter;
        }

        static void UpdateProgress(char letter)
        {
            string result = "";

            for (int i = 0; i < word.Length; i++)
            {
                if (letter == word[i])
                {
                    result += letter + " ";
                } else
                {
                    result += progress[2*i] + " ";
                }
            }

            if (progress == result)
            {
                lives--;
            }

            progress = result;
        }
    }
}