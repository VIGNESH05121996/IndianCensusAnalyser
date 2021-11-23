using IndianCensusAnalyser.DataDAO;
using IndianCensusAnalyser.DTO;
using IndianCensusAnalyser;
using System.Collections.Generic;
using System;
using NUnit.Framework;

namespace IndianCensusAnalyserTesting
{
    [TestFixture]
    public class UnitTest1
    {
        string stateCodePath = @"D:\.net\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCode.csv";
        string stateCensusPath = @"D:\.net\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCensusData.csv";
        string wrongCensusPath = @"D:\.net\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\wrongIndiaStateCode.csv";
        string wrongStateCodePath = @"D:\.net\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\WrongIndiaCode.csv";
        string wrongTypeStateCodePath = @"D:\.net\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCode.txt";
        string wrongHeaderStateCodePath = @"D:\.net\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\WrongIndiaStateCode.csv";
        string wrongHeaderStateCensusPath = @"D:\.net\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        string delimiterStateCodePath = @"D:\.net\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\DelimiterIndiaStateCode.csv";
        string delimiterStateCensusPath = @"D:\.net\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\DelimiterIndiaStateCensusData.csv";
        IndianCensusAnalyser.CSVAdapterFactory csv = null;
        //Dictionary<string, CensusDTO> stateRecords;
        Dictionary<string, CensusDTO> totalRecords;

        [SetUp]
        public void SetUp()
        {
            csv = new IndianCensusAnalyser.CSVAdapterFactory();
            //stateRecords = new Dictionary<string, CensusDTO>();
            totalRecords = new Dictionary<string, CensusDTO>();

        }

        //TC1.1 Given the correct path it should return total count from the census
        [Test]
        public void GivenStateCensusCSVShouldReturnRecords()
        {
            //stateRecords = csv.LoadCsvData(IndianCensusAnalyser.CensusAnalyser.Country.INDIA,stateCensusPath,"State,Population,AreaInSqKm,DensityPerSqKm");
            //Assert.AreEqual(29, stateRecords.Count);
        }

        //TC1.2 Given incorrect path should return file not found exception
        [Test]
        public void GivenIncorrectFileShouldThrowCustomException()
        {
            //string expected = "File Not Found";
            //try
            //{
            //    var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            //}
            //catch(CensusAnalyserException ex)
            //{
            //    Assert.AreEqual(expected, ex.Message);
            //}
        }

        //Tc1.3 Given wrong type of path should return invalid file type custom exception
        [Test]
        public void GivenWrongTypeReturnCustomException()
        {
            //try
            //{
            //    var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTpyeStateCodePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            //    Assert.AreEqual(customException.exception, CensusAnalyserException.Exception.INVALID_FILE_TYPE);
            //}
            //catch(CensusAnalyserException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        //TC1.4 Given wrong delimiter should return incorrect delimiter custom exception
        [Test]
        public void GivenWrongDelimiterReturnsCustomException()
        {
            //try
            //{
            //    var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            //    Assert.AreEqual(customException.exception, CensusAnalyserException.Exception.INCORRECT_DELIMITER);
            //}
            //catch (CensusAnalyserException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        //TC1.5 Given wrong header type should return incorrect header type custom exception
        [Test]
        public void GivenWrongHeaderReturnsCustomException()
        {
            //try
            //{
            //    var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            //    Assert.AreEqual(customException.exception, CensusAnalyserException.Exception.INCORRECT_HEADER);
            //}
            //catch (CensusAnalyserException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }


        //TC2.1 Given the correct path should return the total count from the census
        [Test]
        public void GivenStateCodeReturnCount()
        {
            totalRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodePath, "SrNo,State Name,TIN,StateCode");
            Assert.AreEqual(37, totalRecords.Count);
        }

        //TC2.2 Given incorrect path should return file not found custom exception
        [Test]
        public void GivenIncorrectPathCodeCustomException()
        {
            var stateCustomException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(stateCustomException.exception, CensusAnalyserException.Exception.FILE_NOT_FOUND);
        }

        //TC2.3 Given Wrong Type of path should return invalid file type custom exception
        [Test]
        public void GivenIncorrectPathTypeCodeReturnException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.Exception.INVALID_FILE_TYPE);
        }

        //TC2.4 Given wrong delimiter should return incorrect delimiter custom exception
        [Test]
        public void GivenWrongDelimiterStateCodeReturnsCustomException()
        {
                var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCodePath, "SrNo,State Name,TIN,StateCode"));
                Assert.AreEqual(customException.exception, CensusAnalyserException.Exception.INCORRECT_DELIMITER);
        }

        //TC2.5 Given wrong header type should return incorrect header type custom exception
        [Test]
        public void GivenWrongHeaderStateCodeReturnsCustomException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.Exception.INCORRECT_HEADER);
        }
    }
}
