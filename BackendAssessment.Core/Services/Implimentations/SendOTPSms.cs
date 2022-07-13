using BackendAssessment.Core.Services.Interfaces;
using BackendAssessment.Core.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace BackendAssessment.Core.Services.Implimentations
{
    public class SendOTPSms : ISendOTPSms
    {
        private readonly IOptions<SMSConfiguration> _configuration;

        public SendOTPSms(IOptions<SMSConfiguration> configuration)
        {
            _configuration = configuration;
        }
        public string SendOptBySms(string number, string otp)
        {
            var result = _configuration.Value;
            string editedNumber = number.Substring(1, 10);
            var accountSid = result.SID; //Environment.GetEnvironmentVariable("ACcbe958b5caac5c398aa22256269d9110");
            string authToken = result.Token; //Environment.GetEnvironmentVariable("1aa743526cbf1786141785776a484b2a");

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: $"Your OTP is: {otp}, \n " +
                $" It expires in 5 minutes.",
                from: new Twilio.Types.PhoneNumber(result.PhoneNumber),
                to: new Twilio.Types.PhoneNumber("+234" + editedNumber)
            );

            return "success";
            
        }

    }
}
