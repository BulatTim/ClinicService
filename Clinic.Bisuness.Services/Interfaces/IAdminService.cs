using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.DTO;

namespace Clinic.Bisuness.Services.Interfaces
{
    public interface IAdminService
    {
        List<SpecialityInfo> GetSpecialities(Guid guid);

        bool AddSpeciality(string title,Guid guid);
        bool AddDoctor(DoctorInfo doctorInfo, Guid guid);

        List<TicketInfo> ShowDoctorVisits(int doctorID, DateTime date, Guid guid);
        List<TicketInfo> ShowDoctorVisits(int doctorID, DateTime beginDate, DateTime endDate, Guid guid);
        List<TicketInfo> GetPatientVisits(int patientId, Guid guid);
    }
}
