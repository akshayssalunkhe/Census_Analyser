using System;
using System.IO;

namespace CensusAnalyser
{
    public class CensusAnalyser
    {
        public int loadStateCSVData(string csvFilePath)
        {
            if (!csvFilePath.Contains("StateCensusData"))
                throw new CensusAnalyserException("WRONG_FILE_PATH", CensusAnalyserException.ExceptionType.NO_SUCH_FILE);

            string[] lines = File.ReadAllLines(csvFilePath);
            return lines.Length - 1;

        }
    
    }
}
