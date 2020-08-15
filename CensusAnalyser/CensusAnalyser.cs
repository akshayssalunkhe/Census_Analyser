using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyser
{
    public class CensusAnalyser
    {
        public delegate object CSVData();

        string filePath;
        string dataHeader;

        public CensusAnalyser(string filePath, string dataHeader)
        {
            this.filePath = filePath;
            this.dataHeader = dataHeader;
        }

        public CensusAnalyser()
        {
        }

        public object loadCensusData()
        {
            if (!File.Exists(filePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.NO_SUCH_FILE);
            }

            if (Path.GetExtension(filePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE);
            }

            string[] data = File.ReadAllLines(filePath);
            
            if (data[0] != dataHeader)
            {
                throw new CensusAnalyserException("Invalid Header", CensusAnalyserException.ExceptionType.NO_SUCH_HEADER);
            }
            
            foreach (string delimiter in data)
            {
                if (!delimiter.Contains(","))
                {
                    throw new CensusAnalyserException("Invalid Delimiter", CensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER);
                }
            }
            
            return data.Skip(1).ToArray();
        }
    }
}
