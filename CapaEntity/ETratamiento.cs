using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntity
{
    public class ETratamiento
    {
        public int tratamientoID { get; set; }
        public string nombre { get; set; }
        public string color { get; set; }
        public Nullable<decimal> precio { get; set; }
        public string tipo { get; set; }
        public Nullable<int> estado { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<EOdontograma_detalle> odontograma_detalle { get; set; }
    }
}
