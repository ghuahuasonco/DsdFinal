using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace AF_TPSOAPServices
{
    public class TPListas : ITPListas
    {
        public string CadenaConexion()
        {
            return "Data Source = ghuahuasonco; Initial Catalog = BD_AF; Integrated Security = True";
        }

        public string ListarTP(int Trainig)
        {

            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:1266/TPrograms.svc/TPrograms"); req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string tprogram = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<TProgram> TPlista = js.Deserialize<List<TProgram>>(tprogram);
            //ejecucion de wcf service desde consola fuera del visual estudio.
            switch (TPlista.Count) { 
                case 0:
                    return "";
                default:
                    string listajs = "";
                    int listalen = 0;
                    foreach (TProgram thelist in TPlista){
                        listajs = listajs + thelist.DescripcionTP + ":" + thelist.FechaTP + ":" + thelist.CodigoTP + ":";
                    }
                    listalen = listajs.Length - 1;
                    return listajs.Substring(0, listalen);
            }
        }

        public string CalificarTP(int Trainig)
        {
            try
            {
                SqlConnection cone = new SqlConnection(CadenaConexion());
                cone.Open();

                SqlDataAdapter cmd = new SqlDataAdapter("SELECT LTRIM(RTRIM(A.PERTNOM))+':'+LTRIM(RTRIM(CONVERT(CHAR(10),A.PERTNOTA)))+':'+LTRIM(RTRIM(CONVERT(CHAR(10),A.CODPERT)))+':'+B.DESTPG AS TPGM FROM AFPERSONAL A, AFTPROGRAM B WHERE A.CODTPG=" + Trainig.ToString() + "  AND  A.CODTPG =B.CODTPG", cone);
                System.Data.DataTable dt = new System.Data.DataTable();
                cmd.Fill(dt);

                String lista = "";
                int listalen = 0;

                foreach (System.Data.DataRow row in dt.Rows)
                {
                    lista = lista + row["TPGM"].ToString().Trim() + ':';
                }

                switch (lista.Length)
                {
                    case 0:
                        return "";
                    default:
                        listalen = lista.Length - 1;
                        return lista.Substring(0, listalen);
                }
            }
            catch (Exception e)
            {
                String error = e.ToString();
                return "";
            }
        }

    
    }
}
