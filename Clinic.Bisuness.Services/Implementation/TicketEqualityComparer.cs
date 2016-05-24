using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.DTO;

namespace Clinic.Bisuness.Services.Implementation
{
   public class TicketEqualityComparer:IEqualityComparer<TicketInfo>
    {

        public bool Equals(TicketInfo x, TicketInfo y)
        {
            if(x==null || y==null)
            {
                return false;
            }
            return x.DateTime == y.DateTime;
        }

        public int GetHashCode(TicketInfo obj)
        {
            return obj.DateTime.GetHashCode();
        }
    }
}
