using AutoMapper;
using BackendAssessment.Core.Services.Interfaces;
using BackendAssessment.Core.Utilities;
using BackendAssessment.Infrastructure.DTOs.Requests;
using BackendAssessment.Infrastructure.DTOs.Responses;
using BackendAssessment.Infrastructure.Entities;
using BackendAssessment.Infrastructure.Repository.Implimentation;
using BackendAssessment.Infrastructure.Repository.Interface;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Core.Services.Implimentations
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ILGAServices _iLGAServices;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOptions<SMSConfiguration> _configuration;
        private readonly Mock<ISendOTPSms> _sendOTPSms;

        public CustomerServices(ILGAServices iLGAServices, IMapper mapper, ICustomerRepository customerRepository, IOptions<SMSConfiguration> configuration)
        {
            _iLGAServices = iLGAServices;
            _mapper = mapper;
            _customerRepository = customerRepository;
            _configuration = configuration;
            _sendOTPSms = new Mock<ISendOTPSms>();
        }

        public async Task<ApiResponse<CustomerRegReponseDTO>> OnboardCustomer(CustomerRegRequestDTO request)
        {
            var existingCustomer = _customerRepository.FindByEmailAsync(request.Email);
            if (existingCustomer == null)
            {
                return new ApiResponse<CustomerRegReponseDTO>((int)HttpStatusCode.BadRequest, "failed", $"{request.Email} already exist");
            }

            //var lgaToVerify = _mapper.Map<LGAVerificationRequest>(request.Location);
            var verifyLGA = _iLGAServices.VerifyLGAAsync(request.State, request.LGA);

            if (verifyLGA)
            {
                using (var transaction = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeAsyncFlowOption.Enabled))
                {
                    DateTime dateTime = new DateTime();
                    string opt = GenerateOPT.OTPGenerator();
                    var customer = _mapper.Map<Customer>(request);
                    customer.Id = new Guid();
                    customer.OTP = opt;
                    customer.OPTExpiresAt = dateTime.AddMinutes(5);
                    customer.Password = HashPassword.ComputeSha256Hash(request.Password);

                    //
                    var smsResponse = _sendOTPSms.Setup(x => x.SendOptBySms(customer.PhoneNumber, opt)).Returns("success");

                    //

                    bool isCumstomerOnboard = await _customerRepository.OnboardCustomerAsync(customer);

                    if (isCumstomerOnboard)
                    {
                        transaction.Complete();
                        return new ApiResponse<CustomerRegReponseDTO>((int)HttpStatusCode.OK, $"{request.Email} has been onboarded", "")
                        {
                            Data = _mapper.Map<CustomerRegReponseDTO>(customer)
                        };
                    }
                    else
                    {
                        return new ApiResponse<CustomerRegReponseDTO>((int)HttpStatusCode.BadRequest, "failed", $"{request.Email} has not been onboarded");
                    }
                }
            }
            else
            {
                return new ApiResponse<CustomerRegReponseDTO>((int)HttpStatusCode.BadRequest, "failed", $" Customer with {request.Email} has no valid State and LGA");
            }
        }


        public async Task<ApiResponse<List<BoardedResponse>>> GetAllBoardedCustomer()
        {
            var customers = await _customerRepository.GetAllOnboardedCustomersAsync();
            if (customers != null)
            {
                return new ApiResponse<List<BoardedResponse>>((int)HttpStatusCode.OK, "success", "")
                {
                    Data =  _mapper.Map<List<BoardedResponse>>(customers)
                };
            }



            return new ApiResponse<List<BoardedResponse>>((int)HttpStatusCode.BadRequest, "failed", "No customers found");

        }
    }
}
