using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AF_SOAPServices
{
    [ServiceContract]
    public interface ITPCalificarNotas
    {
        [OperationContract]
        string CadenaConexion();

        [OperationContract]
        string CalificarNotaTP(int trainig, double score);
    }
}
