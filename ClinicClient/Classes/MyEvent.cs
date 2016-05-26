using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicClient.Classes
{
    public delegate void ClinicDelegate();
    public class MyEvent
    {
            public event ClinicDelegate clinicEvent;

            public void RaiseEvent(int i)
            {
                if (clinicEvent != null)
                {
                    clinicEvent();
                }
            }
        
    }
}
