using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
   public class CSVStateCensus
    {
        public string state;
        public long population;
        public long areaInSqKm;
        public long densityPerSqKm;

        public CSVStateCensus(string state, string population, string areaInSqKm, string densityPerSqKm)
        {
            this.state = state;
            this.population = Convert.ToUInt32(population);
            this.areaInSqKm = Convert.ToUInt32(areaInSqKm);
            this.densityPerSqKm = Convert.ToUInt32(densityPerSqKm);
        }
    }
}