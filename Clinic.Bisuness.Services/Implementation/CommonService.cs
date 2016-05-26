using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Bisuness.Services.Interfaces;
using Clinic.Bisuness.Services.DAL;
using Clinic.DTO;
using Clinic.Bisuness.Services.Classes;

namespace Clinic.Bisuness.Services.Implementation
{
    public class CommonService : ICommonService
    {
        /// <summary>
        /// Gets all doctors from database.
        /// </summary>
       [HandleError(true)]
        public List<DoctorInfo> GetAllDoctors(Guid guid)
        {
            return DBHelper.Execute(context => context.Doctor.ToList()
                .Select(x => new DoctorInfo
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    specialityInfo = new SpecialityInfo
                    {
                        Title = x.Speciality.Title
                    },
                    Room = x.Room
                }).ToList(), guid);
        }


      

  

  
       /// <summary>
       /// Returns all doctor's visist on period.
       /// </summary>
       [HandleError(true)]
       public List<TicketInfo> ShowDoctorVisits(int doctorID, DateTime beginDate, DateTime endDate, Guid guid)
       {
           return DBHelper.Execute(context => context.Ticket.Where(t => t.DoctorId == doctorID && t.DateTime > beginDate && t.DateTime < endDate).ToList()
               .Select(x => new TicketInfo
               {
                   DateTime = x.DateTime,
                   PatientInfo = new PatientInfo
                   {
                       FirstName = x.Patient.FirstName,
                       LastName = x.Patient.LastName
                   }
               }).ToList(), guid);
       }
       /// <summary>
       /// Returns all patient's visits to doctors.
       /// </summary>
       /// <param name="patientId"></param>
       /// <param name="guid"></param>
       /// <returns></returns>
       [HandleError(true)]
       public List<TicketInfo> GetPatientVisits(int patientId, Guid guid)
       {
           return DBHelper.Execute(context => context.Ticket.Where(t => t.PatientId == patientId).ToList()
               .Select(x => new TicketInfo
               {
                   DateTime = x.DateTime,
                   DoctorInfo = new DoctorInfo
                   {
                       FirstName = x.Doctor.FirstName,
                       LastName = x.Doctor.LastName,
                       specialityInfo = new SpecialityInfo
                       {
                           Title = x.Doctor.Speciality.Title
                       }
                   }
               }
               ).ToList(), guid);
       }

       /// <summary>
       /// Returns all doctor's visits on date
       /// </summary>
       [HandleError(true)]
       public List<TicketInfo> ShowDoctorVisits(int doctorID, DateTime date, Guid guid)
       {
           return DBHelper.Execute(context => context.Ticket.Where(t => t.DoctorId == doctorID && t.DateTime.Year == date.Year && t.DateTime.Month == date.Month && t.DateTime.Day == date.Day).ToList()
               .Select(x => new TicketInfo
               {
                   DateTime = x.DateTime,
                   PatientInfo = new PatientInfo
                   {
                       FirstName = x.Patient.FirstName,
                       LastName = x.Patient.LastName
                   }
               }).ToList(), guid);
       }
    }
}
