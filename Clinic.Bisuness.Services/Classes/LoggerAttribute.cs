using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Bisuness.Services.Classes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class LoggerAttribute:System.Attribute
    {
        public bool IsLogEnable;
        public LoggerAttribute(bool IsLogEnable)
        {
            this.IsLogEnable = IsLogEnable;
        }
    }
}
