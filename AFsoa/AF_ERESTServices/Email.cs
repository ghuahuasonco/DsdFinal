using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AF_ERESTServices
{
    [DataContract]
    public class Email
    {
        [DataMember]
        public string msgto     {get; set;}
        [DataMember]
        public string msgsubjet {get; set;}
        [DataMember]
        public string msgbody   {get; set;}
    }
}