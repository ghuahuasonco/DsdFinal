using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Linq;
using System.IO;
using System.Web.Script.Serialization;

namespace RESTtest
{
    [TestClass]
    public class TPrograms
    {
        [TestMethod]
        public void TProgramstest()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:1266/TPrograms.svc/TPrograms"); req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string tprogram = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<TProgram> TPlista = js.Deserialize<List<TProgram>>(tprogram);

        }
    }
}
