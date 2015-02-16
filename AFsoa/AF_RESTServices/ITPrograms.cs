using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AF_RESTServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITPrograms" in both code and config file together.
    [ServiceContract]
    public interface ITPrograms
    {
        [OperationContract]
        void DoWork();
    }
}
