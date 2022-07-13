using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Infrastructure.DTOs.Requests
{
    public class CustomerRegRequestDTO
    {

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string State { get; set; }

        public string LGA { get; set; }

    }
}
