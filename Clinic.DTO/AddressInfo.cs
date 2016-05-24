using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Clinic.DTO
{
    [DataContract]
   public class AddressInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string Home { get; set; }
        [DataMember]
        public string HousingBody { get; set; }
        [DataMember]
        public string Apartament { get; set; }
    
    }
}
