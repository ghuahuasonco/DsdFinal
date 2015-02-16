using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;

namespace AF_ESOAPServices
{
    public class TPEmails : ITPEmails
    {
        public string SendEmail(String msgto, String msgsubjet, String msgbody)
        {
            try
            {
                SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
                cliente.EnableSsl = true;
                cliente.Timeout = 10000;
                cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                cliente.UseDefaultCredentials = false;
                cliente.Credentials = new NetworkCredential("tuemail@gmail.com", "tuclave");
                MailMessage msg = new MailMessage();
                msg.To.Add(msgto);
                msg.From = new MailAddress("enviar@gmail.com");
                msg.Subject = msgsubjet;
                msg.Body = msgbody;
                msg.IsBodyHtml = true;
                cliente.Send(msg);
                return "";
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return "No se puede enviar el Email, verifique su servidor de Correos.";
            }
        }
    }
}
