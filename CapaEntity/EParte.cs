using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntity
{
    public class EParte
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public EParte()
        //{
        //    this.odontograma_detalle = new HashSet<EOdontograma_detalle>();
        //}

        public int parteID { get; set; }
        public string nombre { get; set; }
        public Nullable<int> estado { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<EOdontograma_detalle> odontograma_detalle { get; set; }
    }
}
