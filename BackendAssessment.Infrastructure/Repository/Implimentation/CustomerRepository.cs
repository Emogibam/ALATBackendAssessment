using BackendAssessment.Infrastructure.Context;
using BackendAssessment.Infrastructure.Entities;
using BackendAssessment.Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Infrastructure.Repository.Implimentation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BackendAssessmentContext _context;
        private readonly DbSet<Customer> _customer;

        public CustomerRepository(BackendAssessmentContext context)
        {
            _context = context;
            _customer = _context.Customers;
        }

        public async Task<bool> OnboardCustomerAsync(Customer customer)
        {
            await _customer.AddAsync(customer);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Customer>> GetAllOnboardedCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> FindByEmailAsync(string email)
        {
            return await _customer.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
