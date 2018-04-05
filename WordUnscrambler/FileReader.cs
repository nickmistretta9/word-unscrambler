using System;
using System.IO;

namespace WordUnscrambler
{
    public class FileReader
    {
        public string[] Read(string input)
        {
            string[] fileContent;

            try {
                fileContent = File.ReadAllLines(input);
            } catch(Exception ex) {
                throw new Exception(ex.Message);
            }

            return fileContent;
        }
    }
}
