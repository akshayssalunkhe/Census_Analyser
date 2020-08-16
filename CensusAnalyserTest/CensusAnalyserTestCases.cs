using CensusAnalyser;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using static CensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        private string STATE_CENSUS_DATA_PATH = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCensusData.csv";

        private string WRONG_CSV_FILE_PATH = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\CensusData.csv";

        private string STATE_CENSUS_DATA_PATH_INCORRECT_TYPE = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCensusData.txt";

        private string STATE_CENSUS_INCORRECT_DELIMITER_FILE = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCensusDataIncorrectDelimiter.csv";

        private string STATE_CENSUS_DATA_CSV_INCORRECT_HEADER_FILE = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCensusDataIncorrectHeader.csv";

        private string STATE_CODE_DATA_PATH = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCode.csv";

        private string WRONG_CSV_CODE_FILE_PATH = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCodes.csv";

        private string STATE_CODE_DATA_PATH_INCORRECT_TYPE = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCode.txt";

        private string STATE_CODE_INCORRECT_DELIMITER_FILE = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCodeIncorrectDelimiter.csv";

        private string STATE_CODE_DATA_CSV_INCORRECT_HEADER_FILE = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCodeIncorrectHeader.csv";

        static string CENSUS_DATA_HEADERS = "State,Population,AreaInSqKm,DensityPerSqKm";

        static string STATE_CODE_HEADERS = "SrNo,StateName,TIN,StateCode";


        CSVBuilderFactory csvFactory = new CSVBuilderFactory();
        CSVData csvData;
        Dictionary<string, CensusDTO> numberOfRecords = new Dictionary<string, CensusDTO>();

        [Test]

        public void givenStatesCensusCSVFile_WhenNumberOfRecordsMatches_ShouldReturnTrue()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(censusAnalyser.loadCSVDataFile);
            numberOfRecords = (Dictionary<string, CensusDTO>)csvData(STATE_CENSUS_DATA_PATH, CENSUS_DATA_HEADERS);
            Assert.AreEqual(29, numberOfRecords.Count);

        }

        [Test]
        public void givenIndianStatesCensusCSVFile_WhenUnMatchNoOfRecord_ThenReturnFalse()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(censusAnalyser.loadCSVDataFile);
            numberOfRecords = (Dictionary < string, CensusDTO >)csvData(STATE_CENSUS_DATA_PATH, CENSUS_DATA_HEADERS);
            Assert.AreNotEqual(30, numberOfRecords.Count);

        }

        [Test]
        public void givenIndiaCensusData_WithWrongFile_ShouldThrowCustomException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(censusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<CensusAnalyserException>(() => csvData(WRONG_CSV_FILE_PATH, CENSUS_DATA_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE, result.type);

        }

        [Test]
        public void givenIncorrectIndianStatesCensusCSVFileType_WhenUnmatch_ThenThrowCustomException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(censusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<CensusAnalyserException>(() => csvData(STATE_CENSUS_DATA_PATH_INCORRECT_TYPE, CENSUS_DATA_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, result.type);

        }

        [Test]
        public void givenIncorrectDelimiterCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(censusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<CensusAnalyserException>(() => csvData(STATE_CENSUS_INCORRECT_DELIMITER_FILE, CENSUS_DATA_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, result.type);

        }

        [Test]
        public void givenIncorrectHeaderIndianStatesCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(censusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<CensusAnalyserException>(() => csvData(STATE_CENSUS_DATA_CSV_INCORRECT_HEADER_FILE, CENSUS_DATA_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_HEADER, result.type);

        }

        [Test]
        public void givenStatesCodeCSVFile_WhenMatchNumberOfRecord_ThenReturnTrue()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(censusAnalyser.loadCSVDataFile);
            numberOfRecords = (Dictionary<string, CensusDTO> )csvData(STATE_CODE_DATA_PATH, STATE_CODE_HEADERS);
            Assert.AreEqual(37, numberOfRecords.Count);
        
        }

        [Test]
        public void givenStatesCensusCSVFile_WhenUnMatchNoOfRecord_ThenReturnFalse()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(censusAnalyser.loadCSVDataFile);
            numberOfRecords = (Dictionary<string, CensusDTO>)csvData(STATE_CODE_DATA_PATH, STATE_CODE_HEADERS);
            Assert.AreNotEqual(30, numberOfRecords.Count);

        }

        [Test]
        public void givenStateCensusCode_WithWrongFile_ShouldThrowCustomException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(censusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<CensusAnalyserException>(() => csvData(WRONG_CSV_CODE_FILE_PATH, STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE, result.type);

        }

        [Test]
        public void givenIncorrectIndianStatesCodeCSVFileType_WhenUnmatch_ThenThrowCustomException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(censusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<CensusAnalyserException>(() => csvData(STATE_CODE_DATA_PATH_INCORRECT_TYPE, STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, result.type);

        }


        [Test]
        public void givenIncorrectDelimiterCSVStateCodeFile_WhenUnmatch_ThenThrowCustomException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(censusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<CensusAnalyserException>(() => csvData(STATE_CODE_INCORRECT_DELIMITER_FILE, STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, result.type);

        }

        [Test]
        public void givenIncorrectHeaderStatesCodeCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(censusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<CensusAnalyserException>(() => csvData(STATE_CODE_DATA_CSV_INCORRECT_HEADER_FILE, STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_HEADER, result.type);
        }

        
        [Test]
        public void givenCensusData_WhenSortedStateWiseAlphabetically_thenReturnSortedResult()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            string sortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(STATE_CENSUS_DATA_PATH, CENSUS_DATA_HEADERS, "state", "ASC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Andhra Pradesh", sortedData[0].state);

        }

        [Test]
        public void givenStateCodeData_WhenSortedCode_ThenReturnSortedStartResult()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            string sortedStateCodeData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(STATE_CODE_DATA_PATH, STATE_CODE_HEADERS, "stateCode","ASC").ToString();
            CSVStateCode[] sortedData = JsonConvert.DeserializeObject<CSVStateCode[]>(sortedStateCodeData);
            Assert.AreEqual("AD", sortedData[0].stateCode);

        }

        [Test]
        public void givenStateCensusData_WhenSortedByPopulationDensity_ThenShouldReturnSortedMostPopulatedResult()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            string sortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(STATE_CENSUS_DATA_PATH, CENSUS_DATA_HEADERS, "populationDensity", "ASC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Bihar", sortedData[0].state);
        }

    }
}
    