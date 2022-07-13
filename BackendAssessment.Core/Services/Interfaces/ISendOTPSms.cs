using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Core.Services.Interfaces
{
    public interface ISendOTPSms
    {
        string SendOptBySms(string number, string otp);
    }
}
