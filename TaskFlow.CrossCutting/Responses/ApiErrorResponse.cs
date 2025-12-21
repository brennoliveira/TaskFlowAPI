using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.CrossCutting.Responses
{
    public class ApiErrorResponse : ApiResponse
    {
        public string ErrorMessage { get; }
        
        public ApiErrorResponse(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }
    }
}
