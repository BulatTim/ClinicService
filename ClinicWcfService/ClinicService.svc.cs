using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Configuration;
using Clinic.Bisuness.Services.Implementation;
using Clinic.DTO;
using Clinic.Bisuness.Services.Interfaces;
using Clinic.Bisuness.Services.Classes;
using Microsoft.Practices.Unity;
using System.Web.Configuration;

namespace ClinicWcfService
{
    public class ClinicService : IClinicService
    {
        public delegate List<SpecialityInfo> smtdlg(Guid guid);
        
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
          
            return Invoker.Invoke(AuthorizationService.Authorize, userName, password);
        }
        
        public IList<DoctorInfo> GetAllDoctors(Guid guid)
        {
            
            return Invoker.Invoke(CommonService.GetAllDoctors, guid);
        }
        public void LogOut(SessionTokenInfo sessionTokenInfo)
        {
            
            Invoker.InvokeAction(AuthorizationService.LogOut, sessionTokenInfo);

        }
        public IList<TicketInfo> GetTickets(int doctorId, DateTime date, Guid guid)
        {
            var timeout = double.Parse(WebConfigurationManager.AppSettings["timeout"]);
            return Invoker.Invoke(ReceptionService.GetTickets, doctorId, date, guid,timeout);
        }

        public IList<PatientInfo> GetMedicalRecords(Guid guid)
        {

            return Invoker.Invoke(ReceptionService.GetMedicalRecords, guid);
        }
        public int AddMedicalRecord(PatientInfo patientInfo, Guid guid)
        {

            return Invoker.Invoke(ReceptionService.AddMedicalRecord, patientInfo, guid);
        }
        public bool AddTicket(TicketInfo ticketInfo, Guid guid)
        {


            return Invoker.Invoke(ReceptionService.AddTicket, ticketInfo, guid);
        }
        public bool RemoveTicket(int ticketId, Guid guid)
        {

            return Invoker.Invoke(ReceptionService.RemoveTicket, ticketId, guid);
        }
        public List<SpecialityInfo> GetSpecialities(Guid guid)
        {
            
            
            
            return Invoker.Invoke(AdminService.GetSpecialities, guid);
            
        }
        public bool AddSpeciality(string title,Guid guid)
        {
            
            return Invoker.Invoke(AdminService.AddSpeciality,title, guid);
        }
        public bool AddDoctor(DoctorInfo doctorInfo, Guid guid)
        {
           
            return Invoker.Invoke(AdminService.AddDoctor, doctorInfo, guid);
        }
         public List<TicketInfo> GetDoctorVisits(int doctorID, DateTime date, Guid guid)
        {

            return Invoker.Invoke(CommonService.ShowDoctorVisits, doctorID, date, guid);
        }
         public List<TicketInfo> GetDoctorVisitsByPeriod(int doctorID, DateTime beginDate, DateTime endDate, Guid guid)
         {
             return Invoker.Invoke(CommonService.ShowDoctorVisits, doctorID, beginDate, endDate, guid);
             
         }
         public List<TicketInfo> GetPatientVisits(int patientId, Guid guid)
         {

             return Invoker.Invoke(CommonService.GetPatientVisits, patientId, guid);
         }
        public int SetReservation(TicketInfo ticketInfo, Guid guid)
         {
            return Invoker.Invoke(ReceptionService.SetReservation, ticketInfo,guid);
         }
        public void AbortReservation(int ticketId)
        {
            Invoker.InvokeAction(ReceptionService.AbortReservation, ticketId);
        }
    }
        
    

}
