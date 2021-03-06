﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 15.0.26323.1
// 
namespace Roommate.IoT.Business.RoommateServer {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RoommateServer.IAppointmentService")]
    public interface IAppointmentService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAppointmentService/GetAppointmentsBetween", ReplyAction="http://tempuri.org/IAppointmentService/GetAppointmentsBetweenResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.Collection<Roommate.Application.Shared.Appointment.AppointmentUiModel>> GetAppointmentsBetweenAsync(System.DateTime dateFrom, System.DateTime dateTo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAppointmentServiceChannel : Roommate.IoT.Business.RoommateServer.IAppointmentService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AppointmentServiceClient : System.ServiceModel.ClientBase<Roommate.IoT.Business.RoommateServer.IAppointmentService>, Roommate.IoT.Business.RoommateServer.IAppointmentService {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public AppointmentServiceClient() : 
                base(AppointmentServiceClient.GetDefaultBinding(), AppointmentServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.NetTcpBinding_IAppointmentService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AppointmentServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(AppointmentServiceClient.GetBindingForEndpoint(endpointConfiguration), AppointmentServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AppointmentServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(AppointmentServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AppointmentServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(AppointmentServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AppointmentServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.Collection<Roommate.Application.Shared.Appointment.AppointmentUiModel>> GetAppointmentsBetweenAsync(System.DateTime dateFrom, System.DateTime dateTo) {
            return base.Channel.GetAppointmentsBetweenAsync(dateFrom, dateTo);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.NetTcpBinding_IAppointmentService)) {
                System.ServiceModel.NetTcpBinding result = new System.ServiceModel.NetTcpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.NetTcpBinding_IAppointmentService)) {
                return new System.ServiceModel.EndpointAddress(new System.Uri("net.tcp://localhost:9001/AppointmentService"), new System.ServiceModel.UpnEndpointIdentity("DESKTOP-GSPPT2P\\aprac"));
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return AppointmentServiceClient.GetBindingForEndpoint(EndpointConfiguration.NetTcpBinding_IAppointmentService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return AppointmentServiceClient.GetEndpointAddress(EndpointConfiguration.NetTcpBinding_IAppointmentService);
        }
        
        public enum EndpointConfiguration {
            
            NetTcpBinding_IAppointmentService,
        }
    }
}
