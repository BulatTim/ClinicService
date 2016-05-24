using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Clinic.DTO
{
    [DataContract]
   public class PatientInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public System.DateTime Birthdate { get; set; }

        [DataMember]
        public AddressInfo Address { get; set; }
    }
}
