using BackendAssessment.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackendAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankServices _bankServices;

        public BankController(IBankServices bankServices)
        {
            _bankServices = bankServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetBanksAsync()
        {
          var result =  await _bankServices.GetbankRequest();
            return Ok(result);
        }
    }
}
