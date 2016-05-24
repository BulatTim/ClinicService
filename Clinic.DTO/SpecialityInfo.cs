using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Clinic.DTO
{
    [DataContract]
    public class SpecialityInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
    }
}
