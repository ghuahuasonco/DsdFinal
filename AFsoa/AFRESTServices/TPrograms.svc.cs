using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AFRESTServices
{
    public class TPrograms : ITPrograms
    {
        private TProgramDAO dao = new TProgramDAO();
        public List<TProgram> ListarTProgram()
        {
            return dao.ObtenerTProgram();
        }
    }
}
