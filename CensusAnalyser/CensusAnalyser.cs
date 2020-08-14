using System;
using System.Collections.Generic;
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
            foreach (string line in lines)
            {
                if (!line.Contains(','))
                {
                    throw new CensusAnalyserException("Incorrect delimiter", CensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER);
                }
            }

            List<CSVStateCensus> list = new List<CSVStateCensus>();
            StreamReader reader = new StreamReader(csvFilePath);
            string header = reader.ReadLine();

            if (!header.Contains("State") || !header.Contains("Population") || !header.Contains("AreaInSqKm") || !header.Contains("DensityPerSqKm"))
            {
                throw new CensusAnalyserException("Incorrect header", CensusAnalyserException.ExceptionType.NO_SUCH_HEADER);
            }

            return lines.Length - 1;

        }
    
    }
}
