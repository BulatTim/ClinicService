using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Clinic.DTO
{
    [DataContract]
    public class TicketInfo
    {
        [DataMember]
        public int Id { get; set; }
         [DataMember]
        public DoctorInfo DoctorInfo { get; set; }
         [DataMember]
         public PatientInfo PatientInfo { get; set; }

         [DataMember]
        public System.DateTime DateTime { get; set; }
       
    }
}
