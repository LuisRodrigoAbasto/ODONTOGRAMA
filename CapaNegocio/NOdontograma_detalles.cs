using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntity;

namespace CapaNegocio
{
    public class NOdontograma_detalle
    {
        public static long save(EOdontograma_detalle OD)
        {
            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                odontograma_detalle Obj = new odontograma_detalle();
                Obj.odontogramaID = OD.odontogramaID;
                Obj.dienteID = OD.dienteID;
                Obj.parteID = OD.parteID;
                Obj.diagnosticoID = OD.diagnosticoID;
                Obj.procedimientoID = OD.procedimientoID;
                Obj.estado = OD.estado;

                cn.odontograma_detalle.Add(Obj);
                int result = cn.SaveChanges();
                if (result > 0)
                {
                    return Obj.odontogramaID;
                }
                else
                {
                    throw new Exception("Error al guardar");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static long update(EOdontograma_detalle OD)
        {

            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                odontograma_detalle Obj = new odontograma_detalle();
                Obj = (from o in cn.odontograma_detalle
                       where o.odontogramaID == OD.odontogramaID
                       select o).First();

                Obj.odontogramaID = OD.odontogramaID;
                Obj.dienteID = OD.dienteID;
                Obj.parteID = OD.parteID;
                Obj.diagnosticoID = OD.diagnosticoID;
                Obj.procedimientoID = OD.procedimientoID;
                Obj.estado = OD.estado;

                int result = cn.SaveChanges();
                if (result > 0)
                {
                    return Obj.odontogramaID;
                }
                else
                {
                    throw new Exception("error al Editar");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string delete(EOdontograma_detalle OD)
        {
            string rpta = "";
            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                odontograma_detalle Obj = new odontograma_detalle();
                //Obj = (from p in cn.paciente
                //       where p.id == Paciente.id
                //       select p).First();
                Obj = cn.odontograma_detalle.Find(OD.odontogramaID);
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

        public static List<EOdontograma_detalle> mostrar(int ID)
        {
            try
            {
                List<EOdontograma_detalle> Odontogramas = new List<EOdontograma_detalle>();
                List<odontograma_detalle> odontogramas = new List<odontograma_detalle>();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    odontogramas = (from o in cn.odontograma_detalle
                                    where o.odontogramaID == ID
                                    where o.estado == 1
                                    orderby o.odontogramaID descending
                                    select o).ToList();
                    foreach (var item in odontogramas)
                    {
                        EOdontograma_detalle Obj = new EOdontograma_detalle();
                        Obj.odontogramaID = item.odontogramaID;
                        Obj.dienteID = item.dienteID;
                        Obj.parteID = item.parteID;
                        Obj.diagnosticoID = item.diagnosticoID;
                        Obj.procedimientoID = item.procedimientoID;
                        Obj.estado = item.estado;
                        Odontogramas.Add(Obj);
                    }
                    return Odontogramas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<EOdontograma_detalle_mostrar> OdontogramaDetalle(int ID)
        {
            try
            {
                List<EOdontograma_detalle_mostrar> Odontogramas = new List<EOdontograma_detalle_mostrar>();
                List<odontograma_detalle> odontogramas = new List<odontograma_detalle>();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    odontogramas = (from o in cn.odontograma_detalle
                                    where o.odontogramaID == ID
                                    where o.estado == 1
                                    select o).ToList();
                    foreach (var item in odontogramas)
                    {
                        EOdontograma_detalle_mostrar Obj = new EOdontograma_detalle_mostrar();
                        Obj.odontogramaID = item.odontogramaID;
                        Obj.dienteID = item.dienteID;
                        Obj.parteID = item.parteID;
                        Obj.parte = item.parte.nombre;
                        Obj.diagnosticoID = item.diagnosticoID;
                        Obj.diagnostico = item.diagnostico.nombre;
                        Obj.colorD = item.diagnostico.color;
                        Obj.procedimientoID = item.procedimientoID;
                        Obj.procedimiento = item.procedimiento.nombre;
                        Obj.colorP = item.procedimiento.color;
                        Obj.precio = item.procedimiento.precio;
                        Obj.realizado = item.realizado;
                        Obj.vector = item.diente.vector;
                        Obj.estado = item.estado;

                        Odontogramas.Add(Obj);
                    }
                    return Odontogramas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
