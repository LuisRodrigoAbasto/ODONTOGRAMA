using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntity
{

    public class EOdontograma
    {
        public int odontogramaID { get; set; }
        public Nullable<System.DateTime> fechaInicio { get; set; }
        public Nullable<System.DateTime> fechaFinal { get; set; }
        public Nullable<decimal> montoTotal { get; set; }
        public string tratamiento { get; set; }
        public Nullable<int> estado { get; set; }
        public string Paciente { get; set; }
    }
}
