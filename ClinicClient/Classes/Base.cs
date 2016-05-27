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
        public void Initialize(int actionNumber, string role)
        {
            ClinicEventArgs e=null;
            switch (role)
            {
                case "Admin":
                    switch (actionNumber)
                    {
                        case 1:
                            e = new ClinicEventArgs(commonAction.ShowAllDoctors);
                            break;
                        case 2:
                            e = new ClinicEventArgs(admin.AddDoctor);
                            break;
                        case 3:
                            e = new ClinicEventArgs(admin.AddSpeciality);
                            break;
                        case 4:
                            e = new ClinicEventArgs(commonAction.GetDoctorVisits);
                            break;
                        case 5:
                            e = new ClinicEventArgs(commonAction.GetPatientVisits);
                            break;
                        case 0:
                            e = new ClinicEventArgs(authorization.LogOut);
                            break;
                    }
                    AdminAction += new Handler().DoAction;
                    break;

                case "Reseption":
                    switch (actionNumber)
                    {
                        case 1:
                            e = new ClinicEventArgs(commonAction.ShowAllDoctors);
                            break;
                        case 2:
                            e = new ClinicEventArgs(reseption.DoActionWithTickets);
                            break;
                        case 3:
                            e = new ClinicEventArgs(commonAction.GetDoctorVisits);
                            break;
                        case 4:
                            e = new ClinicEventArgs(commonAction.GetPatientVisits);
                            break;
                        case 0:
                            e = new ClinicEventArgs(authorization.LogOut);
                            break;
                    }
                    ReceptionAction += new Handler().DoAction;
                    break;
            }
            
            RaiseEvent(e);
        }
        public static  event EventHandler<ClinicEventArgs> AdminAction;
        public static event EventHandler<ClinicEventArgs> ReceptionAction;
        private void RaiseEvent(ClinicEventArgs e)
        {
            if (AdminAction != null)
            {
                AdminAction(this, e);
                AdminAction = null;
            }
            if (ReceptionAction != null)
            {
                ReceptionAction(this,e);
                ReceptionAction = null;
            }
            
        }

        
    }
}
