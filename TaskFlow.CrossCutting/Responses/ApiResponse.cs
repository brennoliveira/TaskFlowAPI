using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.CrossCutting.Responses
{
    public abstract class ApiResponse
    {
        public bool Success { get; set; }
    }
}
