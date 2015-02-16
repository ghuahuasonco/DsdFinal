using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace AFSOAP_Services
{
    public class TPCalificas : ITPCalificas
    {
        public string CadenaConexion()
        {
            return "Data Source = ghuahuasonco; Initial Catalog = BD_AF; Integrated Security = True";
        }

        public string TPNotaCalifica(int trainig, double score)
        {
            if (score >= 0 && score <= 20) {
                try
                {
                    SqlConnection cone = new SqlConnection(CadenaConexion());
                    cone.Open();

                    string updatescore = "UPDATE AFPERSONAL SET PERTNOTA=" + score.ToString() + " WHERE CODPERT=" + trainig.ToString();
                    SqlCommand cmd = new SqlCommand(updatescore, cone);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
            else {
                return "La Nota ingresada no es la correcta " + score.ToString() + ", el rango de nota es: 0 a 20.";
            }
        }
    }
}
