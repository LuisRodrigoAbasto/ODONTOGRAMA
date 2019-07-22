using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntity
{
    public class EUsers
    {
        public int usuarioID { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tipo { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public Nullable<int> estado { get; set; }
    }
}
