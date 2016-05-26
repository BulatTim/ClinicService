using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Bisuness.Services.Classes;
using Clinic.DTO;
using Clinic.Bisuness.Services.DAL;
using System.ServiceModel;
using Clinic.Bisuness.Services.Interfaces;

namespace Clinic.Bisuness.Services.Implementation
{
    public class AuthorizationService:IAuthorizationService
    {
        /// <summary>
        /// Starts new session.
        /// </summary>

        [HandleError(true)]
        public SessionTokenInfo Authorize(string loginName, string password)
        {
            return DBHelper.ExecuteWithoutGuid(context =>
            {
                var currentUser = context.User.FirstOrDefault(u => u.Name == loginName && u.Password == password);
                if (currentUser == null)
                {
                    throw new FaultException("Введены неверные имя пользователя или пароль");

                }
                var role = currentUser.Role.Title;
                var sessionToken = context.SessionToken.FirstOrDefault(u => u.DoctorId == currentUser.DoctorId);
                if (sessionToken == null)
                {
                    sessionToken = new SessionToken
                    {
                        DoctorId = currentUser.DoctorId,
                        Guid = Guid.NewGuid(),
                        CreatedDate = DateTime.Now
                    };
                    context.SessionToken.Add(sessionToken);
                    context.SaveChanges();
                }

                return new SessionTokenInfo
                {
                    DoctorId = sessionToken.DoctorId,
                    Guid = sessionToken.Guid,
                    CreatedDate = sessionToken.CreatedDate,
                    Role = role
                };
            });
        }



        /// <summary>
        /// Closes currents session.
        /// </summary>
         [HandleError(true)]
        public void LogOut(SessionTokenInfo sessionTokenInfo)
        {
            DBHelper.ExecuteWithoutGuid(context =>
            {
                var sessionToken = context.SessionToken.FirstOrDefault(s => s.Guid == sessionTokenInfo.Guid);
                context.SessionToken.Remove(sessionToken);
                context.SaveChanges();
                
            });
        }
    }
}
