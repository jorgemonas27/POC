using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataAccessNF.Models;

namespace WCFCrud
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat =WebMessageFormat.Json, BodyStyle =WebMessageBodyStyle.Wrapped, UriTemplate ="json/post")]
        string InsertData(OrdDetails order);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/put/{id}")]
        string UpdateData(string id, OrdDetails order);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "delete/{id}")]
        string DeleteData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "get")]
        IEnumerable<ClientOrder> GetData();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "get/{id}")]
        ClientOrder GetCertainData(string id);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class OrdDetails
    {
        int oId;
        string orName = string.Empty;
        string orCity = string.Empty;
        string orState = string.Empty;
        string orAddress = string.Empty;
        string orCountry = string.Empty;
        string orDesCity = string.Empty;
        string orDesState = string.Empty;
        string orDesAddress = string.Empty;
        string orDesCountry = string.Empty;
        string orStatus = string.Empty;
        string orDescription = string.Empty;
        int orIdShipment;
        int orIdLoad;

        [DataMember]
        public int Id
        {
            get { return oId; }
            set { oId = value; }
        }

        [DataMember]
        public string NameOrder
        {
            get { return orName; }
            set { orName = value; }
        }

        [DataMember]
        public string OriginCountry
        {
            get { return orCountry; }
            set { orCountry = value; }
        }

        [DataMember]
        public string OriginState
        {
            get { return orState; }
            set { orState = value; }
        }

        [DataMember]
        public string OriginCity
        {
            get { return orCity; }
            set { orCity = value; }
        }

        [DataMember]
        public string OriginAddress
        {
            get { return orAddress; }
            set { orAddress = value; }
        }

        [DataMember]
        public string DestinationCountry
        {
            get { return orDesCountry; }
            set { orDesCountry = value; }
        }

        [DataMember]
        public string DestinationState
        {
            get { return orDesState; }
            set { orDesState = value; }
        }

        [DataMember]
        public string DestinationCity
        {
            get { return orDesCity; }
            set { orDesCity = value; }
        }

        [DataMember]
        public string DestinationAddress
        {
            get { return orDesAddress; }
            set { orDesAddress = value; }
        }

        [DataMember]
        public string Status
        {
            get { return orStatus; }
            set { orStatus = value; }
        }

        [DataMember]
        public string Description
        {
            get { return orDescription; }
            set { orDescription = value; }
        }

        [DataMember]
        public int IdLoad
        {
            get { return orIdLoad; }
            set { orIdLoad = value; }
        }

        [DataMember]
        public int IdShipment
        {
            get { return orIdShipment; }
            set { orIdShipment = value; }
        }
    }
}
