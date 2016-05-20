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
       IList<DoctorInfo> GetAllDoctors(Guid guid);
    }
}
