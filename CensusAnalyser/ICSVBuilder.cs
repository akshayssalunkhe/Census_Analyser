using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public interface ICSVBuilder
    {
        object loadCSVDataFile(string csvFilePath, string headers);
    }
}