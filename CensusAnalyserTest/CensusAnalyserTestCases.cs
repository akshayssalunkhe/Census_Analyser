using CensusAnalyser;
using NUnit.Framework;

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


        CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
        public void Setup()
        {
        }

        [Test]

        public void givenStatesCensusCSVFile_WhenNumberOfRecordsMatches_ShouldReturnTrue()
        {
            int numberOfRecord = censusAnalyser.loadStateCSVData(STATE_CENSUS_DATA_PATH);
            Assert.AreEqual(29, numberOfRecord);
        }

        [Test]
        public void givenIndianStatesCensusCSVFile_WhenUnMatchNoOfRecord_ThenReturnFalse()
        {
            int numberOfRecords = censusAnalyser.loadStateCSVData(STATE_CENSUS_DATA_PATH);
            Assert.AreNotEqual(30, numberOfRecords);
        }

        [Test]
        public void givenIndiaCensusData_WithWrongFile_ShouldThrowCustomException()
        {
            try
            {
                censusAnalyser.loadStateCSVData(WRONG_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE, e.type);
            }

        }

        [Test]
        public void givenIncorrectIndianStatesCensusCSVFileType_WhenUnmatch_ThenThrowCustomException()
        {
            try
            {
                censusAnalyser.loadStateCSVData(STATE_CENSUS_DATA_PATH_INCORRECT_TYPE);

            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, e.type);
            }
        }


        [Test]
        public void givenIncorrectDelimiterCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            try
            {
                censusAnalyser.loadStateCSVData(STATE_CENSUS_INCORRECT_DELIMITER_FILE);

            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, e.type);
            }
        }

        [Test]
        public void givenIncorrectHeaderIndianStatesCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            try
            {
                censusAnalyser.loadStateCSVData(STATE_CENSUS_DATA_CSV_INCORRECT_HEADER_FILE);

            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_HEADER, e.type);
            }
        }
    

    [Test]
    public void givenStatesCodeCSVFile_WhenMatchNumberOfRecord_ThenReturnTrue()
    {
        int numberOfRecord = censusAnalyser.loadCSVStateCodeFile(STATE_CODE_DATA_PATH);
        Assert.AreEqual(37, numberOfRecord);
    }

    }
}