using IndianCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianCensusAnalyser
{
    public class CSVAdapterFactory
    {
        public Dictionary<string,CensusDTO> LoadCsvData(CensusAnalyser.Country country,string csvFilePath,string dataHeaders)
        {
                switch (country)
                {
                    case (CensusAnalyser.Country.INDIA):
                        return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);

                    //case (CensusAnalyser.Country.US):
                    //return new USCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);

                    default:
                        throw new CensusAnalyserException("No Such Country", CensusAnalyserException.Exception.NO_SUCH_COUNTRY);
                }
        }
    }
}
