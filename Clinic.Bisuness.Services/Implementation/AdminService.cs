using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Bisuness.Services.Classes;
using Clinic.Bisuness.Services.Interfaces;
using Clinic.DTO;
using Clinic.Bisuness.Services.DAL;

namespace Clinic.Bisuness.Services.Implementation
{
   public class AdminService: IAdminService
   {
       /// <summary>
       /// Returns all doctor's specialities.
       /// </summary>
       public List<SpecialityInfo> GetSpecialities(Guid guid)
       {
           return DBHelper.Execute(context => context.Speciality.ToList()
               .Select(x => new SpecialityInfo
               { 
                   Id = x.Id, 
                   Title = x.Title 
               }).ToList(), guid);
       }


       /// <summary>
       /// Adds new doctor's speciality in database.
       /// </summary>
       public bool AddSpeciality(string title,Guid guid)
       {
           return DBHelper.Execute(context=>
            {
                context.Speciality.Add(new Speciality
               {
                    Title=title
               }
                );
            return context.SaveChanges()>0;
            },guid);
           
       }
        ///<summary>
        ///Adds new doctor in database.
        ///</summary>
       public bool AddDoctor(DoctorInfo doctorInfo, Guid guid)
       {
           return DBHelper.Execute(context =>
               {
                   var address = context.Address.Add(new Address
                         {
                             City = doctorInfo.AddressInfo.City,
                             Street = doctorInfo.AddressInfo.Street,
                             Home = doctorInfo.AddressInfo.Home,
                             HousingBody = doctorInfo.AddressInfo.HousingBody,
                             Apartament = doctorInfo.AddressInfo.Apartament
                         });
                   context.SaveChanges();
                   context.Doctor.Add(new Doctor
                       {
                           AddressId = address.Id,
                           LastName = doctorInfo.LastName,
                           FirstName = doctorInfo.FirstName,
                           Room = doctorInfo.Room,
                           SpecialityId = doctorInfo.specialityInfo.Id
                       });
                   return context.SaveChanges() > 0;
               }, guid);
       }
  
       /// <summary>
       /// Returns all doctor's visits on date
       /// </summary>
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

       /// <summary>
       /// Returns all doctor's visist on period.
       /// </summary>
       public List<TicketInfo> ShowDoctorVisits(int doctorID, DateTime beginDate, DateTime endDate, Guid guid)
       {
           return DBHelper.Execute(context=>context.Ticket.Where(t => t.DoctorId == doctorID && t.DateTime > beginDate && t.DateTime < endDate).ToList()
               .Select(x=>new TicketInfo
               {
                   DateTime=x.DateTime,
                   PatientInfo=new PatientInfo
                   {
                        FirstName=x.Patient.FirstName,
                        LastName=x.Patient.LastName
                   }
               }).ToList(),guid);
       }
       /// <summary>
       /// Returns all patient's visits to doctors.
       /// </summary>
       /// <param name="patientId"></param>
       /// <param name="guid"></param>
       /// <returns></returns>
       public List<TicketInfo> GetPatientVisits(int patientId, Guid guid)
       {
           return DBHelper.Execute(context => context.Ticket.Where(t => t.PatientId == patientId).ToList()
               .Select(x => new TicketInfo 
               { 
                    DateTime=x.DateTime,
                    DoctorInfo= new DoctorInfo
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
   }
    
}
