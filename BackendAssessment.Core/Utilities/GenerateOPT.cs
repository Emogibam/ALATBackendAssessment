using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Core.Utilities
{
    public class GenerateOPT
    {
        public static string OTPGenerator()
        {
            Random random = new();
            return Convert.ToString(random.Next(100000, 999999));
        }
    }
}
