using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AFRESTServices
{
    [DataContract]
    public class TProgram
    {
        [DataMember]
        public string CodigoTP      { get; set; }
        [DataMember]
        public string DescripcionTP { get; set; }
        [DataMember]
        public string FechaTP       { get; set; }
    }
}