using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Infrastructure.DTOs.Responses
{
    public class ApiResponse<T>
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public string Erros { get; set; }

        public ApiResponse(int statusCode, string message, string errors)
        {
            this.Code = statusCode;
            this.Message = message;
            this.Erros = errors;
            this.Status = Code == 200 ? "success" : "failed";
        }
    }
}
