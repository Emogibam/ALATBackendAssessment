using BackendAssessment.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Infrastructure.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<bool> OnboardCustomerAsync(Customer customer);
        Task<IEnumerable<Customer>> GetAllOnboardedCustomersAsync();
        Task<Customer> FindByEmailAsync(string email);
    }
}
