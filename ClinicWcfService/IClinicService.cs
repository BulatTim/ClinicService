using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Clinic.DTO;

namespace ClinicWcfService
{
    [ServiceContract]
    public interface IClinicService
    {
        [OperationContract]
        SessionTokenInfo Authorize(string userName, string password);

        [OperationContract]
        IList<DoctorInfo> GetAllDoctors(Guid guid);

        [OperationContract]
        void LogOut(SessionTokenInfo sessionTokenInfo);

        [OperationContract]
        IList<TicketInfo> GetTickets(int doctorId, DateTime date,Guid guid);

        [OperationContract]
        IList<PatientInfo> GetMedicalRecords(Guid guid);

        [OperationContract]
        int AddMedicalRecord(PatientInfo patientInfo, Guid guid);
        
        [OperationContract]
        bool AddTicket(TicketInfo ticketInfo, Guid guid);

        [OperationContract]
        bool RemoveTicket(int ticketId, Guid guid);
        [OperationContract]
        List<SpecialityInfo> GetSpecialities(Guid guid);

        [OperationContract]
        bool AddSpeciality(string title, Guid guid);
        [OperationContract]
        bool AddDoctor(DoctorInfo doctorInfo, Guid guid);
        [OperationContract]
        List<TicketInfo> GetDoctorVisits(int doctorID, DateTime date, Guid guid);
        [OperationContract]
        List<TicketInfo> GetDoctorVisitsByPeriod(int doctorID, DateTime beginDate, DateTime endDate, Guid guid);

        [OperationContract]
        List<TicketInfo> GetPatientVisits(int patientId, Guid guid);
        [OperationContract]
        int SetReservation(TicketInfo ticketInfo, Guid guid);
        [OperationContract]
        void AbortReservation(int ticketId);
    }
}
