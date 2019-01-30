using System.ServiceModel;
using System.ServiceModel.Web;

namespace clu.active.learning.web
{
    [ServiceContract]
    public interface ISalesService
    {
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        SalesPerson GetSalesPerson(string emailAddress);
    }
}
