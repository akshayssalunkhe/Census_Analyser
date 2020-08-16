using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class CSVStateCode
    {
        public int srNo;
        public string stateName;
        public int tin;
        public string stateCode;

        public CSVStateCode(string srNo, string stateName, string tin, string stateCode)
        {
            this.srNo = Convert.ToInt32(srNo);
            this.stateName = stateName;
            this.tin = Convert.ToInt32(tin);
            this.stateCode = stateCode;
        }

    }
}