using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntity;

namespace CapaNegocio
{
    public class NParte
    {
        public static long save(EParte Parte)
        {
            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                List<parte> partes = new List<parte>();
                parte Obj = new parte();

                partes = (from t in cn.parte
                         where t.nombre == Parte.nombre
                         select t).ToList();

                if (partes.Count > 0)
                {
                    throw new Exception("El Parte Ya Existe");
                }


                Obj.nombre = Parte.nombre;
                cn.parte.Add(Obj);
                int result = cn.SaveChanges();
                if (result > 0)
                {
                    return Obj.parteID;
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

        public static long update(EParte Parte)
        {

            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                List<parte> partes = new List<parte>();
                parte Obj = new parte();

                partes = (from t in cn.parte
                         where t.nombre == Parte.nombre
                         select t).ToList();

                if (partes.Count > 0)
                {
                    throw new Exception("El parte Ya Existe");
                }


                Obj = (from t in cn.parte
                       where t.parteID == Parte.parteID
                       select t).First();

                Obj.nombre = Parte.nombre;


                int result = cn.SaveChanges();
                if (result > 0)
                {
                    return Obj.parteID;
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

        public static string delete(EParte Parte)
        {
            string rpta = "";
            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                parte Obj = new parte();
                //Obj = (from p in cn.paciente
                //       where p.id == Paciente.id
                //       select p).First();
                Obj = cn.parte.Find(Parte.parteID);

                cn.SaveChanges();
            }
            catch (Exception ex)
            {
                rpta = (ex.Message);
            }
            return rpta;
        }


        public static List<EParte> mostrar(string texto)
        {
            try
            {
                List<EParte> Partes = new List<EParte>();
                List<parte> partes = new List<parte>();
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    partes = (from t in cn.parte
                              where t.estado == 1
                              where t.nombre.Contains(texto)
                              orderby t.parteID descending
                              select t).ToList();
                    foreach (var item in partes)
                    {
                        EParte Obj = new EParte();
                        Obj.parteID = item.parteID;
                        Obj.nombre = item.nombre;
                        Obj.estado = item.estado;
                        Partes.Add(Obj);
                    }

                    return Partes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string mostrarNombre(int ID)
        {
            try
            {
                parte partes = new parte();
               

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    partes =cn.parte.Find(ID);
                    
                    return partes.nombre;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
