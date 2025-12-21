using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.CrossCutting.Responses
{
    public class ApiSuccessResponse<T> : ApiResponse
    {
        public string? Message { get; }
        public T? Data { get; }

        public ApiSuccessResponse(T? data, string? message = null)
        {
            Success = true;
            Data = data;
            Message = message;
        }
    }

    public class ApiSuccessResponse : ApiResponse
    {
        public string? Message { get; }
        public ApiSuccessResponse(string? message = null)
        {
            Success = true;
            Message = message;
        }
    }
}
