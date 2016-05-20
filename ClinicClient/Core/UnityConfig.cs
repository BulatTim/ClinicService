using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using ClinicClient.ClinicWCFService;
using ClinicClient.Application;




namespace ClinicClient.Core
{
    public static class UnityConfig
    {
        public static void Initialize(UnityContainer unityContainer)
        {
            unityContainer.RegisterType<Admin>("admin");
            unityContainer.RegisterType<Authorization>("authorization");
            unityContainer.RegisterType<Reseption>("reseption");
            unityContainer.RegisterType<CommonAction>("commonAction");
            unityContainer.RegisterType<IClinicService, ClinicServiceClient>(new InjectionConstructor());
            
            


        }
    }
}
