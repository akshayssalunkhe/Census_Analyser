namespace CensusAnalyser
{
    public class CSVStateCode
    {
        private int srNo;
        private string stateName;
        private int tin;
        private string stateCode;

        public int SrNo { get => srNo; set => srNo = value; }
        public string StateName { get => stateName; set => stateName = value; }
        public int TIN { get => tin; set => tin = value; }
        public string StateCode { get => stateCode; set => stateCode = value; }
    }
}