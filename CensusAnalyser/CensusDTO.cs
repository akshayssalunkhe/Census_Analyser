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
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;

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

        public CensusDTO(CSVUSCensus usCensus)
        {
            this.stateCode = usCensus.stateId;
            this.stateName = usCensus.stateName;
            this.population = usCensus.population;
            this.housingDensity = usCensus.housingDensity;
            this.totalArea = usCensus.totalArea;
            this.waterArea = usCensus.waterArea;
            this.landArea = usCensus.landArea;
            this.populationDensity = usCensus.populationDensity;
            this.housingDensity = usCensus.housingDensity;
        }
    }
}