using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AFSOAPServices
{
    [ServiceContract]
    public interface ITPCalificas
    {

        [OperationContract]
        string CadenaConexion();

        [OperationContract]

        [OperationContract]
        string TPCalificar(int trainig, double score);

    }
}
