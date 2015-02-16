using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AF_Msmq
{
    public partial class Frmsqm : Form
    {

        int contador = 0;
        int minuto = 0;
        public Frmsqm()
        {
            InitializeComponent();
            
        }

        private void Frmsqm_Load(object sender, EventArgs e)
        {
            timerE.Enabled = true;
            EmailNoEnviados();
        }

        private void enviarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailNoEnviados();
        }

        private void leerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LeerEmail();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public string CadenaConexion()
        {
            return "Data Source = ghuahuasonco; Initial Catalog = BD_AF; Integrated Security = True";
        }

        public void EmailNoEnviados()
        {
            string rutacola = @".\private$\EmailNoEnviado";
            if (!MessageQueue.Exists(rutacola))
            {
                SqlConnection cone = new SqlConnection(CadenaConexion());
                cone.Open();

                SqlDataAdapter cmd = new SqlDataAdapter("SELECT LTRIM(RTRIM(A.PERTNOM)) AS NOMBRE,B.DESTPG AS TPGM FROM AFPERSONAL A, AFTPROGRAM B WHERE A.EMAILSTD=2 AND  A.CODTPG =B.CODTPG", cone);
                System.Data.DataTable dt = new System.Data.DataTable();
                cmd.Fill(dt);

                String lista = "";
                String tpdesc= "";
                String tpdescs="";
                int numero = 0;
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    numero = numero + 1;
                    if (numero == 1)
                    {
                        tpdesc = row["TPGM"].ToString().Trim();
                        tpdescs = "* "+tpdesc + "\n";
                    }
                    else { tpdescs = ""; }
                    if (tpdesc != row["TPGM"].ToString().Trim()) {
                        tpdesc = row["TPGM"].ToString().Trim();
                        tpdescs = "* "+tpdesc + "\n";
                    }

                    lista = lista + tpdescs + "     - " + row["NOMBRE"].ToString().Trim() + "\n";
                }
                contador = numero;

                switch (lista.Length) { 
                    case 0:
                        break;
                    default:
                            MessageQueue.Create(rutacola);
                            MessageQueue cola = new MessageQueue(rutacola);
                            System.Messaging.Message mensaje = new System.Messaging.Message();
                            mensaje.Label = "Emails No Enviados";
                            mensaje.Body = new EmailEN { EmailMsg = lista };
                            cola.Send(mensaje);
                            break;
                }
            }
        }

        public class EmailEN
        {
            public string EmailMsg { get; set; }
        }

        public void LeerEmail()
        {
            string rutacola = @".\private$\EmailNoEnviado";
            if (!MessageQueue.Exists(rutacola))
                MessageQueue.Create(rutacola);
            MessageQueue cola = new MessageQueue(rutacola);

            cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(EmailEN) });
            System.Messaging.Message mensaje = cola.Receive();
            EmailEN MsgEN = (EmailEN)mensaje.Body;

            notifyIconE.Visible = true;
            notifyIconE.BalloonTipTitle = mensaje.Label;
            notifyIconE.BalloonTipText = MsgEN.EmailMsg;
            notifyIconE.BalloonTipIcon = ToolTipIcon.Info;
            notifyIconE.ShowBalloonTip(100000);

            if (MessageQueue.Exists(rutacola))
                MessageQueue.Delete(rutacola);
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
            notifyIconE.Visible = !this.Visible;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            this.Hide();
            notifyIconE.Visible = true;
        }

        private void timerE_Tick(object sender, EventArgs e)
        {
            switch(minuto){
                case 20:
                    timerE.Enabled = false;
                    EmailNoEnviados();
                    minuto = 0;
                    timerE.Enabled = true;
                    break;
                default:
                    switch (contador) {
                        case 0:
                            break;
                        default:
                            this.Hide();
                            LeerEmail();
                            contador = 0;
                            break;
                    }
                    minuto = minuto + 1;
                    break;
            
            }

        }
    }
}
