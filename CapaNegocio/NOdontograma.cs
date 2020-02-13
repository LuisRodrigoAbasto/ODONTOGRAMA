using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDato;
using CapaEntity;

namespace CapaNegocio
{
    public class NOdontograma
    {
        public static long save(EOdontograma Odontograma, DataTable dtDetalles, EAtencion atencion,EPaciente paciente, EUsers odontologo, EUsers empleado)
        {
            CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
            var db = cn.Database.BeginTransaction();
            try
            {
                odontograma Obj = new odontograma();
                Obj.fechaInicio = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                Obj.fechaFinal = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                Obj.estado = 1;
                Obj.tratamiento = Odontograma.tratamiento;
                Obj.montoTotal = Odontograma.montoTotal;
                cn.odontograma.Add(Obj);
                int result = cn.SaveChanges();

                foreach (DataRow row in dtDetalles.Rows)
                {
                    odontograma_detalle OD = new odontograma_detalle();
                    OD.odontogramaID = Obj.odontogramaID;
                    OD.dienteID = Convert.ToInt32(row["dienteID"].ToString());
                    OD.diagnosticoID = Convert.ToInt32(row["diagnosticoID"].ToString());
                    OD.procedimientoID = Convert.ToInt32(row["procedimientoID"].ToString());
                    OD.parteID = Convert.ToInt32(row["parteID"].ToString());
                    OD.realizado= Convert.ToString(row["realizado"].ToString());
                    OD.estado = 1;
                    cn.odontograma_detalle.Add(OD);
                    result = cn.SaveChanges() + result;
                }

                atencion atencionR = new atencion();
                atencionR.fecha = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                atencionR.hora = DateTime.Now.TimeOfDay;
                atencionR.importe = atencion.importe;
                atencionR.descripcion = atencion.descripcion;
                atencionR.estado = 1;
                atencionR.tipo = "TRATAMIENTO";
                atencionR.pacienteID = paciente.pacienteID;
                atencionR.odontologoID = odontologo.usuarioID;
                atencionR.empleadoID = empleado.usuarioID;
                cn.atencion.Add(atencionR);
                result = cn.SaveChanges() + result;
                int contador = 0;
                foreach (DataRow row in dtDetalles.Rows)
                {
                    if (Convert.ToString(row["realizado"].ToString()) == "SI")
                    {
                        contador++;
                        atencion_detalle atencionD = new atencion_detalle();
                        atencionD.atencionID = atencionR.atencionID;
                        atencionD.odontogramaID = Obj.odontogramaID;
                        atencionD.dienteID = Convert.ToInt32(row["dienteID"].ToString());
                        atencionD.diagnosticoID = Convert.ToInt32(row["diagnosticoID"].ToString());
                        atencionD.procedimientoID = Convert.ToInt32(row["procedimientoID"].ToString());
                        atencionD.parteID = Convert.ToInt32(row["parteID"].ToString());
                        atencionD.realizado = Convert.ToString(row["realizado"].ToString());
                        atencionD.estado = 1;
                        cn.atencion_detalle.Add(atencionD);
                        result = cn.SaveChanges() + result;
                    }
                }
                
                if (result >0 && contador!=0)
                {
                    db.Commit();
                    return atencionR.atencionID;
                }
                else
                {
                    db.Rollback();
                    throw new Exception("Error al guardar");
                }
            }
            catch (Exception ex)
            {
                db.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public static long update(EOdontograma Odontograma, DataTable dtDetalles, EAtencion atencion, EPaciente paciente, EUsers odontologo, EUsers empleado)
        {
            int result =0;
            CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
            var db = cn.Database.BeginTransaction();
            try
            {

                odontograma Obj = new odontograma();
                Obj = cn.odontograma.Find(Odontograma.odontogramaID);
                Obj.fechaFinal = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                Obj.odontogramaID = Odontograma.odontogramaID;
                Obj.tratamiento = Odontograma.tratamiento;
                Obj.montoTotal = Odontograma.montoTotal;
                Obj.estado = 1;
                result = cn.SaveChanges();

                List<odontograma_detalle> ODT = new List<odontograma_detalle>();
                ODT = (from od in cn.odontograma_detalle
                       where od.odontogramaID == Odontograma.odontogramaID
                       select od).ToList();
                foreach(var item in ODT)
                {
                    odontograma_detalle ODTF = new odontograma_detalle();
                    ODTF = (from dt in cn.odontograma_detalle
                            where dt.odontogramaID == Odontograma.odontogramaID &&
                            dt.dienteID == item.dienteID && dt.procedimientoID == item.procedimientoID &&
                            dt.diagnosticoID == item.diagnosticoID &&
                            dt.parteID == item.parteID
                            select dt).First();
                    ODTF.estado = 0;
                    cn.SaveChanges();
                }

                foreach (DataRow row in dtDetalles.Rows)
                {
                   
                    odontograma_detalle OD = new odontograma_detalle();
                    OD.odontogramaID = Obj.odontogramaID;
                    OD.dienteID = Convert.ToInt32(row["dienteID"].ToString());
                    OD.diagnosticoID = Convert.ToInt32(row["diagnosticoID"].ToString());
                    OD.procedimientoID = Convert.ToInt32(row["procedimientoID"].ToString());
                    OD.parteID = Convert.ToInt32(row["parteID"].ToString());                    

                    List<odontograma_detalle> ODL = new List<odontograma_detalle>();
                    ODL = (from dt in cn.odontograma_detalle
                          where dt.odontogramaID == OD.odontogramaID &&
                          dt.dienteID == OD.dienteID &&
                          dt.diagnosticoID == OD.diagnosticoID &&
                          dt.procedimientoID== OD.procedimientoID &&
                          dt.parteID == OD.parteID
                    select dt).ToList();
                    if (ODL.Count>0)
                    {
                        OD = (from od in cn.odontograma_detalle
                              where od.odontogramaID == Obj.odontogramaID &&
                              od.diagnosticoID == OD.diagnosticoID &&
                              od.procedimientoID == OD.procedimientoID &&
                              od.dienteID == OD.dienteID &&
                              od.parteID == OD.parteID
                              select od).First();                        
                        OD.realizado = Convert.ToString(row["realizado"].ToString());
                        OD.estado = 1;
                    }
                    else
                    {
                        OD.realizado = Convert.ToString(row["realizado"].ToString());
                        OD.estado = 1;
                        cn.odontograma_detalle.Add(OD);                        
                    }
                    result = cn.SaveChanges()+result;
                }
                atencion atencionR = new atencion();
                atencionR.fecha = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                atencionR.hora = DateTime.Now.TimeOfDay;
                atencionR.importe = atencion.importe;
                atencionR.descripcion = atencion.descripcion;
                atencionR.estado = 1;
                atencionR.tipo = "TRATAMIENTO";
                atencionR.pacienteID = paciente.pacienteID;
                atencionR.odontologoID = odontologo.usuarioID;
                atencionR.empleadoID = empleado.usuarioID;
                cn.atencion.Add(atencionR);
                result = cn.SaveChanges() + result;
                int contador = 0;
                foreach (DataRow row in dtDetalles.Rows)
                {
                    if (Convert.ToString(row["realizado"].ToString()) == "SI")
                    {
                        atencion_detalle atencionD = new atencion_detalle();
                        atencionD.atencionID = atencionR.atencionID;
                        atencionD.odontogramaID = Obj.odontogramaID;
                        atencionD.dienteID = Convert.ToInt32(row["dienteID"].ToString());
                        atencionD.diagnosticoID = Convert.ToInt32(row["diagnosticoID"].ToString());
                        atencionD.procedimientoID = Convert.ToInt32(row["procedimientoID"].ToString());
                        atencionD.parteID = Convert.ToInt32(row["parteID"].ToString());

                        List<atencion_detalle> cd = new List<atencion_detalle>();
                        cd = (from dt in cn.atencion_detalle
                              where dt.estado == 1
                              where dt.odontogramaID == atencionD.odontogramaID &&
                              dt.dienteID == atencionD.dienteID &&
                              dt.diagnosticoID == atencionD.diagnosticoID &&
                              dt.procedimientoID == atencionD.procedimientoID &&
                              dt.parteID == atencionD.parteID
                              select dt).ToList();
                        if (cd.Count == 0)
                        {
                            contador++;
                            atencionD.realizado = Convert.ToString(row["realizado"].ToString());
                            atencionD.estado = 1;
                            cn.atencion_detalle.Add(atencionD);
                            result = cn.SaveChanges() + result;
                        }
                    }

                }

                if (result > 0 && contador!=0)
                {
                    db.Commit();
                    return atencionR.atencionID;
                }
                else
                {
                    db.Rollback();
                    throw new Exception("Error al guardar");
                }
            }
            catch (Exception ex)
            {
                db.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public static long updateAtencion(EOdontograma Odontograma, DataTable dtDetalles, EAtencion atencion, EPaciente paciente, EUsers odontologo, EUsers empleado)
        {
            int result = 0;
            using (dbodontogramaEntity cn = new dbodontogramaEntity())
            {
                var db = cn.Database.BeginTransaction();
                try
                {

                    odontograma Obj = new odontograma();
                    Obj = cn.odontograma.Find(Odontograma.odontogramaID);
                    Obj.fechaFinal = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                    Obj.odontogramaID = Odontograma.odontogramaID;
                    Obj.tratamiento = Odontograma.tratamiento;
                    Obj.montoTotal = Odontograma.montoTotal;
                    Obj.estado = 1;
                    result = cn.SaveChanges();

                    List<odontograma_detalle> ODT = new List<odontograma_detalle>();
                    ODT = (from od in cn.odontograma_detalle
                           where od.odontogramaID == Odontograma.odontogramaID
                           select od).ToList();
                    foreach (var item in ODT)
                    {
                        odontograma_detalle ODTF = new odontograma_detalle();
                        ODTF = (from dt in cn.odontograma_detalle
                                where dt.odontogramaID == Odontograma.odontogramaID &&
                                dt.dienteID == item.dienteID && dt.procedimientoID == item.procedimientoID &&
                                dt.diagnosticoID == item.diagnosticoID &&
                                dt.parteID == item.parteID
                                select dt).First();
                        ODTF.estado = 0;
                        cn.SaveChanges();
                    }

                    foreach (DataRow row in dtDetalles.Rows)
                    {

                        odontograma_detalle OD = new odontograma_detalle();
                        OD.odontogramaID = Obj.odontogramaID;
                        OD.dienteID = Convert.ToInt32(row["dienteID"].ToString());
                        OD.diagnosticoID = Convert.ToInt32(row["diagnosticoID"].ToString());
                        OD.procedimientoID = Convert.ToInt32(row["procedimientoID"].ToString());
                        OD.parteID = Convert.ToInt32(row["parteID"].ToString());

                        List<odontograma_detalle> ODL = new List<odontograma_detalle>();
                        ODL = (from dt in cn.odontograma_detalle
                               where dt.odontogramaID == OD.odontogramaID &&
                               dt.dienteID == OD.dienteID &&
                               dt.diagnosticoID == OD.diagnosticoID &&
                               dt.procedimientoID == OD.procedimientoID &&
                               dt.parteID == OD.parteID
                               select dt).ToList();
                        if (ODL.Count > 0)
                        {
                            OD = (from od in cn.odontograma_detalle
                                  where od.odontogramaID == Obj.odontogramaID &&
                                  od.diagnosticoID == OD.diagnosticoID &&
                                  od.procedimientoID == OD.procedimientoID &&
                                  od.dienteID == OD.dienteID &&
                                  od.parteID == OD.parteID
                                  select od).First();
                            OD.realizado = Convert.ToString(row["realizado"].ToString());
                            OD.estado = 1;
                        }
                        else
                        {
                            OD.realizado = Convert.ToString(row["realizado"].ToString());
                            OD.estado = 1;
                            cn.odontograma_detalle.Add(OD);
                        }
                        result = cn.SaveChanges() + result;
                    }
                    atencion atencionR = new atencion();
                    atencionR = cn.atencion.Find(atencion.atencionID);
                    atencionR.fecha = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                    atencionR.hora = DateTime.Now.TimeOfDay;
                    atencionR.importe = atencion.importe;
                    atencionR.descripcion = atencion.descripcion;
                    atencionR.estado = 1;
                    atencionR.tipo = "TRATAMIENTO";
                    atencionR.pacienteID = paciente.pacienteID;
                    atencionR.odontologoID = odontologo.usuarioID;
                    atencionR.empleadoID = empleado.usuarioID;
                    result = cn.SaveChanges() + result;

                    List<atencion_detalle> CDT = new List<atencion_detalle>();
                    CDT = (from cd in cn.atencion_detalle
                           where cd.atencionID == atencionR.atencionID
                           select cd).ToList();
                    foreach (var item in CDT)
                    {
                        atencion_detalle CDTF = new atencion_detalle();
                        CDTF = (from dt in cn.atencion_detalle
                                where dt.odontogramaID == Odontograma.odontogramaID &&
                                dt.dienteID == item.dienteID && dt.procedimientoID == item.procedimientoID &&
                                dt.diagnosticoID == item.diagnosticoID &&
                                dt.parteID == item.parteID && dt.atencionID == atencionR.atencionID
                                select dt).First(); 
                        cn.atencion_detalle.Remove(CDTF);
                        cn.SaveChanges();
                    }
                    int contador = 0;
                    foreach (DataRow row in dtDetalles.Rows)
                    {
                        if (Convert.ToString(row["realizado"].ToString()) == "SI")
                        {
                            atencion_detalle atencionD = new atencion_detalle();
                            atencionD.atencionID = atencionR.atencionID;
                            atencionD.odontogramaID = Obj.odontogramaID;
                            atencionD.dienteID = Convert.ToInt32(row["dienteID"].ToString());
                            atencionD.diagnosticoID = Convert.ToInt32(row["diagnosticoID"].ToString());
                            atencionD.procedimientoID = Convert.ToInt32(row["procedimientoID"].ToString());
                            atencionD.parteID = Convert.ToInt32(row["parteID"].ToString());

                            List<atencion_detalle> cd = new List<atencion_detalle>();
                            cd = (from dt in cn.atencion_detalle
                                  where dt.odontogramaID == atencionD.odontogramaID &&
                                  dt.dienteID == atencionD.dienteID &&
                                  dt.diagnosticoID == atencionD.diagnosticoID &&
                                  dt.procedimientoID == atencionD.procedimientoID &&
                                  dt.parteID == atencionD.parteID
                                  select dt).ToList();
                            
                            if (cd.Count == 0)
                            {
                                contador++;
                                atencionD.realizado = Convert.ToString(row["realizado"].ToString());
                                atencionD.estado = 1;
                                cn.atencion_detalle.Add(atencionD);
                                result = cn.SaveChanges() + result;
                            }
                        }

                    }

                    if (result > 0 && contador != 0)
                    {
                        db.Commit();
                        return atencionR.atencionID;
                    }
                    else
                    {
                        db.Rollback();
                        throw new Exception("Error al guardar");
                    }
                }
                catch (Exception ex)
                {
                    db.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        public static string delete(EOdontograma Odontograma)
        {
            string rpta = "";
            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                odontograma Obj = new odontograma();
                //Obj = (from p in cn.paciente
                //       where p.id == Paciente.id
                //       select p).First();
                Obj = cn.odontograma.Find(Odontograma.odontogramaID);
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


        public static List<EOdontograma> mostrar(string nombre,string apellido,int pag)
        {
            try
            {
                List<EOdontograma> O = new List<EOdontograma>();
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    O = (from o in cn.odontograma
                         join od in cn.odontograma_detalle on o.odontogramaID equals od.odontogramaID
                         join d in cn.diente on od.dienteID equals d.dienteID
                         join par in cn.parte on od.parteID equals par.parteID
                         join tra in cn.tratamiento on od.diagnosticoID equals tra.tratamientoID
                         join pro in cn.tratamiento on od.procedimientoID equals pro.tratamientoID
                         join cd in cn.atencion_detalle on od.odontogramaID equals cd.odontogramaID
                         join c in cn.atencion on cd.atencionID equals c.atencionID

                         join pc in cn.paciente on c.pacienteID equals pc.pacienteID
                         where o.estado == 1
                         where pc.nombre.Contains(nombre)
                         where pc.apellido.Contains(apellido)

                         group o by new { o.odontogramaID, o.fechaInicio, o.fechaFinal, o.tratamiento, o.montoTotal, o.estado,pc.nombre,pc.apellido } into grupo
                         orderby grupo.Key.odontogramaID descending
                         select new EOdontograma
                         {
                             odontogramaID = grupo.Key.odontogramaID,
                             fechaInicio = grupo.Key.fechaInicio,
                             fechaFinal = grupo.Key.fechaFinal,
                             montoTotal = grupo.Key.montoTotal,
                             tratamiento = grupo.Key.tratamiento,
                             Paciente =  grupo.Key.nombre + " " + grupo.Key.apellido,
                             estado = grupo.Key.estado
                         }).ToList();


                    pag = pag * 10;
                   
                    var tabla = O.Skip(pag).Take(10);
                    if (O.Count < pag)
                    {
                        tabla = O.Skip(pag).Take(10);
                    }
                    
                    return tabla.ToList();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int mostrarTotal(string nombre, string apellido)
        {
            try
            {
                List<EOdontograma> OD = new List<EOdontograma>();
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    OD = (from o in cn.odontograma
                         join od in cn.odontograma_detalle on o.odontogramaID equals od.odontogramaID
                         join d in cn.diente on od.dienteID equals d.dienteID
                         join par in cn.parte on od.parteID equals par.parteID
                         join tra in cn.tratamiento on od.diagnosticoID equals tra.tratamientoID
                         join pro in cn.tratamiento on od.procedimientoID equals pro.tratamientoID
                         join cd in cn.atencion_detalle on od.odontogramaID equals cd.odontogramaID
                         join c in cn.atencion on cd.atencionID equals c.atencionID

                         join pc in cn.paciente on c.pacienteID equals pc.pacienteID
                         where o.estado == 1
                         where pc.nombre.Contains(nombre)
                         where pc.apellido.Contains(apellido)

                         group o by new { o.odontogramaID, o.fechaInicio, o.fechaFinal, o.tratamiento, o.montoTotal, o.estado, pc.nombre, pc.apellido } into grupo
                         orderby grupo.Key.odontogramaID descending
                         select new EOdontograma
                         {
                             odontogramaID = grupo.Key.odontogramaID,
                             fechaInicio = grupo.Key.fechaInicio,
                             fechaFinal = grupo.Key.fechaFinal,
                             montoTotal = grupo.Key.montoTotal,
                             tratamiento = grupo.Key.tratamiento,
                             Paciente = grupo.Key.nombre + " " + grupo.Key.apellido,
                             estado = grupo.Key.estado
                         }).ToList();

                    return OD.Count;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public static int mostrarAtencionID(int ID)
        {
            try
            {
               odontograma odontogramas = new odontograma();
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    odontogramas = (from o in cn.odontograma
                                    join ct in cn.atencion_detalle on o.odontogramaID equals ct.odontogramaID
                                    where o.estado == 1 && ct.atencion.atencionID == ID
                                    select o).First();
                    return odontogramas.odontogramaID;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public EOdontograma mostrarID(int ID)
        {
            try
            {
                EOdontograma Obj = new EOdontograma();
                //odontograma item = new odontograma();
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    Obj = (from o in cn.odontograma
                           join od in cn.odontograma_detalle on o.odontogramaID equals od.odontogramaID
                           join d in cn.diente on od.dienteID equals d.dienteID
                           join par in cn.parte on od.parteID equals par.parteID
                           join tra in cn.tratamiento on od.diagnosticoID equals tra.tratamientoID
                           join pro in cn.tratamiento on od.procedimientoID equals pro.tratamientoID
                           join cd in cn.atencion_detalle on od.odontogramaID equals cd.odontogramaID
                           join c in cn.atencion on cd.atencionID equals c.atencionID

                           join pc in cn.paciente on c.pacienteID equals pc.pacienteID
                           where o.estado == 1 
                           where o.odontogramaID==ID
                           group o by new { o.odontogramaID, o.fechaInicio, o.fechaFinal, o.tratamiento, o.montoTotal, o.estado, pc.nombre, pc.apellido } into grupo

                           select new EOdontograma
                           {
                               odontogramaID = grupo.Key.odontogramaID,
                               fechaInicio = grupo.Key.fechaInicio,
                               fechaFinal = grupo.Key.fechaFinal,
                               montoTotal = grupo.Key.montoTotal,
                               tratamiento = grupo.Key.tratamiento,
                               Paciente = grupo.Key.nombre + " " + grupo.Key.apellido,
                               estado = grupo.Key.estado
                           }).First();

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<EOdontograma> mostrarCliente(int pacienteID)
        {
            try
            {
                List<EOdontograma> O = new List<EOdontograma>();
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    O = (from o in cn.odontograma
                         join od in cn.odontograma_detalle on o.odontogramaID equals od.odontogramaID
                         join d in cn.diente on od.dienteID equals d.dienteID
                         join par in cn.parte on od.parteID equals par.parteID
                         join tra in cn.tratamiento on od.diagnosticoID equals tra.tratamientoID
                         join pro in cn.tratamiento on od.procedimientoID equals pro.tratamientoID
                         join cd in cn.atencion_detalle on od.odontogramaID equals cd.odontogramaID
                         join c in cn.atencion on cd.atencionID equals c.atencionID

                         join pc in cn.paciente on c.pacienteID equals pc.pacienteID
                         where o.estado == 1
                         where pc.pacienteID == pacienteID
                         group o by new { o.odontogramaID, o.fechaInicio, o.fechaFinal, o.tratamiento, o.montoTotal, o.estado, pc.nombre, pc.apellido } into grupo
                         orderby grupo.Key.odontogramaID descending
                         select new EOdontograma
                         {
                             odontogramaID = grupo.Key.odontogramaID,
                             fechaInicio = grupo.Key.fechaInicio,
                             fechaFinal = grupo.Key.fechaFinal,
                             montoTotal = grupo.Key.montoTotal,
                             tratamiento = grupo.Key.tratamiento,
                             Paciente = grupo.Key.nombre + " " + grupo.Key.apellido,
                             estado = grupo.Key.estado
                         }).ToList();
                   
                    return O;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
