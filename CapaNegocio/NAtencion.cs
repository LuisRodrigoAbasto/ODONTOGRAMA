using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntity;

namespace CapaNegocio
{
    public class NAtencion
    {
        public static long save(EAtencion Atencion)
        {
            try
            {
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    atencion Obj = new atencion();
                    Obj.pacienteID = Atencion.pacienteID;
                    Obj.empleadoID = Atencion.empleadoID;
                    Obj.odontologoID = Atencion.odontologoID;
                    Obj.fecha = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                    Obj.hora = Atencion.hora;
                    Obj.importe = Atencion.importe;
                    Obj.descripcion = Atencion.descripcion;

                    Obj.estado = 1;
                    cn.atencion.Add(Obj);
                    int result = cn.SaveChanges();
                    if (result > 0)
                    {
                        return Obj.atencionID;
                    }
                    else
                    {
                        throw new Exception("Error Al guardar El Registro");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static long update(EAtencion Atencion)
        {

            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                List<atencion> atencions = new List<atencion>();
                atencion Obj = new atencion();

                if (atencions.Count > 1)
                {
                    throw new Exception("El atencion Ya Existe");
                }

                Obj = (from p in cn.atencion
                       where p.atencionID == Atencion.atencionID
                       select p).First();

                Obj.pacienteID = Atencion.pacienteID;
                Obj.empleadoID = Atencion.empleadoID;
                Obj.odontologoID = Atencion.odontologoID;
                Obj.fecha = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                Obj.hora = Atencion.hora;
                Obj.importe = Atencion.importe;
                Obj.descripcion = Atencion.descripcion;

                Obj.estado = 1;
                int result = cn.SaveChanges();
                if (result > 0)
                {
                    return Obj.atencionID;
                }
                else
                {
                    throw new Exception("No hubo Ningun Cambio al Editar");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //expresiones Landan y Delegados
        //user Control 
        public static string delete(EAtencion Atencion)
        {
            string rpta = "";
            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                atencion Obj = new atencion();
                Obj = cn.atencion.Find(Atencion.atencionID);
                rpta = Obj.estado == 1 ? "OK" : "No se Puede Eliminar el Registro";
                Obj.estado = 0;
                cn.SaveChanges();
            }
            catch (Exception ex)
            {
                rpta = (ex.Message);
            }
            return rpta;
        }

        public static List<EAtencion> mostrar(int pag)
        {
            try
            {
                List<EAtencion> Atencion = new List<EAtencion>();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    Atencion = (from p in cn.atencion
                                 join cd in cn.atencion_detalle on p.atencionID equals cd.atencionID
                                 join pc in cn.paciente on p.pacienteID equals pc.pacienteID
                                 join em in cn.users on p.empleado.usuarioID equals em.usuarioID
                                 join odon in cn.users on p.odontologo.usuarioID equals odon.usuarioID
                                 where p.estado == 1
                                 group p by new { p.atencionID, p.pacienteID, p.empleadoID, p.odontologoID, p.fecha, p.importe,
                                 p.descripcion,p.tipo, p.hora, p.estado, p.odontologo, p.empleado, p.paciente } into item

                                 orderby item.Key.atencionID descending
                                 select new EAtencion
                                 {
                                     atencionID = item.Key.atencionID,
                                     pacienteID = item.Key.pacienteID,
                                     empleadoID = item.Key.empleadoID,
                                     odontologoID = item.Key.odontologoID,
                                     fecha = item.Key.fecha,
                                     tipo=item.Key.tipo,
                                     hora = item.Key.hora,
                                     importe = item.Key.importe,
                                     descripcion = item.Key.descripcion,
                                     Odontologo = item.Key.odontologo.nombre + " " + item.Key.odontologo.apellido,
                                     Paciente = item.Key.paciente.nombre + " " + item.Key.paciente.apellido,
                                     Empleado = item.Key.empleado.nombre + " " + item.Key.empleado.apellido,
                                     estado = item.Key.estado
                                 }).ToList();

                    pag = pag * 10;
                    var tabla = Atencion.Skip(pag).Take(10);
                    if (Atencion.Count < pag)
                    {
                        tabla = Atencion.Skip(pag).Take(10);
                    }
                    
                    return Atencion.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<EAtencion> mostrarReporteAtencionRango(DateTime inicio, DateTime fin)
        {
            try
            {
                List<EAtencion> Atencions = new List<EAtencion>();
                List<atencion> atencions = new List<atencion>();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    atencions = (from p in cn.atencion

                             where p.estado == 1
                             where p.fecha >= inicio.Date && p.fecha <= fin.Date
                             select p).ToList();


                    foreach (var item in atencions)
                    {
                        EAtencion Obj = new EAtencion();
                        Obj.atencionID = item.atencionID;
                        Obj.pacienteID = item.pacienteID;
                        Obj.empleadoID = item.empleadoID;
                        Obj.odontologoID = item.odontologoID;
                        Obj.fecha = item.fecha;
                        Obj.hora = item.hora;
                        Obj.importe = item.importe;
                        Obj.tipo = item.tipo;
                        Obj.descripcion = item.descripcion;
                        Obj.Odontologo = item.odontologo.nombre + " " + item.odontologo.apellido;
                        Obj.Paciente = item.paciente.nombre + " " + item.paciente.apellido;
                        Obj.Empleado = item.empleado.nombre + " " + item.empleado.apellido;
                        Obj.estado = item.estado;
                        Atencions.Add(Obj);
                    }
                    return Atencions;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<EAtencion> mostrarClienteID(int ID)
        {
            try
            {
                List<EAtencion> Atencions = new List<EAtencion>();
                List<atencion> atencions = new List<atencion>();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    atencions = (from p in cn.atencion
                             where p.estado == 1
                             where p.paciente.pacienteID==ID
                             select p).ToList();

                    foreach (var item in atencions)
                    {
                        EAtencion Obj = new EAtencion();
                        Obj.atencionID = item.atencionID;
                        Obj.pacienteID = item.pacienteID;
                        Obj.empleadoID = item.empleadoID;
                        Obj.odontologoID = item.odontologoID;
                        Obj.fecha = item.fecha;
                        Obj.hora = item.hora;
                        Obj.tipo = item.tipo;
                        Obj.importe = item.importe;
                        Obj.descripcion = item.descripcion;
                        Obj.Odontologo = item.odontologo.nombre + " " + item.odontologo.apellido;
                        Obj.Paciente = item.paciente.nombre + " " + item.paciente.apellido;
                        Obj.Empleado = item.empleado.nombre + " " + item.empleado.apellido;
                        Obj.estado = item.estado;
                        Atencions.Add(Obj);
                    }
                    return Atencions;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public EAtencion mostrarAtencionID(int ID)
        {
            try
            {
                EAtencion Obj = new EAtencion();
                atencion item = new atencion();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    item = (from p in cn.atencion
                             where p.estado == 1
                             where p.atencionID == ID
                             select p).First();

                    
                    Obj.atencionID = item.atencionID;
                    Obj.pacienteID = item.pacienteID;
                    Obj.empleadoID = item.empleadoID;
                    Obj.odontologoID = item.odontologoID;
                    Obj.fecha = item.fecha;
                    Obj.hora = item.hora;
                    Obj.tipo = item.tipo;
                    Obj.importe = item.importe;
                    Obj.descripcion = item.descripcion;
                    Obj.Odontologo = item.odontologo.nombre + " " + item.odontologo.apellido;
                    Obj.Paciente = item.paciente.nombre + " " + item.paciente.apellido;
                    Obj.Empleado = item.empleado.nombre + " " + item.empleado.apellido;
                    Obj.estado = item.estado;

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<EAtencion> mostrarOdontogramaAtencion(int ID)
        {
            try
            {
                List<EAtencion> Atencion = new List<EAtencion>();
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    Atencion = (from p in cn.atencion join cd in cn.atencion_detalle on p.atencionID equals cd.atencionID
                                 join pc in cn.paciente on p.pacienteID equals pc.pacienteID
                                 join em in cn.users on p.empleado.usuarioID equals em.usuarioID
                                 join odon in cn.users on p.odontologo.usuarioID equals odon.usuarioID
                             where p.estado == 1
                             where cd.odontogramaID==ID
                             group p by new {p.atencionID,p.pacienteID,p.empleadoID,p.odontologoID,p.fecha, p.importe, p.descripcion ,p.tipo, p.hora,p.estado,p.odontologo,p.empleado,p.paciente} into item
                             
                             orderby item.Key.atencionID descending
                             select new EAtencion {atencionID = item.Key.atencionID,
                    pacienteID = item.Key.pacienteID,
                    empleadoID = item.Key.empleadoID,
                    odontologoID = item.Key.odontologoID,
                    fecha = item.Key.fecha,
                    tipo = item.Key.tipo,
                    hora = item.Key.hora,
                    importe = item.Key.importe,
                    descripcion = item.Key.descripcion,
                    Odontologo = item.Key.odontologo.nombre + " " + item.Key.odontologo.apellido,
                    Paciente = item.Key.paciente.nombre + " " + item.Key.paciente.apellido,
                    Empleado = item.Key.empleado.nombre + " " + item.Key.empleado.apellido,
                    estado = item.Key.estado
                }).ToList();

                    
                    return Atencion;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public static int mostrarTotal()
        {
            try
            {
                List<atencion> atencions = new List<atencion>();
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    atencions = (from c in cn.atencion
                             where c.estado == 1
                             orderby c.atencionID descending
                             select c).ToList();
                    return atencions.Count;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
