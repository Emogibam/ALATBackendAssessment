using BackendAssessment.Infrastructure.Context;
using BackendAssessment.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Infrastructure.SeedData
{
    public class Seeder
    {
        private static string documentName = "Customers.json";
        private static string folderName = "Json";
        public async static Task Seed(BackendAssessmentContext dbContext)
        {
            await dbContext.Database.EnsureCreatedAsync();
            await SeedCustomer(dbContext);
        }

        private static async Task SeedCustomer(BackendAssessmentContext dbContext)
        {
            if (!dbContext.Customers.Any())
            {
                var products = SeedHelper<Customer>.GetData(documentName , folderName);
                await dbContext.Customers.AddRangeAsync(products);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
