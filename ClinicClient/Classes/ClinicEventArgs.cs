using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicClient.Classes
{
    public class ClinicEventArgs:EventArgs
    {
        private int action;
        private string role;
        public ClinicEventArgs(int action,string role)
        {
            this.action = action;
            this.role = role;
        }
        public int Action { get { return action; } }
        public string Role { get { return role; } }
    }
}
