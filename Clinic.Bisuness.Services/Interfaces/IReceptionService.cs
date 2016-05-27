using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.DTO;

namespace Clinic.Bisuness.Services.Interfaces
{
    public interface IReceptionService
    {
        List<TicketInfo> GetTickets(int doctorId, DateTime date, Guid guid,double timeout);
        List<PatientInfo> GetMedicalRecords(Guid guid);

        int AddMedicalRecord(PatientInfo patientInfo, Guid guid);

        bool AddTicket(TicketInfo ticketInfo, Guid guid);

        bool RemoveTicket(int ticketId, Guid guid);

        int SetReservation(TicketInfo ticketInfo, Guid guid);
        void AbortReservation(int ticketId);
    }
}
