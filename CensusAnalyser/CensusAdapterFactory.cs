using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    class CensusAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCSVCensusData(CensusAnalyser.Country country, string csvFilePath, string headers)
        {
            return country switch
            {
                (CensusAnalyser.Country.INDIA) => new IndianStateCensusAdapter().LoadCensusData(csvFilePath, headers),
                (CensusAnalyser.Country.US) => new USCensusAdapter().LoadCensusData(csvFilePath, headers),
                _ => throw new CensusAnalyserException("No such country found", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY),
            };
        }
    }
}
