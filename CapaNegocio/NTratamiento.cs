using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntity;

namespace CapaNegocio
{
    public class NTratamiento
    {
        public static long save(ETratamiento tratamiento)
        {
            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                List<tratamiento> tratamientos = new List<tratamiento>();
                tratamiento Obj = new tratamiento();

                tratamientos = (from d in cn.tratamiento
                                where d.nombre == tratamiento.nombre || d.color == tratamiento.color
                                select d).ToList();

                if (tratamientos.Count > 1)
                {
                    throw new Exception("Ingrese Otro Tratamiento o Seleccione Otro Color");
                }


                Obj.nombre = tratamiento.nombre;
                Obj.color = tratamiento.color;
                if (Obj.nombre == string.Empty && Obj.color == string.Empty)
                {
                    throw new Exception("Ingrese Nombre y el Color");
                }
                
                Obj.tipo = tratamiento.tipo;
                Obj.precio = tratamiento.precio; 
                Obj.estado = 1;
                cn.tratamiento.Add(Obj);
                int result = cn.SaveChanges();
                if (result > 0)
                {
                    return Obj.tratamientoID;
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

        public static long update(ETratamiento tratamiento)
        {

            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                List<tratamiento> tratamientos = new List<tratamiento>();
                tratamiento Obj = new tratamiento();
                
                tratamientos = (from d in cn.tratamiento
                                where d.nombre == tratamiento.nombre 
                                || d.color == tratamiento.color
                                select d).ToList();

                if (tratamientos.Count > 1)
                {
                    throw new Exception("Ingrese Otro Tratamiento, O Seleccione Otro Color");
                }


                Obj = (from d in cn.tratamiento
                       where d.tratamientoID == tratamiento.tratamientoID
                       select d).First();

                Obj.nombre = tratamiento.nombre;
                Obj.color = tratamiento.color;
                Obj.tipo = tratamiento.tipo;
                Obj.precio = tratamiento.precio;
                Obj.estado = 1;

                int result = cn.SaveChanges();
                if (result > 0)
                {
                    return Obj.tratamientoID;
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

        public static string delete(ETratamiento tratamiento)
        {
            string rpta = "";
            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                tratamiento Obj = new tratamiento();
                Obj = cn.tratamiento.Find(tratamiento.tratamientoID);
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

        public static List<ETratamiento> mostrar(string texto, int pag)
        {
            try
            {
                List<ETratamiento> ETratamientos = new List<ETratamiento>();
                List<tratamiento> tratamientos = new List<tratamiento>();
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {

                    tratamientos = (from d in cn.tratamiento
                                    where d.estado == 1
                                    where d.nombre.Contains(texto)
                                    orderby d.tratamientoID descending
                                    select d).ToList();

                    pag = pag * 10;
                    var tabla = tratamientos.Skip(pag).Take(10);
                    if (tratamientos.Count < pag)
                    {
                        tabla = tratamientos.Skip(pag).Take(10);
                    }

                    foreach (var item in tabla)
                    {
                        ETratamiento Obj = new ETratamiento();
                        Obj.tratamientoID = item.tratamientoID;
                        Obj.nombre = item.nombre;
                        Obj.color = item.color;
                        Obj.tipo = item.tipo;
                        Obj.precio = item.precio;
                        Obj.estado = item.estado;

                        ETratamientos.Add(Obj);
                    }

                    return ETratamientos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<ETratamiento> mostrarTipo(string texto,string tipo)
        {
            try
            {
                List<ETratamiento> ETratamientos = new List<ETratamiento>();
                List<tratamiento> tratamientos = new List<tratamiento>();
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    tratamientos = (from d in cn.tratamiento
                                    where d.estado == 1
                                    where d.tipo==tipo
                                    where d.nombre.Contains(texto)
                                    select d).ToList();
                    foreach (var item in tratamientos)
                    {
                        ETratamiento Obj = new ETratamiento();
                        Obj.tratamientoID = item.tratamientoID;
                        Obj.nombre = item.nombre;
                        Obj.color = item.color;
                        Obj.tipo = item.tipo;
                        Obj.precio = item.precio;
                        Obj.estado = item.estado;

                        ETratamientos.Add(Obj);
                    }

                    return ETratamientos;
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
                List<tratamiento> tratamientos = new List<tratamiento>();
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {

                    tratamientos = (from d in cn.tratamiento
                                    where d.estado == 1
                                    where d.nombre.Contains(texto)
                                    select d).ToList();     

                    return tratamientos.Count;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
