using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Clinic.DTO;
using ClinicClient.Application;
using ClinicClient.ClinicWCFService;
using ClinicClient.Classes;




namespace ClinicClient
{
    public class Authorization 
    {
        private readonly IClinicService _clinicServiceClient;

        public Authorization(IClinicService clinicServiceClient)
        {
            _clinicServiceClient = clinicServiceClient;
        }
        /// <summary>
        /// Creates new session for entering username and password.
        /// </summary>
        /// <returns></returns>
        public SessionTokenInfo Authorize()
        {
            Console.WriteLine("Введите имя пользователя");
            var userName = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            var password = Console.ReadLine();

            //string userName = "User";
            //string password = "123";

            SessionTokenInfo sessionTokenInfo=null;
            try
            {
                sessionTokenInfo = _clinicServiceClient.Authorize(userName, password);
            }
            catch (FaultException err)
            {
                Console.WriteLine(err.Message);
            }     
            return sessionTokenInfo;
        }
        /// <summary>
        /// Ends current session.
        /// </summary>
        public void LogOut()
        {
            _clinicServiceClient.LogOut(CurrentUserInfo.sessionTokenInfo);
            Environment.Exit(0);
        }
        
    }
}
