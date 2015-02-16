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

namespace AF_SOAPServices
{
    public class TPCalificarNotas : ITPCalificarNotas
    {
        public string CadenaConexion()
        {
            return "Data Source = ghuahuasonco; Initial Catalog = BD_AF; Integrated Security = True";
        }

        public string CalificarNotaTP(int trainig, double score)
        {
            string error = "La Nota: "+  score.ToString()  +" se actualizo en forma exitosa.";
            if (score >= 0 && score <= 20)
            {
                try
                {
                    SqlConnection cone = new SqlConnection(CadenaConexion());
                    cone.Open();

                    string updatescore = "UPDATE AFPERSONAL SET PERTNOTA=" + score.ToString() + " WHERE CODPERT=" + trainig.ToString();
                    SqlCommand cmd = new SqlCommand(updatescore, cone);
                    cmd.ExecuteNonQuery();

                    //Enviar emails si la nota es mayor igual al 13
                    if (score >= 13) {
                            SqlDataAdapter cmde = new SqlDataAdapter("SELECT A.PERTNOM,A.PERTMAIL,B.DESTPG FROM AFPERSONAL A, AFTPROGRAM B WHERE A.CODPERT=" + trainig.ToString() + " AND A.CODTPG=B.CODTPG", cone);
                            System.Data.DataSet ds = new System.Data.DataSet();
                            cmde.Fill(ds);

                            System.Data.DataTable table = ds.Tables[0];
                            String msgto = table.Rows[0]["PERTMAIL"].ToString();
                            String msgsubject = table.Rows[0]["DESTPG"].ToString();
                            String msgbody = "";

                            msgbody = msgbody + "<!DOCTYPE html>";
                            msgbody = msgbody + "<html lang='en'>";
                            msgbody = msgbody + "<head>";
                            msgbody = msgbody + "</head>";
                            msgbody = msgbody + "<body>";
                            msgbody = msgbody + "Estimado <B>" + table.Rows[0]["PERTNOM"].ToString() + ",</B><BR>";
                            msgbody = msgbody + "La empresa AF Consultora le da la bienvenida a formar parte de nuestro Staff, ya que aprobó el examen del Training Program: <B>" + msgsubject + "</B>.<BR><BR>";
                            msgbody = msgbody + "Favor de presentarse a la oficina con los siguientes documentos:<BR><BR>";
                            msgbody = msgbody + "<ul><li>Currículo Vitae documentado.</li>";
                            msgbody = msgbody + "<li>Antecedentes Policiales.</li>";
                            msgbody = msgbody + "<li>Antecedentes Penales.</li>";
                            msgbody = msgbody + "<li>Antecedentes Judiciales.</li>";
                            msgbody = msgbody + "<li>Certificado de domicilio.</li></ul><BR>";
                            msgbody = msgbody + "Gracias.<BR>";
                            msgbody = msgbody + "Saludos.<BR><BR>";
                            msgbody = msgbody + "AF CONSULTORA.<BR>";
                            msgbody = msgbody + "<body>";
                            msgbody = msgbody + "</html>";

                            //email restful
                            int emailstd = 0; //1: email enviado 2: email no enviado error

                            try
                            {
                                string postdata = "{\"msgto\":\"" + msgto + "\",\"msgsubjet\":\"" + msgsubject + "\",\"msgbody\":\"" + msgbody + "\"}";
                                byte[] data = Encoding.UTF8.GetBytes(postdata);
                                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:2613/Emails.svc/Emails");
                                req.Method = "POST";
                                req.ContentLength = data.Length;
                                req.ContentType = "application/json";
                                var reqStream = req.GetRequestStream();
                                reqStream.Write(data, 0, data.Length);
                                var res = (HttpWebResponse)req.GetResponse();
                                StreamReader reader = new StreamReader(res.GetResponseStream());
                                string EmailJson = reader.ReadToEnd();
                                JavaScriptSerializer js = new JavaScriptSerializer();
                                Email EmailEviados = js.Deserialize<Email>(EmailJson);
                                emailstd = 1;
                            } catch (Exception e) { emailstd = 2; }
                            
                            try
                            {
                                SqlConnection conemail = new SqlConnection(CadenaConexion());
                                conemail.Open();

                                string updatemail = "UPDATE AFPERSONAL SET EMAILSTD=" + emailstd.ToString() + " WHERE CODPERT=" + trainig.ToString();
                                SqlCommand cmdemail = new SqlCommand(updatemail, conemail);
                                cmdemail.ExecuteNonQuery();
                            }
                            catch (Exception e) {
                                error = "Existe un Error al envier el Email, verifique";
                            } 
                    }
                }
                catch (Exception e) {
                    error = "Existe un Error al Ingresar la Nota, verifique";   
                }
            }
            else { 
                error= "La Nota ingresada no es la correcta " + score.ToString() + ", el rango de la Nota es: 0 a 20."; 
            }
            return error;
        }
    }
}
