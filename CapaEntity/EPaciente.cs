using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntity
{
    public class EPaciente
    {
        //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //    public EPaciente()
        //    {
        //        this.cita = new HashSet<ECita>();
        //    }

        public int pacienteID { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string ci { get; set; }
        public string telefono { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public string direccion { get; set; }
        public string sexo { get; set; }
        public Nullable<int> estado { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ECita> cita { get; set; }
    }
}
