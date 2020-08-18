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

        private string US_CENSUS_DATA_CSV_FILE_PATH = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\USCensusData.csv";

        private string US_CENSUS_DATA_CSV_FILE_INCORRECT_PATH = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\USCensusDataincorrect.csv";

        private string US_CENSUS_DATA_CSV_INCORRECT_FILE_TYPE = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\USCensusData.txt";

        private string US_CENSUS_DATA_CSV_INCORRECT_DELIMITER = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\USCensusDataIncorrectDelimiter.csv";

        private string US_CENSUS_DATA_CSV_INCORRECT_HEADER = @"C:\Users\de\source\repos\CensusAnalyser\CensusAnalyserTest\resource\USCensusDataIncorrectHeader.csv";

        private string CENSUS_DATA_HEADERS = "State,Population,AreaInSqKm,DensityPerSqKm";

        private string STATE_CODE_HEADERS = "SrNo,StateName,TIN,StateCode";

        private string US_CENSUS_HEADER = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";



        private CensusAnalyser.CensusAnalyser censusAnalyser;
        private Dictionary<string, CensusDTO> numberOfRecords = new Dictionary<string, CensusDTO>();
        private Dictionary<string, CensusDTO> totalRecords = new Dictionary<string, CensusDTO>();

        [SetUp]
        public void SetUp()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser();
            this.numberOfRecords = new Dictionary<string, CensusDTO>();
            this.totalRecords = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianStatesCensusCSVFile_WhenMatchNoOfRecord_ThenShouldReturnTrue()
        {
            this.numberOfRecords = censusAnalyser.loadCSVDataFile(Country.INDIA, STATE_CENSUS_DATA_PATH, CENSUS_DATA_HEADERS);
            this.totalRecords = censusAnalyser.loadCSVDataFile(Country.INDIA, STATE_CODE_DATA_PATH, STATE_CODE_HEADERS);
            Assert.AreEqual(29, this.numberOfRecords.Count);
            Assert.AreEqual(37, this.totalRecords.Count);
        }

        [Test]
        public void GivenIncorrectIndianStatesCensusCSVFile_WhenUnmatch_ThenShouldThrowCustomException()
        {
            var censusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVDataFile(Country.INDIA, WRONG_CSV_FILE_PATH, CENSUS_DATA_HEADERS));
            var codeResult = Assert.Throws<CensusAnalyserException>(() => this.censusAnalyser.loadCSVDataFile(Country.INDIA, WRONG_CSV_CODE_FILE_PATH, STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE, censusResult.type);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE, codeResult.type);
        }

        [Test]
        public void GivenIncorrectIndianStatesCensusCSVFileType_WhenUnmatch_ThenShouldThrowCustomException()
        {
            var censusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVDataFile(Country.INDIA, STATE_CENSUS_DATA_PATH_INCORRECT_TYPE, CENSUS_DATA_HEADERS));
            var codeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVDataFile(Country.INDIA, STATE_CODE_DATA_PATH_INCORRECT_TYPE, STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, censusResult.type);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, codeResult.type);
        }

        [Test]
        public void GivenIncorrectDelimiterIndianStatesCensusCSVFile_WhenUnmatch_ThenShouldThrowCustomException()
        {
            var censusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVDataFile(Country.INDIA, STATE_CENSUS_INCORRECT_DELIMITER_FILE, CENSUS_DATA_HEADERS));
            var codeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVDataFile(Country.INDIA, STATE_CODE_INCORRECT_DELIMITER_FILE, STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, censusResult.type);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, codeResult.type);
        }

        [Test]
        public void GivenIncorrectHeaderIndianStatesCensusCSVFile_WhenUnmatch_ThenShouldThrowCustomException()
        {
            var censusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVDataFile(Country.INDIA, this.STATE_CENSUS_DATA_CSV_INCORRECT_HEADER_FILE, CENSUS_DATA_HEADERS));
            var codeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVDataFile(Country.INDIA, STATE_CODE_DATA_CSV_INCORRECT_HEADER_FILE, STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_HEADER, censusResult.type);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_HEADER, codeResult.type);
        }

        [Test]
        public void GivenIndianStatesCodeCSVFile_WhenMatchNoOfRecord_ThenShouldReturnTrue()
        {
            this.numberOfRecords = censusAnalyser.loadCSVDataFile(Country.INDIA, STATE_CODE_DATA_PATH, STATE_CODE_HEADERS);
            Assert.AreEqual(37, this.numberOfRecords.Count);
        }

        [Test]
        public void GivenIncorrectIndianStatesCodeCSVFile_WhenUnmatch_ThenShouldThrowCustomException()
        {
            var result = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVDataFile(Country.INDIA, WRONG_CSV_CODE_FILE_PATH, STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE, result.type);
        }

        [Test]
        public void GivenIncorrectIndianStatesCodeCSVFileType_WhenUnmatch_ThenShouldThrowCustomException()
        {
            var result = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVDataFile(Country.INDIA, STATE_CODE_DATA_PATH_INCORRECT_TYPE, STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, result.type);
        }

        [Test]
        public void GivenIncorrectDelimiterIndianStatesCodeCSVFile_WhenUnmatch_ThenShouldThrowCustomException()
        {
            var result = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVDataFile(Country.INDIA, STATE_CODE_INCORRECT_DELIMITER_FILE, STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, result.type);
        }

        [Test]
        public void GivenIncorrectHeaderIndianStatesCodeCSVFile_WhenUnmatch_ThenShouldThrowCustomException()
        {
            var result = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVDataFile(Country.INDIA, STATE_CODE_DATA_CSV_INCORRECT_HEADER_FILE, STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_HEADER, result.type);
        }

        [Test]
        public void GivenIndianCensusData_WhenSortedState_ThenShouldReturnSortedStartResult()
        {
            string sortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, this.STATE_CENSUS_DATA_PATH, CENSUS_DATA_HEADERS, "state", "ASC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Andhra Pradesh", sortedData[0].state);
        }

        [Test]
        public void GivenIndianCensusData_WhenSortedState_ThenShouldReturnSortedLastResult()
        {
            string sortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, STATE_CENSUS_DATA_PATH, CENSUS_DATA_HEADERS, "state", "DESC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("West Bengal", sortedData[0].state);
        }

        [Test]
        public void GivenStateCodeData_WhenSortedCode_ThenShouldReturnSortedStartResult()
        {
            string sortedStateCodeData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, this.STATE_CODE_DATA_PATH, STATE_CODE_HEADERS, "stateCode", "ASC").ToString();
            CSVStateCode[] sortedData = JsonConvert.DeserializeObject<CSVStateCode[]>(sortedStateCodeData);
            Assert.AreEqual("AD", sortedData[0].stateCode);
        }

        [Test]
        public void GivenStateCodeData_WhenSortedCode_ThenShouldReturnSortedLastResult()
        {
            string sortedStateCodeData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, STATE_CODE_DATA_PATH, STATE_CODE_HEADERS, "stateCode", "DESC").ToString();
            CSVStateCode[] sortedData = JsonConvert.DeserializeObject<CSVStateCode[]>(sortedStateCodeData);
            Assert.AreEqual("WB", sortedData[0].stateCode);
        }

        [Test]
        public void GivenStateCensusData_WhenSortedByPopulation_ThenShouldReturnSortedMostPopulatedResult()
        {
            string sortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, STATE_CENSUS_DATA_PATH, CENSUS_DATA_HEADERS, "population", "ASC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Uttar Pradesh", sortedData[^1].state);
        }

        [Test]
        public void GivenStateCensusData_WhenSortedByPopulation_ThenShouldReturnSortedLeastPopulatedResult()
        {
            string sortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, STATE_CENSUS_DATA_PATH, CENSUS_DATA_HEADERS, "population", "DESC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Sikkim", sortedData[^1].state);
        }

        [Test]
        public void GivenStateCensusData_WhenSortedByPopulationDensity_ThenShouldReturnSortedMostPopulatedDensityResult()
        {
            string sortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, STATE_CENSUS_DATA_PATH, CENSUS_DATA_HEADERS, "populationDensity", "ASC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Bihar", sortedData[^1].state);
        }

        [Test]
        public void GivenStateCensusData_WhenSortedByPopulationDensity_ThenShouldReturnSortedLeastPopulatedDensityResult()
        {
            string sortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, STATE_CENSUS_DATA_PATH, CENSUS_DATA_HEADERS, "populationDensity", "DESC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Arunachal Pradesh", sortedData[^1].state);
        }

        [Test]
        public void GivenStateCensusData_WhenSortedByArea_ThenShouldReturnSortedMostAreaResult()
        {
            string sortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, STATE_CENSUS_DATA_PATH, CENSUS_DATA_HEADERS, "area", "ASC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Rajasthan", sortedData[^1].state);
        }

        [Test]
        public void GivenStateCensusData_WhenSortedByArea_ThenShouldReturnSortedLeastAreaResult()
        {
            string sortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, STATE_CENSUS_DATA_PATH, CENSUS_DATA_HEADERS, "area", "DESC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Arunachal Pradesh", sortedData[^1].state);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenUnMatchNumberOfRecord_ThenShouldReturnFalse()
        {
            this.numberOfRecords = censusAnalyser.loadCSVDataFile(Country.US, this.US_CENSUS_DATA_CSV_FILE_PATH, this.US_CENSUS_HEADER);
            Assert.AreNotEqual(51, this.numberOfRecords.Count);
        }

        [Test]
        public void GivenIncorrectUSCensusCSVFile_WhenUnmatch_ThenShouldThrowCustomException()
        {
            var result = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVDataFile(Country.US, this.US_CENSUS_DATA_CSV_FILE_INCORRECT_PATH, this.US_CENSUS_HEADER));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE, result.type);
        }

        [Test]
        public void GivenIncorrectUSCensusCSVFileType_WhenUnmatch_ThenShouldThrowCustomException()
        {
            var result = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVDataFile(Country.US, this.US_CENSUS_DATA_CSV_INCORRECT_FILE_TYPE, this.US_CENSUS_HEADER));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, result.type);
        }
        [Test]
        public void GivenIncorrectDelimiterUSCensusCSVFile_WhenUnmatch_ThenShouldThrowCustomException()
        {
            var result = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVDataFile(Country.US, this.US_CENSUS_DATA_CSV_INCORRECT_DELIMITER, this.US_CENSUS_HEADER));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, result.type);
        }

        [Test]
        public void GivenIncorrectHeaderUSCensusCSVFile_WhenUnmatch_ThenShouldThrowCustomException()
        {
            var result = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVDataFile(Country.US, this.US_CENSUS_DATA_CSV_INCORRECT_HEADER, this.US_CENSUS_HEADER));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_HEADER, result.type);
        }

        [Test]
        public void GivenUSCensusData_WhenSortedByPopulation_ThenShouldReturnSortedMostPopulatedResult()
        {
            string sortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.US, this.US_CENSUS_DATA_CSV_FILE_PATH, this.US_CENSUS_HEADER, "population", "ASC").ToString();
            CSVUSCensus[] sortedData = JsonConvert.DeserializeObject<CSVUSCensus[]>(sortedStateCensusData);
            Assert.AreEqual("California", sortedData[^1].stateName);
        }

        [Test]
        public void GivenUSCensusData_WhenSortedByPopulation_ThenShouldReturnSortedLeastPopulatedResult()
        {
            string sortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.US, this.US_CENSUS_DATA_CSV_FILE_PATH, this.US_CENSUS_HEADER, "population", "DESC").ToString();
            CSVUSCensus[] sortedData = JsonConvert.DeserializeObject<CSVUSCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Wyoming", sortedData[^1].stateName);
        }

        [Test]
        public void GivenUSCensusData_WhenSortedByPopulationDensity_ThenShouldReturnSortedMostDensedResult()
        {
            string sortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.US, this.US_CENSUS_DATA_CSV_FILE_PATH, this.US_CENSUS_HEADER, "usPopulationDensity", "ASC").ToString();
            CSVUSCensus[] sortedData = JsonConvert.DeserializeObject<CSVUSCensus[]>(sortedStateCensusData);
            Assert.AreEqual("District of Columbia", sortedData[^1].stateName);
        }

        [Test]
        public void GivenUSCensusData_WhenSortedByPopulationDensity_ThenReturnSortedLeastDensedResult()
        {
            string sortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.US, this.US_CENSUS_DATA_CSV_FILE_PATH, this.US_CENSUS_HEADER, "usPopulationDensity", "DESC").ToString();
            CSVUSCensus[] sortedData = JsonConvert.DeserializeObject<CSVUSCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Alaska", sortedData[^1].stateName);
        }

        [Test]
        public void GivenUSCensusData_WhenSortedByPopulationDensity_ThenReturnSortedLargeAreaResult()
        {
            string sortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.US, this.US_CENSUS_DATA_CSV_FILE_PATH, this.US_CENSUS_HEADER, "totalArea", "ASC").ToString();
            CSVUSCensus[] sortedData = JsonConvert.DeserializeObject<CSVUSCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Alaska", sortedData[^1].stateName);
        }

        [Test]
        public void GivenUSCensusData_WhenSortedByPopulationDensity_ThenReturnSortedSmallAreaResult()
        {
            string sortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.US, this.US_CENSUS_DATA_CSV_FILE_PATH, this.US_CENSUS_HEADER, "totalArea", "DESC").ToString();
            CSVUSCensus[] sortedData = JsonConvert.DeserializeObject<CSVUSCensus[]>(sortedStateCensusData);
            Assert.AreEqual("District of Columbia", sortedData[^1].stateName);
        }

        [Test]
        public void GivenTheUSAndIndiaCensusData_WhenSortedOnPopulation_ThenShouldReturnMostPopulousStateWithDensity()
        {
            string indianSortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, STATE_CENSUS_DATA_PATH, CENSUS_DATA_HEADERS, "populationDensity", "ASC").ToString();
            CSVStateCensus[] indianSortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(indianSortedStateCensusData);

            string usSortedStateCensusData = censusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.US, this.US_CENSUS_DATA_CSV_FILE_PATH, this.US_CENSUS_HEADER, "usPopulationDensity", "ASC").ToString();
            CSVUSCensus[] usSortedData = JsonConvert.DeserializeObject<CSVUSCensus[]>(usSortedStateCensusData);

            Assert.AreEqual(true, indianSortedData[^1].densityPerSqKm.CompareTo((long)usSortedData[^1].populationDensity) < 0);

        }
    }
}    