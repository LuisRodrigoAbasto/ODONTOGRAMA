using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntity;

namespace CapaNegocio
{
    public class NReportes
    {
        //public static EReporteUsuario mostrarDia()
        //{
            //EReporteUsuario resultado = new EReporteUsuario();
            //using (dbodontogramaEntity cn = new dbodontogramaEntity())
            //{
            //    resultado = (from emp in cn.users
            //                 join ate in cn.atencion on emp.usuarioID equals ate.empleadoID
            //                 join pa in cn.paciente on ate.pacienteID equals pa.pacienteID
            //                 //where ate.fecha == fecha
            //                 group emp by new { emp.nombre, emp.apellido,ate.importe, emp.tipo, pa.pacienteID } into grupo
            //                 select new EReporteUsuario
            //                 {
            //                     nombre = grupo.Key.nombre,
            //                     apellido = grupo.Key.apellido,
            //                     tipo = grupo.Key.tipo
            //                     //monto = grupo.Sum(ate=>ate)

            //                 }).ToList();
            //    return resultado;
            //}
        //}
    }
}
