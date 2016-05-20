using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Bisuness.Services.Interfaces;
using Clinic.Bisuness.Services.DAL;
using Clinic.DTO;

namespace Clinic.Bisuness.Services.Implementation
{
    public class CommonService : ValidationService,ICommonService
    {
        
        public IList<DoctorInfo> GetAllDoctors(Guid guid)
        {
            if (!IsValidToken(guid))
                throw new Exception("Доступ запрещен");
            IList<DoctorInfo> doctorInfoList=new List<DoctorInfo>();
            using(var db=new ClinicEntities())
            {
                IEnumerable<Doctor> doctors = db.Doctor;
                foreach(Doctor doctor in doctors)
                {

                    doctorInfoList.Add(new DoctorInfo
                    {
                        Id = doctor.Id,
                        FirstName = doctor.FirstName,
                        LastName = doctor.LastName,
                        SpecialityTitle = doctor.Speciality.Title
                    });
                }
                return doctorInfoList;
            }
            
            
        }

       
    }
}
