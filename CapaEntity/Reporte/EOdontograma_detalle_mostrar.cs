using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntity
{
    public class EOdontograma_detalle_mostrar
    {
        public int odontogramaID { get; set; }
        public int dienteID { get; set; }
        public int parteID { get; set; }
        public int diagnosticoID { get; set; }
        public int procedimientoID { get; set; }

        public string diente { get; set; }
        public string parte { get; set; }
        public string diagnostico{ get; set; }
        public string colorD { get; set; }
        public string procedimiento { get; set; }
        public string colorP { get; set; }
        public Nullable<decimal> precio { get; set; }
        public string realizado { get; set; }
        public Nullable<int> vector { get; set; }
        public Nullable<int> estado { get; set; }



    }
}
