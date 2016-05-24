using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.DTO;

namespace Clinic.Bisuness.Services.Interfaces
{
    public interface ICommonService
    {
       List<DoctorInfo> GetAllDoctors(Guid guid);

       List<TicketInfo> GetTickets(int doctorId,DateTime date,Guid guid);
       List<PatientInfo> GetMedicalRecords(Guid guid);

       int AddMedicalRecord(PatientInfo patientInfo, Guid guid);

       bool AddTicket(TicketInfo ticketInfo, Guid guid);

       bool RemoveTicket(int ticketId, Guid guid);
    }
}
