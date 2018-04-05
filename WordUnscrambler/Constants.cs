using System.IO;

namespace WordUnscrambler
{
    class Constants
    {
        public const string WelcomeToProgram = "Welcome to the program. What would you like to do? (M/F): ";
        //public const string OptionsOnHowToEnterScrambledWords = "Enter scrambled word(s) manually or as a file: ";
        public const string OptionsOnContinuingTheProgram = "Would you like to continue? (Y/N): ";

        public const string EnterScrambledWordsViaFile = "Enter full path including the file name: ";
        public const string EnterScrambledWordsManually = "Enter word(s) manually, separated by commas if multiple, or nothing to exit: ";
        public const string EnterScrambledWordsOptionNotRecognized = "The option was not recognized. Please try again.";

        public const string ErrorScrambledWordsCouldNotBeLoaded = "Scrambled words could not be loaded because there was an error.";
        public const string ErrorProgramWillBeTerminated = "The program will be terminated.";

        public const string MatchFound = "Match found for {0}: {1}";
        public const string MatchNotFound = "No matches have been found.";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manual = "M";

        public const string WordListFileName = "MyFirstFile.txt";
    }
}
