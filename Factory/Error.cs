using System;
namespace Factory
{
    public class Error:Exception 
    {
        public override  string Message { get; }
        public string ExceptionMessage { get; set; }
        public string ExceptionType { get; set; }
        public override  string StackTrace { get;  }
    }
}
