using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AFRESTServices
{
    [ServiceContract]
    public interface ITPrograms
    {
        [OperationContract]
        [WebInvoke(Method="GET", UriTemplate="TPrograms",ResponseFormat=WebMessageFormat.Json)]
        List <TProgram> ListarTProgram();
    }
}
