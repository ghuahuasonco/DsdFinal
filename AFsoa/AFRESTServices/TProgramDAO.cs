using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AFRESTServices
{
    public class TProgramDAO
    {
        public List<TProgram> ObtenerTProgram() {
            TProgram TPEncontrado = null;
            List<TProgram> TPLista = new List<TProgram>();
            string sql = "SELECT LTRIM(RTRIM(CONVERT(CHAR(10),CODTPG))) AS CODGTP,DESTPG AS DESCTP,CONVERT(CHAR(10),TPGFIN,126)+'  '+CONVERT(CHAR(10),TPGFFI,126) AS TPFECHA FROM AFTPROGRAM ORDER BY TPGFIN";
            SqlConnection con = new SqlConnection(TPConexion.CadenaCone);
            SqlCommand com = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader TPResultado = com.ExecuteReader();
                    
            while (TPResultado.Read()) {
                TPEncontrado = new TProgram() {
                    CodigoTP = (string)TPResultado["CODGTP"],
                    DescripcionTP = (string)TPResultado["DESCTP"],
                    FechaTP = (string)TPResultado["TPFECHA"]
                };
                TPLista.Add(TPEncontrado);
            }
            return TPLista;
        }
    }
}