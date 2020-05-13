using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Exceptions
{
    public class EmptyorNullNameException : Exception
    {
        public int Code { get { return 406; } }

        public EmptyorNullNameException(string message) : base(message)
        {

        }
    }
    public class EmptyOrNullTypeException : Exception
    {
        public int Code { get { return 406; } }

        public EmptyOrNullTypeException(string message) : base(message)
        {

        }
    }
    public class StockBetweenException : Exception
    {
        public int Code { get { return 406; } }

        public StockBetweenException(string message) : base(message)
        {

        }
    }
    public class NameLengthException : Exception
    {
        public int Code { get { return 411; } }

        public NameLengthException(string message) : base(message)
        {

        }
    }
    public class CodeNullorEmptyException : Exception
    {
        public int Code { get { return 400; } }

        public CodeNullorEmptyException(string message) : base(message)
        {

        }
    }
    public class NotFoundCodeException : Exception
    {
        public int Code { get { return 404; } }

        public NotFoundCodeException(string message) : base(message)
        {

        }
    }
    public class InvalidTypeException : Exception
    {
        public int Code { get { return 404; } }

        public InvalidTypeException(string message) : base(message)
        {

        }
    }

}
