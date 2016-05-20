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

        
    }
}
