﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17379
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AsyncMVC.NewsServiceMVC4Reference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NewsModel", Namespace="http://schemas.datacontract.org/2004/07/AsyncMVC")]
    [System.SerializableAttribute()]
    public partial class NewsModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string HeadingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Heading {
            get {
                return this.HeadingField;
            }
            set {
                if ((object.ReferenceEquals(this.HeadingField, value) != true)) {
                    this.HeadingField = value;
                    this.RaisePropertyChanged("Heading");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Text {
            get {
                return this.TextField;
            }
            set {
                if ((object.ReferenceEquals(this.TextField, value) != true)) {
                    this.TextField = value;
                    this.RaisePropertyChanged("Text");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NewsServiceMVC4Reference.INewsServiceMVC4")]
    public interface INewsServiceMVC4 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsServiceMVC4/GetWorldNews", ReplyAction="http://tempuri.org/INewsServiceMVC4/GetWorldNewsResponse")]
        AsyncMVC.NewsServiceMVC4Reference.NewsModel[] GetWorldNews();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsServiceMVC4/GetWorldNews", ReplyAction="http://tempuri.org/INewsServiceMVC4/GetWorldNewsResponse")]
        System.Threading.Tasks.Task<AsyncMVC.NewsServiceMVC4Reference.NewsModel[]> GetWorldNewsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsServiceMVC4/GetSportNews", ReplyAction="http://tempuri.org/INewsServiceMVC4/GetSportNewsResponse")]
        AsyncMVC.NewsServiceMVC4Reference.NewsModel[] GetSportNews();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsServiceMVC4/GetSportNews", ReplyAction="http://tempuri.org/INewsServiceMVC4/GetSportNewsResponse")]
        System.Threading.Tasks.Task<AsyncMVC.NewsServiceMVC4Reference.NewsModel[]> GetSportNewsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsServiceMVC4/GetFunNews", ReplyAction="http://tempuri.org/INewsServiceMVC4/GetFunNewsResponse")]
        AsyncMVC.NewsServiceMVC4Reference.NewsModel[] GetFunNews();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsServiceMVC4/GetFunNews", ReplyAction="http://tempuri.org/INewsServiceMVC4/GetFunNewsResponse")]
        System.Threading.Tasks.Task<AsyncMVC.NewsServiceMVC4Reference.NewsModel[]> GetFunNewsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INewsServiceMVC4Channel : AsyncMVC.NewsServiceMVC4Reference.INewsServiceMVC4, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NewsServiceMVC4Client : System.ServiceModel.ClientBase<AsyncMVC.NewsServiceMVC4Reference.INewsServiceMVC4>, AsyncMVC.NewsServiceMVC4Reference.INewsServiceMVC4 {
        
        public NewsServiceMVC4Client() {
        }
        
        public NewsServiceMVC4Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NewsServiceMVC4Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NewsServiceMVC4Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NewsServiceMVC4Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AsyncMVC.NewsServiceMVC4Reference.NewsModel[] GetWorldNews() {
            return base.Channel.GetWorldNews();
        }
        
        public System.Threading.Tasks.Task<AsyncMVC.NewsServiceMVC4Reference.NewsModel[]> GetWorldNewsAsync() {
            return base.Channel.GetWorldNewsAsync();
        }
        
        public AsyncMVC.NewsServiceMVC4Reference.NewsModel[] GetSportNews() {
            return base.Channel.GetSportNews();
        }
        
        public System.Threading.Tasks.Task<AsyncMVC.NewsServiceMVC4Reference.NewsModel[]> GetSportNewsAsync() {
            return base.Channel.GetSportNewsAsync();
        }
        
        public AsyncMVC.NewsServiceMVC4Reference.NewsModel[] GetFunNews() {
            return base.Channel.GetFunNews();
        }
        
        public System.Threading.Tasks.Task<AsyncMVC.NewsServiceMVC4Reference.NewsModel[]> GetFunNewsAsync() {
            return base.Channel.GetFunNewsAsync();
        }
    }
}
