using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AF_ERESTServices
{
    public class EmailDAO
    {
        public Email Enviar(Email EnviarEmail) {
            Email Emailenviado = null;
            SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
            cliente.EnableSsl = true;
            cliente.Timeout = 10000;
            cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
            cliente.UseDefaultCredentials = false;
            cliente.Credentials = new NetworkCredential("ghuahuasonco@gmail.com", "Kross986280383Kross");
            MailMessage msg = new MailMessage();
            msg.To.Add(EnviarEmail.msgto);
            msg.From = new MailAddress("ghuahuasonco@gmail.com");
            msg.Subject = EnviarEmail.msgsubjet;
            msg.Body = EnviarEmail.msgbody;
            msg.IsBodyHtml = true;
            cliente.Send(msg);
            return Emailenviado;
        }
    }
}