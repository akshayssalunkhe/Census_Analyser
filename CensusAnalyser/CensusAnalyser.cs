using System;
using System.IO;

namespace CensusAnalyser
{
    public class CensusAnalyser
    {
        public int loadStateCSVData(string csvFilePath)
        {
            if (!csvFilePath.Contains("StateCensusData"))
            {
                throw new CensusAnalyserException("WRONG_FILE_PATH", CensusAnalyserException.ExceptionType.NO_SUCH_FILE);

            }

            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Incorrect file type", CensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE);
            }

            string[] lines = File.ReadAllLines(csvFilePath);
            return lines.Length - 1;

        }
    
    }
}
