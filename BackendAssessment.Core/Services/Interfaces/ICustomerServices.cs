using BackendAssessment.Infrastructure.DTOs.Requests;
using BackendAssessment.Infrastructure.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Core.Services.Interfaces
{
    public interface ICustomerServices
    {
        Task<ApiResponse<CustomerRegReponseDTO>> OnboardCustomer(CustomerRegRequestDTO request);
        Task<ApiResponse<List<BoardedResponse>>> GetAllBoardedCustomer();
    }
}
