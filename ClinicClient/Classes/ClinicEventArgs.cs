using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicClient.Classes
{
    public class ClinicEventArgs:EventArgs
    {
        //private int action;
        //private string role;
        private Action action;
        public ClinicEventArgs(Action action)
        {
            this.action = action;

        }

        public Action Action { get { return action; } }
        //public string Role { get { return role; } }
    }
}
