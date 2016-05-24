using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Clinic.DTO
{
    [DataContract]
   public class ClinicFault
    {
        [DataMember]
        public string Operation { get; set; }
        [DataMember]
        public string ProblemType { get; set; }
    }
}
