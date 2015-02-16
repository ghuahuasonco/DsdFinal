using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AF_ESOAPServices
{
    [ServiceContract]
    public interface ITPEmails
    {
        [OperationContract]
        string SendEmail(String msgto, String msgsubjet, String msgbody);   
    }
}
