﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicClient.ClinicWCFService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ClinicWCFService.IClinicService")]
    public interface IClinicService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/Authorize", ReplyAction="http://tempuri.org/IClinicService/AuthorizeResponse")]
        Clinic.DTO.SessionTokenInfo Authorize(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/Authorize", ReplyAction="http://tempuri.org/IClinicService/AuthorizeResponse")]
        System.Threading.Tasks.Task<Clinic.DTO.SessionTokenInfo> AuthorizeAsync(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/GetAllDoctors", ReplyAction="http://tempuri.org/IClinicService/GetAllDoctorsResponse")]
        System.Collections.Generic.List<Clinic.DTO.DoctorInfo> GetAllDoctors(System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/GetAllDoctors", ReplyAction="http://tempuri.org/IClinicService/GetAllDoctorsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Clinic.DTO.DoctorInfo>> GetAllDoctorsAsync(System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/LogOut", ReplyAction="http://tempuri.org/IClinicService/LogOutResponse")]
        void LogOut(Clinic.DTO.SessionTokenInfo sessionTokenInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/LogOut", ReplyAction="http://tempuri.org/IClinicService/LogOutResponse")]
        System.Threading.Tasks.Task LogOutAsync(Clinic.DTO.SessionTokenInfo sessionTokenInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/GetTickets", ReplyAction="http://tempuri.org/IClinicService/GetTicketsResponse")]
        System.Collections.Generic.List<Clinic.DTO.TicketInfo> GetTickets(int doctorId, System.DateTime date, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/GetTickets", ReplyAction="http://tempuri.org/IClinicService/GetTicketsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Clinic.DTO.TicketInfo>> GetTicketsAsync(int doctorId, System.DateTime date, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/GetMedicalRecords", ReplyAction="http://tempuri.org/IClinicService/GetMedicalRecordsResponse")]
        System.Collections.Generic.List<Clinic.DTO.PatientInfo> GetMedicalRecords(System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/GetMedicalRecords", ReplyAction="http://tempuri.org/IClinicService/GetMedicalRecordsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Clinic.DTO.PatientInfo>> GetMedicalRecordsAsync(System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/AddMedicalRecord", ReplyAction="http://tempuri.org/IClinicService/AddMedicalRecordResponse")]
        int AddMedicalRecord(Clinic.DTO.PatientInfo patientInfo, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/AddMedicalRecord", ReplyAction="http://tempuri.org/IClinicService/AddMedicalRecordResponse")]
        System.Threading.Tasks.Task<int> AddMedicalRecordAsync(Clinic.DTO.PatientInfo patientInfo, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/AddTicket", ReplyAction="http://tempuri.org/IClinicService/AddTicketResponse")]
        bool AddTicket(Clinic.DTO.TicketInfo ticketInfo, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/AddTicket", ReplyAction="http://tempuri.org/IClinicService/AddTicketResponse")]
        System.Threading.Tasks.Task<bool> AddTicketAsync(Clinic.DTO.TicketInfo ticketInfo, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/RemoveTicket", ReplyAction="http://tempuri.org/IClinicService/RemoveTicketResponse")]
        bool RemoveTicket(int ticketId, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/RemoveTicket", ReplyAction="http://tempuri.org/IClinicService/RemoveTicketResponse")]
        System.Threading.Tasks.Task<bool> RemoveTicketAsync(int ticketId, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/GetSpecialities", ReplyAction="http://tempuri.org/IClinicService/GetSpecialitiesResponse")]
        System.Collections.Generic.List<Clinic.DTO.SpecialityInfo> GetSpecialities(System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/GetSpecialities", ReplyAction="http://tempuri.org/IClinicService/GetSpecialitiesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Clinic.DTO.SpecialityInfo>> GetSpecialitiesAsync(System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/AddSpeciality", ReplyAction="http://tempuri.org/IClinicService/AddSpecialityResponse")]
        bool AddSpeciality(string title, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/AddSpeciality", ReplyAction="http://tempuri.org/IClinicService/AddSpecialityResponse")]
        System.Threading.Tasks.Task<bool> AddSpecialityAsync(string title, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/AddDoctor", ReplyAction="http://tempuri.org/IClinicService/AddDoctorResponse")]
        bool AddDoctor(Clinic.DTO.DoctorInfo doctorInfo, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/AddDoctor", ReplyAction="http://tempuri.org/IClinicService/AddDoctorResponse")]
        System.Threading.Tasks.Task<bool> AddDoctorAsync(Clinic.DTO.DoctorInfo doctorInfo, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/GetDoctorVisits", ReplyAction="http://tempuri.org/IClinicService/GetDoctorVisitsResponse")]
        System.Collections.Generic.List<Clinic.DTO.TicketInfo> GetDoctorVisits(int doctorID, System.DateTime date, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/GetDoctorVisits", ReplyAction="http://tempuri.org/IClinicService/GetDoctorVisitsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Clinic.DTO.TicketInfo>> GetDoctorVisitsAsync(int doctorID, System.DateTime date, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/GetDoctorVisitsByPeriod", ReplyAction="http://tempuri.org/IClinicService/GetDoctorVisitsByPeriodResponse")]
        System.Collections.Generic.List<Clinic.DTO.TicketInfo> GetDoctorVisitsByPeriod(int doctorID, System.DateTime beginDate, System.DateTime endDate, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/GetDoctorVisitsByPeriod", ReplyAction="http://tempuri.org/IClinicService/GetDoctorVisitsByPeriodResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Clinic.DTO.TicketInfo>> GetDoctorVisitsByPeriodAsync(int doctorID, System.DateTime beginDate, System.DateTime endDate, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/GetPatientVisits", ReplyAction="http://tempuri.org/IClinicService/GetPatientVisitsResponse")]
        System.Collections.Generic.List<Clinic.DTO.TicketInfo> GetPatientVisits(int patientId, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/GetPatientVisits", ReplyAction="http://tempuri.org/IClinicService/GetPatientVisitsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Clinic.DTO.TicketInfo>> GetPatientVisitsAsync(int patientId, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/SetReservation", ReplyAction="http://tempuri.org/IClinicService/SetReservationResponse")]
        int SetReservation(Clinic.DTO.TicketInfo ticketInfo, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/SetReservation", ReplyAction="http://tempuri.org/IClinicService/SetReservationResponse")]
        System.Threading.Tasks.Task<int> SetReservationAsync(Clinic.DTO.TicketInfo ticketInfo, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/AbortReservation", ReplyAction="http://tempuri.org/IClinicService/AbortReservationResponse")]
        void AbortReservation(int ticketId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClinicService/AbortReservation", ReplyAction="http://tempuri.org/IClinicService/AbortReservationResponse")]
        System.Threading.Tasks.Task AbortReservationAsync(int ticketId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IClinicServiceChannel : ClinicClient.ClinicWCFService.IClinicService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ClinicServiceClient : System.ServiceModel.ClientBase<ClinicClient.ClinicWCFService.IClinicService>, ClinicClient.ClinicWCFService.IClinicService {
        
        public ClinicServiceClient() {
        }
        
        public ClinicServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ClinicServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClinicServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClinicServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Clinic.DTO.SessionTokenInfo Authorize(string userName, string password) {
            return base.Channel.Authorize(userName, password);
        }
        
        public System.Threading.Tasks.Task<Clinic.DTO.SessionTokenInfo> AuthorizeAsync(string userName, string password) {
            return base.Channel.AuthorizeAsync(userName, password);
        }
        
        public System.Collections.Generic.List<Clinic.DTO.DoctorInfo> GetAllDoctors(System.Guid guid) {
            return base.Channel.GetAllDoctors(guid);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Clinic.DTO.DoctorInfo>> GetAllDoctorsAsync(System.Guid guid) {
            return base.Channel.GetAllDoctorsAsync(guid);
        }
        
        public void LogOut(Clinic.DTO.SessionTokenInfo sessionTokenInfo) {
            base.Channel.LogOut(sessionTokenInfo);
        }
        
        public System.Threading.Tasks.Task LogOutAsync(Clinic.DTO.SessionTokenInfo sessionTokenInfo) {
            return base.Channel.LogOutAsync(sessionTokenInfo);
        }
        
        public System.Collections.Generic.List<Clinic.DTO.TicketInfo> GetTickets(int doctorId, System.DateTime date, System.Guid guid) {
            return base.Channel.GetTickets(doctorId, date, guid);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Clinic.DTO.TicketInfo>> GetTicketsAsync(int doctorId, System.DateTime date, System.Guid guid) {
            return base.Channel.GetTicketsAsync(doctorId, date, guid);
        }
        
        public System.Collections.Generic.List<Clinic.DTO.PatientInfo> GetMedicalRecords(System.Guid guid) {
            return base.Channel.GetMedicalRecords(guid);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Clinic.DTO.PatientInfo>> GetMedicalRecordsAsync(System.Guid guid) {
            return base.Channel.GetMedicalRecordsAsync(guid);
        }
        
        public int AddMedicalRecord(Clinic.DTO.PatientInfo patientInfo, System.Guid guid) {
            return base.Channel.AddMedicalRecord(patientInfo, guid);
        }
        
        public System.Threading.Tasks.Task<int> AddMedicalRecordAsync(Clinic.DTO.PatientInfo patientInfo, System.Guid guid) {
            return base.Channel.AddMedicalRecordAsync(patientInfo, guid);
        }
        
        public bool AddTicket(Clinic.DTO.TicketInfo ticketInfo, System.Guid guid) {
            return base.Channel.AddTicket(ticketInfo, guid);
        }
        
        public System.Threading.Tasks.Task<bool> AddTicketAsync(Clinic.DTO.TicketInfo ticketInfo, System.Guid guid) {
            return base.Channel.AddTicketAsync(ticketInfo, guid);
        }
        
        public bool RemoveTicket(int ticketId, System.Guid guid) {
            return base.Channel.RemoveTicket(ticketId, guid);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveTicketAsync(int ticketId, System.Guid guid) {
            return base.Channel.RemoveTicketAsync(ticketId, guid);
        }
        
        public System.Collections.Generic.List<Clinic.DTO.SpecialityInfo> GetSpecialities(System.Guid guid) {
            return base.Channel.GetSpecialities(guid);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Clinic.DTO.SpecialityInfo>> GetSpecialitiesAsync(System.Guid guid) {
            return base.Channel.GetSpecialitiesAsync(guid);
        }
        
        public bool AddSpeciality(string title, System.Guid guid) {
            return base.Channel.AddSpeciality(title, guid);
        }
        
        public System.Threading.Tasks.Task<bool> AddSpecialityAsync(string title, System.Guid guid) {
            return base.Channel.AddSpecialityAsync(title, guid);
        }
        
        public bool AddDoctor(Clinic.DTO.DoctorInfo doctorInfo, System.Guid guid) {
            return base.Channel.AddDoctor(doctorInfo, guid);
        }
        
        public System.Threading.Tasks.Task<bool> AddDoctorAsync(Clinic.DTO.DoctorInfo doctorInfo, System.Guid guid) {
            return base.Channel.AddDoctorAsync(doctorInfo, guid);
        }
        
        public System.Collections.Generic.List<Clinic.DTO.TicketInfo> GetDoctorVisits(int doctorID, System.DateTime date, System.Guid guid) {
            return base.Channel.GetDoctorVisits(doctorID, date, guid);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Clinic.DTO.TicketInfo>> GetDoctorVisitsAsync(int doctorID, System.DateTime date, System.Guid guid) {
            return base.Channel.GetDoctorVisitsAsync(doctorID, date, guid);
        }
        
        public System.Collections.Generic.List<Clinic.DTO.TicketInfo> GetDoctorVisitsByPeriod(int doctorID, System.DateTime beginDate, System.DateTime endDate, System.Guid guid) {
            return base.Channel.GetDoctorVisitsByPeriod(doctorID, beginDate, endDate, guid);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Clinic.DTO.TicketInfo>> GetDoctorVisitsByPeriodAsync(int doctorID, System.DateTime beginDate, System.DateTime endDate, System.Guid guid) {
            return base.Channel.GetDoctorVisitsByPeriodAsync(doctorID, beginDate, endDate, guid);
        }
        
        public System.Collections.Generic.List<Clinic.DTO.TicketInfo> GetPatientVisits(int patientId, System.Guid guid) {
            return base.Channel.GetPatientVisits(patientId, guid);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Clinic.DTO.TicketInfo>> GetPatientVisitsAsync(int patientId, System.Guid guid) {
            return base.Channel.GetPatientVisitsAsync(patientId, guid);
        }
        
        public int SetReservation(Clinic.DTO.TicketInfo ticketInfo, System.Guid guid) {
            return base.Channel.SetReservation(ticketInfo, guid);
        }
        
        public System.Threading.Tasks.Task<int> SetReservationAsync(Clinic.DTO.TicketInfo ticketInfo, System.Guid guid) {
            return base.Channel.SetReservationAsync(ticketInfo, guid);
        }
        
        public void AbortReservation(int ticketId) {
            base.Channel.AbortReservation(ticketId);
        }
        
        public System.Threading.Tasks.Task AbortReservationAsync(int ticketId) {
            return base.Channel.AbortReservationAsync(ticketId);
        }
    }
}
