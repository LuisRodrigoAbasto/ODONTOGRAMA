using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntity;

namespace CapaNegocio
{
    public class NAtencion_detalle
    {
        public static List<EAtencion_detalle> mostrar(int ID)
        {
            try
            {
                List<EAtencion_detalle> EDetalle = new List<EAtencion_detalle>();
                List<atencion_detalle> DDetalle = new List<atencion_detalle>();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    DDetalle = (from c in cn.atencion_detalle
                                where c.estado == 1
                                where c.atencion.pacienteID == ID
                                    
                                    select c).ToList();
                    foreach (var item in DDetalle)
                    {
                        EAtencion_detalle Obj = new EAtencion_detalle();
                        Obj.odontogramaID = item.odontogramaID;
                        Obj.atencionID = item.atencionID;
                        Obj.estado = item.estado;
                        EDetalle.Add(Obj);
                    }
                    return EDetalle;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static long mostrarIDO(int ID)
        {
            try
            {
                atencion_detalle Detalle = new atencion_detalle();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    Detalle = (from c in cn.atencion_detalle
                               where c.atencionID == ID
                               select c).First();
                    
                    return Detalle.odontogramaID;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EAtencion_detalle mostrarTodo (int ID)
        {
            try
            {
                EAtencion_detalle EDetalle = new EAtencion_detalle();
                atencion_detalle DDetalle = new atencion_detalle();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    DDetalle = (from c in cn.atencion_detalle
                                where c.estado == 1
                                where c.atencion.pacienteID == 2
                                select c).First();
                    
                    return EDetalle;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<EOdontograma_detalle_mostrar> detalleAtencion(int atencionID)
        {
            try
            {
                List<EOdontograma_detalle_mostrar> Odontogramas = new List<EOdontograma_detalle_mostrar>();
                List<atencion_detalle> cd = new List<atencion_detalle>();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    cd = (from c in cn.atencion_detalle
                                    where c.atencionID == atencionID
                                    where c.estado == 1
                                    select c).ToList();
                    foreach (var item in cd)
                    {
                        EOdontograma_detalle_mostrar Obj = new EOdontograma_detalle_mostrar();
                        Obj.vector = item.odontograma_detalle.diente.vector;
                        Obj.odontogramaID = item.odontogramaID;
                        Obj.dienteID = item.dienteID;
                        Obj.parteID = item.parteID;
                        Obj.parte = item.odontograma_detalle.parte.nombre;
                        Obj.diagnosticoID = item.diagnosticoID;
                        Obj.diagnostico = item.odontograma_detalle.diagnostico.nombre;
                        Obj.colorD = item.odontograma_detalle.diagnostico.color;
                        Obj.procedimientoID = item.procedimientoID;
                        Obj.procedimiento = item.odontograma_detalle.procedimiento.nombre;
                        Obj.colorP = item.odontograma_detalle.procedimiento.color;
                        Obj.precio = item.odontograma_detalle.procedimiento.precio;
                        Obj.realizado = item.realizado;
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
