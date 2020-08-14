using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    class CSVStateCensus
    {
        private string state;
        private string population;
        private string areaInSqKm;
        private string densityPerSqKm;

        public string State { get => state; set => state = value; }
        public string Population { get => population; set => population = value; }
        public string AreaInSqKm { get => areaInSqKm; set => areaInSqKm = value; }
        public string DensityPerSqKm { get => densityPerSqKm; set => densityPerSqKm = value; }
    }
}