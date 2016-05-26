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
       /// 
       [HandleError(true)]
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
       /// 
       [HandleError(true)]
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
       [HandleError(true)]
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
  



   }
    
}
