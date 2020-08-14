using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        public enum ExceptionType
        {
            NO_SUCH_FILE,
            NO_SUCH_FILE_TYPE,
            NO_SUCH_DELIMITER,
            NO_SUCH_HEADER
        }

        public ExceptionType type;

        public CensusAnalyserException(String message, ExceptionType type) : base(message)
        {
            this.type = type;
        }
    }
}
