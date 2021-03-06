using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianCensusAnalyser
{
    public class CensusAnalyserException:Exception
    {
        public Exception exception;
        public enum Exception
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, INCORRECT_HEADER,
            NO_SUCH_COUNTRY,
            INCORRECT_DELIMITER
        }

        public CensusAnalyserException(string message,Exception exception):base(message)
        {
            this.exception = exception;
        }
    }
}
