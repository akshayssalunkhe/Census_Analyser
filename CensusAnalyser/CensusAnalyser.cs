using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyser
{
    public class CensusAnalyser : ICSVBuilder
    {
        List<string> lines = new List<string>();

        Dictionary<string, CensusDTO> dataMap = new Dictionary<string, CensusDTO>();

        public delegate object CSVData(string csvFilePath, string header);
        public object loadCSVDataFile(string csvFilePath, string header)
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

            foreach (string line in lines)
            {
       
                if (!line.Contains(','))
                {
                    throw new CensusAnalyserException("Incorrect delimiter", CensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER);
                }

                string[] field = line.Split(',');

                if (csvFilePath.Contains("StateCode.csv"))
                    dataMap.Add(field[1], new CensusDTO(new CSVStateCode(field[0], field[1], field[2], field[3])));

                if (csvFilePath.Contains("StateCensusData.csv"))
                    dataMap.Add(field[0], new CensusDTO(new CSVStateCensus(field[0], field[1], field[2], field[3])));

            }


            if (lines[0] != header)
            {
                throw new CensusAnalyserException("Incorrect header", CensusAnalyserException.ExceptionType.NO_SUCH_HEADER);
            }

            return dataMap.Skip(0).ToDictionary(field => field.Key, field => field.Value);

        }

     
        public object GetSortedStateWiseCensusDataInJsonFormat(string csvFilePath, string header, string headerField, string sortBy)

        {
            var data = (Dictionary<string, CensusDTO>)loadCSVDataFile(csvFilePath, header);
            List<CensusDTO> censusDataList = data.Values.ToList();
            List<CensusDTO> sortedList = getSortedData(headerField, censusDataList);

            if (sortBy.Contains("DESC")) sortedList.Reverse();

            return JsonConvert.SerializeObject(sortedList);
        }

        public List<CensusDTO> getSortedData(string headerField, List<CensusDTO> censusDataList)
        {
            return headerField switch
            {
                "stateName" => censusDataList.OrderBy(field => field.stateName).ToList(),
                "stateCode" => censusDataList.OrderBy(field => field.stateCode).ToList(),
                "state" => censusDataList.OrderBy(field => field.state).ToList(),
                "area" => censusDataList.OrderBy(field => field.areaInSqKm).ToList(),
                "population" => censusDataList.OrderBy(field => field.population).ToList(),
                "populationDensity" => censusDataList.OrderBy(field => field.densityPerSqKm).ToList(),
                _ => censusDataList.OrderBy(field => field.tin).ToList(),
            };
        }

        public object LoadUSCSVDataFile(string csvFilePath, string header)
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
            foreach (string line in lines)
            {
                if (!line.Contains(','))
                {
                    throw new CensusAnalyserException("Incorrect delimiter", CensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER);
                }

                string[] field = line.Split(',');

                dataMap.Add(field[1], new CensusDTO(new CSVUSCensus(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8])));
            }

            if (lines[0] != header)
            {
                throw new CensusAnalyserException("Incorrect header", CensusAnalyserException.ExceptionType.NO_SUCH_HEADER);
            }

            return dataMap.Skip(1).ToDictionary(field => field.Key, field => field.Value);

        }
    }
    
}
