using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyser
{
    public class CensusAnalyser 
    {
        public enum Country
        {
            INDIA,US
        }

        public Dictionary<string, CensusDTO> loadCSVDataFile(Country country, string csvFilePath, string headers)
        {
            Dictionary<string, CensusDTO> dataMap = new CensusAdapterFactory().LoadCSVCensusData(country, csvFilePath, headers);
            return dataMap;
        }

        public object GetSortedStateWiseCensusDataInJsonFormat(Country country, string csvFilePath, string header, string headerField, string sortBy)

        {
            var data = (Dictionary<string, CensusDTO>)loadCSVDataFile(country, csvFilePath, header);
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
                "usPopulationDensity" => censusDataList.OrderBy(field => field.populationDensity).ToList(),
                "totalArea" => censusDataList.OrderBy(field => field.totalArea).ToList(),
                _ => censusDataList.OrderBy(field => field.tin).ToList(),
            };
        }
      
    }
    
}
