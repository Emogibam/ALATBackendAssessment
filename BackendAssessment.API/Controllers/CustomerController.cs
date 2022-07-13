using BackendAssessment.Core.Services.Interfaces;
using BackendAssessment.Infrastructure.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackendAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }


        [HttpPost]
        public async Task<IActionResult> Post(CustomerRegRequestDTO customer)
        {
            var result = await _customerServices.OnboardCustomer(customer);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _customerServices.GetAllBoardedCustomer();
            return Ok(result);
        }
    }
}
