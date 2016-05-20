using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinic.Bisuness.Services.Interfaces;
using Clinic.Bisuness.Services.Implementation;
using Microsoft.Practices.Unity;

namespace ClinicWcfService
{
    public static class WCFConfig
    {

        public static void Initialize(UnityContainer unityContainer)
        {
            unityContainer.RegisterType<IAdminService, AdminService>();
            unityContainer.RegisterType<IAuthorizationService, AuthorizationService>();
            unityContainer.RegisterType<ICommonService, CommonService>();
            unityContainer.RegisterType<IReceptionService, ReceptionService>();
        }
       
    }
}