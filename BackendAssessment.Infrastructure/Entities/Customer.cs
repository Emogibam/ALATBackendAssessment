using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Infrastructure.Entities
{
    public class Customer 
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string OTP { get; set; }
        [Required]
        public DateTime OPTExpiresAt { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string LGA { get; set; }
    }
}
