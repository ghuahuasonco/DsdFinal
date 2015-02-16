using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AF_ERESTServices
{
    public class Emails : IEmails
    {
        private EmailDAO dao = new EmailDAO();
        public Email E_mail(Email EnviarEmail)
        {
            return dao.Enviar(EnviarEmail);
        }
    }
}
