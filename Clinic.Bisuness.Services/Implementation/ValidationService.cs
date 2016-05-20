using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Bisuness.Services.DAL;

namespace Clinic.Bisuness.Services.Implementation
{
   public class ValidationService
    {
        public bool IsValidToken(Guid giud)
        {
            SessionToken sessionToken;
            using(var db=new ClinicEntities())
            {
                sessionToken = db.SessionToken.Find(giud);
            }
            if (sessionToken != null)
                return true;
            return false;
        }
    }
}
