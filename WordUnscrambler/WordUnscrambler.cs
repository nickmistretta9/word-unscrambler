using System;
using System.Collections.Generic;

namespace WordUnscrambler
{
    public class WordUnscrambler
    {
        private List<string> _scrambledWords;

        public WordUnscrambler()
        {
            _scrambledWords = new List<string>();
        }

        public void PromptForInput()
        {
            Console.Write("Would you like to input words manually or from a file? ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "manual":
                    AddWordsManual();
                    break;
                case "file":
                    AddWordsFromFile();
                    break;
                default:
                    break;
            }
        }

        public void AddWordsManual()
        {
            var input = string.Empty;
            do
            {
                Console.Write("Enter the word you would like to unscramble or enter nothing to exit: ");
                input = Console.ReadLine();

                _scrambledWords.Add(input);
            }
            while (!input.Equals(String.Empty));
        }

        public void AddWordsFromFile()
        {
            Console.Write("Enter the path for the file: ");
            var input = Console.ReadLine();
        }

        public void Run()
        {
            PromptForInput();
        }
    }
}
