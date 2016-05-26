using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicClient.Classes
{
    public class Handler
    {
        public void DoAction(object sender,ClinicEventArgs e)
        {
            var action = e.Action;
            action();
        }
    }
}
