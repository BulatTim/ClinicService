using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.DTO;
using ClinicClient.ClinicWCFService;

namespace ClinicClient.Application
{
   public class CommonAction
    {
        private readonly IClinicService _clinicServiceClient;

        public CommonAction(IClinicService clinicServiceClient)
        {
            _clinicServiceClient = clinicServiceClient;
        }
        public void ShowAllDoctors()
        {
            List<DoctorInfo> docrotsList = _clinicServiceClient.GetAllDoctors(UserInfo.sessionTokenInfo.Guid);
            var groupList = docrotsList.GroupBy(d => d.SpecialityTitle);
            foreach (var group in groupList)
            {
                Console.WriteLine(group.Key + ":");
                foreach (var doctor in group)
                {
                    Console.WriteLine(doctor.FirstName + " " + doctor.LastName + " " + doctor.SpecialityTitle);

                }
                Console.WriteLine("_____________________________________________________________");
            }
        }
    }
}
