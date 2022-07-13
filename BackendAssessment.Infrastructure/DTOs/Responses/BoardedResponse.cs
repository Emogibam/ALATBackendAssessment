using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Infrastructure.DTOs.Responses
{
    public class BoardedResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string OTP { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }
    }
}
