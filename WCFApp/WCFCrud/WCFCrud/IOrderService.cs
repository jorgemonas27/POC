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
        string orDelivery = string.Empty;

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
        public string DeliveryOrder
        {
            get { return orDelivery; }
            set { orDelivery = value; }
        }
    }
}
