using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntity
{
    public class EReporteUsuario
    {
        public int usuarioID { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tipo { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<decimal> monto { get; set; }
    }
}
