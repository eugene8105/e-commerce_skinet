using System;

namespace API.Errors
{
    
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            // operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null.
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            // swich in c# 8
            return statusCode switch 
            {
                // case 1
                400 => "You made a bad request",
                // case 2
                401 => "Not authorized request",
                // case 3
                404 => "Resource not found",
                // case 4
                500 => "Error. Something went wrong",
                // this is default result
                _ => null
            };
        }
    }
}