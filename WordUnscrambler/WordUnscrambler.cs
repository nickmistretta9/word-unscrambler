using System;
using System.Collections.Generic;
using System.Linq;

namespace WordUnscrambler
{
    public class WordUnscrambler
    {
        private readonly FileReader _fileReader = new FileReader();
        private WordMatcher _wordMatcher = new WordMatcher();
        private List<string> _scrambledWords;
        

        public WordUnscrambler()
        {
            _scrambledWords = new List<string>();
        }

        public void PromptForInput()
        {
            Console.Write(Constants.WelcomeToProgram);
            var input = Console.ReadLine();
            switch (input.ToUpper())
            {
                case Constants.Manual:
                    AddWordsManual();
                    break;
                case Constants.File:
                    AddWordsFromFile();
                    break;
                default:
                    Console.WriteLine(Constants.EnterScrambledWordsOptionNotRecognized);
                    ContinueExecution();
                    break;
            }
        }

        public void ContinueExecution()
        {
            var continueGoing = string.Empty;
            do
            {
                Console.Write(Constants.OptionsOnContinuingTheProgram);
                continueGoing = Console.ReadLine() ?? string.Empty;
            } while (!continueGoing.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) && !continueGoing.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

            if (continueGoing.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase))
                PromptForInput();
            else if (continueGoing.Equals(Constants.No, StringComparison.OrdinalIgnoreCase))
                Console.WriteLine(Constants.ErrorProgramWillBeTerminated);
        }

        public void AddWordsManual()
        {
            var input = string.Empty;
            do
            {
                Console.Write(Constants.EnterScrambledWordsManually);
                input = Console.ReadLine();

                string[] scrambledWords = input.Split(", ");
                foreach (var word in scrambledWords)
                {
                    _scrambledWords.Add(word);
                }
                DisplayMatchedUnscrambledWords(_scrambledWords);
                ContinueExecution();
                input = string.Empty;
            }
            while (!input.Equals(String.Empty));
        }

        public void AddWordsFromFile()
        {
            Console.Write(Constants.EnterScrambledWordsViaFile);
            try
            {
                var input = Console.ReadLine();
                string[] scrambledWords = _fileReader.Read(input);
                DisplayMatchedUnscrambledWords(scrambledWords);
                ContinueExecution();
            } catch(Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCouldNotBeLoaded + ex.Message);
                ContinueExecution();
            }
        }

        private void DisplayMatchedUnscrambledWords(IEnumerable<string> scrambledWords)
        {
            string[] wordList = _fileReader.Read(Constants.WordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
                Console.WriteLine(Constants.MatchNotFound);
        }

        public void Run()
        {
            PromptForInput();
        }
    }
}
