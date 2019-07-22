using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntity
{
    public class EAtencion
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public ECita()
        //{
        //    this.cita_detalle = new HashSet<ECita_detalle>();
        //}

        public int atencionID { get; set; }
        public Nullable<int> pacienteID { get; set; }
        public Nullable<int> empleadoID { get; set; }
        public Nullable<int> odontologoID { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<System.TimeSpan> hora { get; set; }
        public Nullable<decimal> importe { get; set; }
        public string descripcion { get; set; }
        public string tipo { get; set; }
        public Nullable<int> estado { get; set; }
        public string Paciente { get; set; }
        public string Odontologo { get; set; }
        public string Empleado { get; set; }

        //public virtual EUsers empleado { get; set; }
        //public virtual EUsers odontologo { get; set; }
        //public virtual EPaciente paciente { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ECita_detalle> cita_detalle { get; set; }
    }
}
