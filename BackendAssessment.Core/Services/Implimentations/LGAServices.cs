using BackendAssessment.Core.Services.Interfaces;
using BackendAssessment.Infrastructure.DTOs.Requests;
using BackendAssessment.Infrastructure.Entities.JsonEntities;
using BackendAssessment.Infrastructure.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Core.Services.Implimentations
{
    public class LGAServices : ILGAServices
    {
        private static string documentName = "StateWithLGA.json";
        private static string folderName = "LGADataBase";



        public bool VerifyLGAAsync(string state, string lga)
        {
            var lgas =  SeedHelper<StatesLGA>.GetData(documentName, folderName);

            foreach (var area in lgas)
            {
                if(area.State.ToLower() == state.ToLower() && area.LGA.ToLower() == lga.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
