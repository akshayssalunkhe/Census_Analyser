using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class CensusDTO
    {
        public string state;
        public string stateCode;
        public string stateName;
        public int srNo;
        public int tin;
        public long population;
        public long areaInSqKm;
        public long densityPerSqKm;

        public CensusDTO(CSVStateCensus stateCensus)
        {
            this.state = stateCensus.state;
            this.population = stateCensus.population;
            this.areaInSqKm = stateCensus.areaInSqKm;
            this.densityPerSqKm = stateCensus.densityPerSqKm;
        }

        public CensusDTO(CSVStateCode stateCode)
        {
            this.stateCode = stateCode.stateCode;
            this.stateName = stateCode.stateName;
            this.srNo = stateCode.srNo;
            this.tin = stateCode.tin;
        }
    }
}