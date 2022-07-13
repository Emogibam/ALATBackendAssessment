using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Infrastructure.DTOs.Requests
{
    public class LGAVerificationRequest
    {
        public string State { get; set; }
        public string LGA { get; set; }
    }
}
