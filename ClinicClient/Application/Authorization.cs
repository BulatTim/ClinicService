using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Clinic.DTO;
using ClinicClient.ClinicWCFService;




namespace ClinicClient
{
    class Authorization 
    {
        private readonly IClinicService _clinicServiceClient;

        public Authorization(IClinicService clinicServiceClient)
        {
            _clinicServiceClient = clinicServiceClient;
        }
        public SessionTokenInfo Authorize()
        {
            Console.WriteLine("Введите имя пользователя");
            string userName = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            string password = Console.ReadLine();
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
        
    }
}
