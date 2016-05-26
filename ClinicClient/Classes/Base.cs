using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using ClinicClient.Application;

namespace ClinicClient.Classes
{
    public delegate void ClinicDelegate();
    public class Base
    {
        static Base()
        {
            commonAction = Program.unityContainer.Resolve<CommonAction>();
            admin = Program.unityContainer.Resolve<Admin>();
            authorization = Program.unityContainer.Resolve<Authorization>();
            reseption = Program.unityContainer.Resolve<Reseption>();
        }
        public static  CommonAction commonAction { get; set; }
        public static Admin admin { get; set; }
        public static Authorization authorization { get; set; }
        public static Reseption reseption { get; set; }
        public void Initialize(ClinicEventArgs e)
        {


            switch (e.Role)
            {
                case "Admin":
                    switch (e.Action)
                    {
                        case 1:
                            NewAction += commonAction.ShowAllDoctors;
                            break;
                        case 2:
                            NewAction += admin.AddDoctor;
                            break;
                        case 3:
                            NewAction += admin.AddSpeciality;
                            break;
                        case 4:
                            NewAction += commonAction.GetDoctorVisits;
                            break;
                        case 5:
                            NewAction += commonAction.GetPatientVisits;
                            break;
                        case 0:
                            NewAction += authorization.LogOut;
                            return;
                    }
                    break;
                case "Reseption":
                    switch (e.Action)
                    {
                        case 1:
                            NewAction += commonAction.ShowAllDoctors;
                            break;
                        case 2:
                            NewAction += reseption.DoActionWithTickets;
                            break;
                        case 3:
                            NewAction += commonAction.GetDoctorVisits;
                            break;
                        case 4:
                            NewAction += commonAction.GetPatientVisits;
                            break;
                        case 0:
                            NewAction += authorization.LogOut;
                            return;
                    }
                    break;
            }

        }
        public event EventHandler<ClinicEventArgs> NewAction;

        private void RaiseEvent(ClinicEventArgs e)
        {
            if(NewAction!=null)
            {
                NewAction(this, e);
                NewAction = null;
            }
        }
        public void DoAction(ClinicEventArgs e)
        {
            Initialize(e);
            RaiseEvent(e);
        }
    }
}
