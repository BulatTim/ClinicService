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
    }
}