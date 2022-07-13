using BackendAssessment.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Infrastructure.Context
{
    public class BackendAssessmentContext : DbContext
    {
        
        public BackendAssessmentContext(DbContextOptions<BackendAssessmentContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        
    }

}
