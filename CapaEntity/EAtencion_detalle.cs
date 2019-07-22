using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntity
{
    public class EAtencion_detalle
    {
        public int atencionID { get; set; }
        public int odontogramaID { get; set; }
        public int dienteID { get; set; }
        public int parteID { get; set; }
        public int diagnosticoID { get; set; }
        public int procedimientoID { get; set; }
        public string realizado { get; set; }
        public Nullable<int> estado { get; set; }
    }
}
