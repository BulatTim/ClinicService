using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Bisuness.Services.DAL;
using Clinic.Bisuness.Services.Classes;

namespace Clinic.Bisuness.Services.Implementation
{
   public static class ValidationService
    {
       /// <summary>
       /// Checks correctness of the guid. 
       /// </summary>
       /// <param name="giud"></param>
       /// <returns></returns>
        public static bool IsValidToken(Guid giud)
        {
            return DBHelper.ExecuteWithoutGuid(context =>context.SessionToken.Find(giud) != null);
        }
    }
}
