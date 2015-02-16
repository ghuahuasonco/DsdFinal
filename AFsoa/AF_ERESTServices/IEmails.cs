using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AF_ERESTServices
{
    [ServiceContract]
    public interface IEmails
    {
        [OperationContract]
        [WebInvoke(Method="POST",UriTemplate="Emails",ResponseFormat=WebMessageFormat.Json)]
        Email E_mail(Email EnviarEmail);
    }
}
