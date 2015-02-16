using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AFSOAP_Services
{
    [ServiceContract]
    public interface ITPCalificas
    {
        [OperationContract]
        string CadenaConexion();

        [OperationContract]
        string TPNotaCalifica(int trainig, double score);
    }
}
