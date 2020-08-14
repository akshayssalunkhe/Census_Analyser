using System;
using System.IO;

namespace CensusAnalyser
{
    public class CensusAnalyser
    {
        public int loadStateCSVData(string csvFilePath)
        {
            string[] lines = File.ReadAllLines(csvFilePath);
            return lines.Length - 1;

        }
    
    }
}
