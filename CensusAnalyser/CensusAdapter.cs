using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace CensusAnalyser
{
    class CensusAdapter
    {
        protected string[] GetCensusData(string csvFilePath, string headers)
        {
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File not found", CensusAnalyserException.ExceptionType.NO_SUCH_FILE);
            }

            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Incorrect file type", CensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE);
            }

            string[] lines = File.ReadAllLines(csvFilePath);
            if (lines[0] != headers)
            {
                throw new CensusAnalyserException("Incorrect header", CensusAnalyserException.ExceptionType.NO_SUCH_HEADER);
            }

            return lines;
        }
    }
}
