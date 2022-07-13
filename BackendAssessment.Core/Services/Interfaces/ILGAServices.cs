using BackendAssessment.Infrastructure.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Core.Services.Interfaces
{
    public interface ILGAServices
    {
        bool VerifyLGAAsync(string state, string lga);
    }
}
