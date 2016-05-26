using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Bisuness.Services.Classes;
using Clinic.Bisuness.Services.DAL;
using Clinic.Bisuness.Services.Interfaces;
using Clinic.DTO;


namespace Clinic.Bisuness.Services.Implementation
{
   public class ReceptionService:IReceptionService
    {
        /// <summary>
        /// Returns tickets list for entering doctor
        /// </summary>
        [HandleError(true)]
        public List<TicketInfo> GetTickets(int doctorId, DateTime date, Guid guid)
        {
            return DBHelper.Execute(context =>
            {
                var freeTicketsListInfo = new List<TicketInfo>();
                for (double d = 8; d < 20; d += 0.5)
                {

                    freeTicketsListInfo.Add(new TicketInfo { DoctorInfo = new DoctorInfo { Id = doctorId }, DateTime = new DateTime(date.Year, date.Month, date.Day, (int)Math.Floor(d), (d - Math.Floor(d) == 0 ? 0 : 30), 0) });
                }
                var reservedTicketsList = context.Ticket.Where(t => t.DoctorId == doctorId && t.DateTime.Year == date.Year
                   && t.DateTime.Month == date.Month && t.DateTime.Day == date.Day).ToList()
                   .Select(x => new TicketInfo
                   {
                       DoctorInfo = new DoctorInfo
                       {
                           Id = x.DoctorId
                       },
                       DateTime = x.DateTime,
                       PatientInfo = new PatientInfo
                       {
                           Id = x.PatientId,
                           FirstName = x.Patient.FirstName,
                           LastName = x.Patient.LastName
                       }
                   }).ToList();
                return freeTicketsListInfo.Except(reservedTicketsList, new TicketEqualityComparer()).Union(reservedTicketsList).OrderBy(x => x.DateTime).ToList();
            }, guid);


        }

        /// <summary>
        /// Returns all medical records from database.
        /// </summary>
        [HandleError(true)]
        public List<PatientInfo> GetMedicalRecords(Guid guid)
        {

            return DBHelper.Execute(context => context.Patient.ToList()
                .Select(x => new PatientInfo
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Birthdate = x.Birthdate,
                    Address = new AddressInfo
                    {
                        Id = x.Address.Id,
                        City = x.Address.City,
                        Street = x.Address.Street,
                        Home = x.Address.Home,
                        HousingBody = x.Address.HousingBody,
                        Apartament = x.Address.Apartament
                    }
                }).ToList(), guid);
        }

        /// <summary>
        /// Adds new medical record in database.
        /// </summary>
        [HandleError(true)]
        public int AddMedicalRecord(PatientInfo patientInfo, Guid guid)
        {
            return DBHelper.Execute(context =>
            {
                var existingPatient = context.Patient.FirstOrDefault(p => p.LastName == patientInfo.LastName
                 && p.FirstName == patientInfo.FirstName
                 && p.Birthdate == patientInfo.Birthdate
                 && p.Address.City == patientInfo.Address.City && p.Address.Street == patientInfo.Address.Street && p.Address.Home == patientInfo.Address.Home
                 && p.Address.HousingBody == patientInfo.Address.HousingBody && p.Address.Apartament == patientInfo.Address.Apartament);
                if (existingPatient != null)
                {
                    return 0;
                }
                var address = context.Address.Add(new Address
                {
                    City = patientInfo.Address.City,
                    Street = patientInfo.Address.Street,
                    Home = patientInfo.Address.Home,
                    HousingBody = patientInfo.Address.HousingBody,
                    Apartament = patientInfo.Address.Apartament
                });
                context.SaveChanges();
                var patient = context.Patient.Add(new Patient
                {
                    AddressId = address.Id,
                    FirstName = patientInfo.FirstName,
                    LastName = patientInfo.LastName,
                    Birthdate = patientInfo.Birthdate
                });
                return patient.Id;
            }, guid);
        }

        /// <summary>
        /// Adds new ticket in database.
        /// </summary>
        [HandleError(true)]
        public bool AddTicket(TicketInfo ticketInfo, Guid guid)
        {
            return DBHelper.Execute(context =>
            {
                context.Ticket.Add(new Ticket
                {
                    DoctorId = ticketInfo.DoctorInfo.Id,
                    DateTime = ticketInfo.DateTime,
                    PatientId = ticketInfo.PatientInfo.Id
                });
                return context.SaveChanges() > 0;
            }, guid);

        }
        /// <summary>
        /// Deletes ticket from database.
        /// </summary>
        [HandleError(true)]
        public bool RemoveTicket(int ticketId, Guid guid)
        {
            return DBHelper.Execute(context =>
            {
                var ticket = context.Ticket.Find(ticketId);
                context.Ticket.Remove(ticket);
                return context.SaveChanges() > 0;
            }, guid);
        }
    }
}
