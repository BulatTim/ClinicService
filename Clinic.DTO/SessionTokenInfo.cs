using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Clinic.DTO
{
    [DataContract]
   public class SessionTokenInfo
    {
        [DataMember]
        public int DoctorId { get; set; }
        [DataMember]
        public System.Guid Guid { get; set; }
        [DataMember]
        public System.DateTime CreatedDate { get; set; }
        [DataMember]
        public string Role { get; set; }
    }
}
