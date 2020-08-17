using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CensusAnalyser
{
    class USCensusAdapter : CensusAdapter
    {
        Dictionary<string, CensusDTO> dataMap = new Dictionary<string, CensusDTO>();

        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string headers)
        {
            string[] lines = GetCensusData(csvFilePath, headers);
            foreach (string line in lines.Skip(1))
            {
                if (!line.Contains(','))
                {
                    throw new CensusAnalyserException("Incorrect delimiter", CensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER);
                }

                string[] field = line.Split(',');

                dataMap.Add(field[1], new CensusDTO(new CSVUSCensus(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8])));

            }

            return dataMap.Skip(1).ToDictionary(field => field.Key, field => field.Value);
        }
    }
}
