using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.DTO;
using Clinic.Bisuness.Services.DAL;
using System.ServiceModel;
using Clinic.Bisuness.Services.Interfaces;

namespace Clinic.Bisuness.Services.Implementation
{
    public class AuthorizationService:IAuthorizationService
    {
        public SessionTokenInfo Authorize(string loginName, string password)
        {
            using (var db = new ClinicEntities())
            {
                var currentUser = db.User.FirstOrDefault(u => u.Name == loginName && u.Password == password);
                if (currentUser == null)
                {
                    throw new FaultException("Введены неверные имя пользователя или пароль");
                    
                }
                string role = currentUser.Role.Title;
                SessionToken sessionToken = db.SessionToken.FirstOrDefault(u => u.DoctorId == currentUser.DoctorId);
                if (sessionToken == null)
                {
                    sessionToken = new SessionToken { DoctorId = currentUser.DoctorId, Guid = Guid.NewGuid(), CreatedDate = DateTime.Now };
                    db.SessionToken.Add(sessionToken);
                    db.SaveChanges();
                }

                return new SessionTokenInfo
                {
                    DoctorId = sessionToken.DoctorId,
                    Guid = sessionToken.Guid,
                    CreatedDate = sessionToken.CreatedDate,
                    Role = role
                };
            }
        }


    }
}
