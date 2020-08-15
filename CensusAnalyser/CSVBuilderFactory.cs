using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
   public class CSVBuilderFactory
    {
        public ICSVBuilder createCSVBuilder()
        {
            return new CensusAnalyser();
        }
    }
}
