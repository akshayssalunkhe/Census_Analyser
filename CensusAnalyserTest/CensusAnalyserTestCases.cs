using CensusAnalyser;
using NUnit.Framework;
using static CensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        private string STATE_CENSUS_DATA_PATH = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCensusData.csv";

        private string WRONG_CSV_FILE_PATH = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\CensusData.csv";

        private string STATE_CENSUS_DATA_PATH_INCORRECT_TYPE = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCensusData.txt";

        private string STATE_CENSUS_INCORRECT_DELIMITER_FILE = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCensusData.csv";

        private string STATE_CENSUS_DATA_CSV_INCORRECT_HEADER_FILE = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCensusDataIncorrectHeader.csv";

        private string STATE_CODE_DATA_PATH = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCode.csv";

        private string WRONG_CSV_CODE_FILE_PATH = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCode.csv";

        private string STATE_CODE_DATA_PATH_INCORRECT_TYPE = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCode.txt";

        private string STATE_CODE_INCORRECT_DELIMITER_FILE = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCodeIncorrectDelimiter.csv";

        private string STATE_CODE_DATA_CSV_INCORRECT_HEADER_FILE = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\StateCodeIncorrectHeader.csv";


        static string CENSUS_DATA_HEADERS = "State,Population,AreaInSqKm,DensityPerSqKm";

        static string STATE_CODE_HEADERS = "SrNo,State Name,TIN,StateCode";


        CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();

        CSVData csvData;

        public void Setup()
        {
        }

        [Test]

        public void givenStatesCensusCSVFile_WhenNumberOfRecordsMatches_ShouldReturnTrue()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser(STATE_CENSUS_DATA_PATH, CENSUS_DATA_HEADERS);
            csvData = new CSVData(censusAnalyser.loadCensusData);
            string[] numberOfRecords = (string[])csvData();
            Assert.AreEqual(29, numberOfRecords.Length);

        }

        [Test]
        public void givenIndianStatesCensusCSVFile_WhenUnMatchNoOfRecord_ThenReturnFalse()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser(STATE_CENSUS_DATA_PATH, CENSUS_DATA_HEADERS);
            csvData = new CSVData(censusAnalyser.loadCensusData);
            string[] numberOfRecords = (string[])csvData();
            Assert.AreNotEqual(30, numberOfRecords);
        }

        [Test]
        public void givenIndiaCensusData_WithWrongFile_ShouldThrowCustomException()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser(WRONG_CSV_FILE_PATH, CENSUS_DATA_HEADERS);
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var wrongFile = Assert.Throws<CensusAnalyserException>(() => csvData());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE, wrongFile.type);

        }

        [Test]
        public void givenIncorrectIndianStatesCensusCSVFileType_WhenUnmatch_ThenThrowCustomException()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser(STATE_CENSUS_DATA_PATH_INCORRECT_TYPE, CENSUS_DATA_HEADERS);
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var incorrectType = Assert.Throws<CensusAnalyserException>(() => csvData());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, incorrectType.type);

        }


        [Test]
        public void givenIncorrectDelimiterCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser(STATE_CENSUS_INCORRECT_DELIMITER_FILE, CENSUS_DATA_HEADERS);
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var incorrectDelimiter = Assert.Throws<CensusAnalyserException>(() => csvData());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, incorrectDelimiter.type);

        }

        [Test]
        public void givenIncorrectHeaderIndianStatesCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser(STATE_CENSUS_DATA_CSV_INCORRECT_HEADER_FILE, CENSUS_DATA_HEADERS);
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var incorrectHeader = Assert.Throws<CensusAnalyserException>(() => csvData());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_HEADER, incorrectHeader.type);

        }


        [Test]
        public void givenStatesCodeCSVFile_WhenMatchNumberOfRecord_ThenReturnTrue()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser(STATE_CODE_DATA_PATH, STATE_CODE_HEADERS);
            csvData = new CSVData(censusAnalyser.loadCensusData);
            string[] numOfRecords = (string[])csvData();
            Assert.AreEqual(37, numOfRecords.Length);

        }

        [Test]
        public void givenStatesCensusCSVFile_WhenUnMatchNoOfRecord_ThenReturnFalse()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser(STATE_CODE_DATA_PATH, STATE_CODE_HEADERS);
            csvData = new CSVData(censusAnalyser.loadCensusData);
            string[] numberOfRecords = (string[])csvData();
            Assert.AreNotEqual(38, numberOfRecords);
        }

        [Test]
        public void givenStateCensusCode_WithWrongFile_ShouldThrowCustomException()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser(WRONG_CSV_CODE_FILE_PATH, STATE_CODE_HEADERS);
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var wrongFile = Assert.Throws<CensusAnalyserException>(() => csvData());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, wrongFile.type);

        }

        [Test]
        public void givenIncorrectIndianStatesCodeCSVFileType_WhenUnmatch_ThenThrowCustomException()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser(STATE_CODE_DATA_PATH_INCORRECT_TYPE, STATE_CODE_HEADERS);
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var incorrectType = Assert.Throws<CensusAnalyserException>(() => csvData());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, incorrectType.type);

        }


        [Test]
        public void givenIncorrectDelimiterCSVStateCodeFile_WhenUnmatch_ThenThrowCustomException()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser(STATE_CODE_INCORRECT_DELIMITER_FILE, STATE_CODE_HEADERS);
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var incorrectDelimiter = Assert.Throws<CensusAnalyserException>(() => csvData());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, incorrectDelimiter.type);

        }

        [Test]
        public void givenIncorrectHeaderStatesCodeCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser(STATE_CODE_DATA_CSV_INCORRECT_HEADER_FILE, STATE_CODE_HEADERS);
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var incorrectHeader = Assert.Throws<CensusAnalyserException>(() => csvData());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_HEADER, incorrectHeader.type);

        }

    }
}