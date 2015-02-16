using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AF_TPSOAPServices
{
    [ServiceContract]
    public interface ITPListas
    {
        [OperationContract]
        string CadenaConexion();

        [OperationContract]
        string ListarTP(int trainig);

        [OperationContract]
        string CalificarTP(int trainig);
    }
}
