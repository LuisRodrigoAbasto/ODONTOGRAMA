using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntity;

namespace CapaNegocio
{
    public class NDiente
    {
        public static long save(EDiente Diente)
        {
            try
            {

                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                List<diente> dientes = new List<diente>();
                diente Obj = new diente();

                dientes = (from d in cn.diente
                           where d.dienteID == Diente.dienteID && d.nombre == Diente.nombre
                           select d).ToList();

                if (dientes.Count > 0)
                {
                    throw new Exception("El Diente Ya Existe");
                }
                Obj.dienteID = Diente.dienteID;
                Obj.nombre = Diente.nombre;
                Obj.estado = 1;
                if (Obj.nombre == string.Empty)
                {
                    throw new Exception("ingrese el Nombre del diente");
                }

                cn.diente.Add(Obj);
                int result = cn.SaveChanges();
                if (result > 0)
                {
                    return Obj.dienteID;
                }
                else
                {
                    throw new Exception("error al guardar");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static long update(EDiente Diente)
        {

            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                List<diente> dientes = new List<diente>();
                diente Obj = new diente();

                dientes = (from d in cn.diente
                           where d.nombre == Diente.nombre && d.dienteID == Diente.dienteID
                           select d).ToList();

                if (dientes.Count > 0)
                {
                    throw new Exception("El Diente Ya Existe");
                }


                Obj = (from p in cn.diente
                       where p.dienteID == Diente.dienteID
                       select p).First();

                Obj.dienteID = Diente.dienteID;
                Obj.nombre = Diente.nombre;
                Obj.estado = 1;
                int result = cn.SaveChanges();
                if (result > 0)
                {
                    return Obj.dienteID;
                }
                else
                {
                    throw new Exception("No Hubo Ningun Cambio al Editar");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string delete(EDiente Diente)
        {
            string rpta = "";
            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                diente Obj = new diente();
                //Obj = (from p in cn.paciente
                //       where p.id == Paciente.id
                //       select p).First();
                Obj = cn.diente.Find(Diente.dienteID);
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

        public static List<EDiente> mostrar(string texto, int pag)
        {
            try
            {
                List<EDiente> dientes = new List<EDiente>();
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    dientes = (from d in cn.diente
                               where d.estado == 1
                               where d.nombre.Contains(texto)
                               orderby d.dienteID descending
                               select new EDiente {dienteID=d.dienteID,nombre=d.nombre,
                                   vector =d.vector,estado=d.estado }).ToList();
                    pag = pag * 10;
                    var tabla = dientes.Skip(pag).Take(10);
                    if (dientes.Count < pag)
                    {
                        tabla = dientes.Skip(pag).Take(10);
                    }
                   

                    return tabla.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int mostrarTotal(string texto)
        {
            try
            {
                List<EDiente> dientes = new List<EDiente>();
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    dientes = (from d in cn.diente
                               where d.estado == 1
                               where d.nombre.Contains(texto)
                               orderby d.dienteID descending
                               select new EDiente
                               {
                                   dienteID = d.dienteID,
                                   nombre = d.nombre,
                                   vector = d.vector,
                                   estado = d.estado
                               }).ToList();

                    return dientes.Count;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 

        public static string mostrarNro(int nro)
        {
            string rpta = "";
            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                diente Obj = new diente();
                Obj = cn.diente.Find(nro);
                rpta = Obj.nombre;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rpta;
        }


    }

}
