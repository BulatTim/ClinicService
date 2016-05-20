using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Clinic.Bisuness.Services.Implementation;
using Clinic.DTO;
using Clinic.Bisuness.Services.Interfaces;
using Microsoft.Practices.Unity;

namespace ClinicWcfService
{
    public class ClinicService : IClinicService
    {
        public static  UnityContainer unityContainer;
        protected IAuthorizationService AuthorizationService { get; set; }

        protected ICommonService CommonService { get; set; }

        protected IAdminService AdminService { get; set; }

        protected IReceptionService ReceptionService { get; set; }
        public ClinicService()
        {
            unityContainer = new UnityContainer();
            WCFConfig.Initialize(unityContainer);
            AuthorizationService = unityContainer.Resolve<IAuthorizationService>();
            CommonService=unityContainer.Resolve<ICommonService>();
            AdminService=unityContainer.Resolve<IAdminService>();
            ReceptionService = unityContainer.Resolve<IReceptionService>();
        }

        public SessionTokenInfo Authorize(string userName, string password)
        {            
            return AuthorizationService.Authorize(userName, password);
        }
        public IList<DoctorInfo> GetAllDoctors(Guid guid)
        {           
            return CommonService.GetAllDoctors(guid);
        }        
    }
}
