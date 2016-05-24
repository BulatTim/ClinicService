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
        #region
        public static UnityContainer unityContainer;
        protected IAuthorizationService AuthorizationService { get; set; }

        protected ICommonService CommonService { get; set; }

        protected IAdminService AdminService { get; set; }

        protected IReceptionService ReceptionService { get; set; }
        #endregion
        public ClinicService()
        {
            unityContainer = new UnityContainer();
            WCFConfig.Initialize(unityContainer);
            AuthorizationService = unityContainer.Resolve<IAuthorizationService>();
            CommonService = unityContainer.Resolve<ICommonService>();
            AdminService = unityContainer.Resolve<IAdminService>();
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
        public void LogOut(SessionTokenInfo sessionTokenInfo)
        {
            AuthorizationService.LogOut(sessionTokenInfo);
        }
        public IList<TicketInfo> GetTickets(int doctorId, DateTime date, Guid guid)
        {
            return CommonService.GetTickets(doctorId, date, guid);
        }

        public IList<PatientInfo> GetMedicalRecords(Guid guid)
        {
            return CommonService.GetMedicalRecords(guid);
        }
        public int AddMedicalRecord(PatientInfo patientInfo, Guid guid)
        {
            return CommonService.AddMedicalRecord(patientInfo, guid);
        }
        public bool AddTicket(TicketInfo ticketInfo, Guid guid)
        {
            
            return CommonService.AddTicket(ticketInfo,guid);
        }
        public bool RemoveTicket(int ticketId, Guid guid)
        {
            return CommonService.RemoveTicket(ticketId, guid);
        }
        public List<SpecialityInfo> GetSpecialities(Guid guid)
        {
            return AdminService.GetSpecialities(guid);
        }
        public bool AddSpeciality(string title,Guid guid)
        {
            return AdminService.AddSpeciality(title, guid);
        }
        public bool AddDoctor(DoctorInfo doctorInfo, Guid guid)
        {
            return AdminService.AddDoctor(doctorInfo, guid);
        }
         public List<TicketInfo> GetDoctorVisits(int doctorID, DateTime date, Guid guid)
        {
            return AdminService.ShowDoctorVisits(doctorID, date, guid);
        }
         public List<TicketInfo> GetDoctorVisitsByPeriod(int doctorID, DateTime beginDate, DateTime endDate, Guid guid)
         {
             return AdminService.ShowDoctorVisits(doctorID, beginDate, endDate, guid);
         }
         public List<TicketInfo> GetPatientVisits(int patientId, Guid guid)
         {
             return AdminService.GetPatientVisits(patientId, guid);
         }
    }
        
    

}
