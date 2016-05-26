using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.DTO;
using Clinic.Bisuness.Services.Implementation;

namespace Clinic.Bisuness.Services.Interfaces
{
    public interface ICommonService
    {
       List<DoctorInfo> GetAllDoctors(Guid guid);


       List<TicketInfo> ShowDoctorVisits(int doctorID, DateTime date, Guid guid);
       List<TicketInfo> ShowDoctorVisits(int doctorID, DateTime beginDate, DateTime endDate, Guid guid);
       List<TicketInfo> GetPatientVisits(int patientId, Guid guid);
    }
}
