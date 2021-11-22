﻿using IndianCensusAnalyser.DataDAO;
using IndianCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianCensusAnalyser
{
    public class IndianCensusAdapter:CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> datamap;
        public Dictionary<string,CensusDTO> LoadCensusData(string csvFilePath,string dataHeaders)
        {
            datamap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeaders);
            foreach(string data in censusData.Skip(1))
            {
                if(!data.Contains(","))
                {
                    throw new CensusAnalyserException("FIle Containers Wrong Delimiter", CensusAnalyserException.Exception.INCORRECT_DELIMITER);
                }
                string[] coloumn = data.Split(",");
                if (csvFilePath.Contains("IndianStateCode.csv"))
                    datamap.Add(coloumn[1], new CensusDTO(new StateCodeDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
                if (csvFilePath.Contains("IndianStateCensusData.csv"))
                    datamap.Add(coloumn[1], new CensusDTO(new StateCodeDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
            }
            return datamap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
