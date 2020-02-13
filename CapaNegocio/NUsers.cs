using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntity;

namespace CapaNegocio
{
    public class NUsers
    {


        public static long save(EUsers Usuario)
        {
            try
            {


                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                List<users> user = new List<users>();
                users Obj = new users();

                user = (from u in cn.users
                        where u.nombre == Usuario.nombre && u.apellido == Usuario.apellido
                        select u).ToList();

                if (user.Count > 0)
                {
                    throw new Exception("El Nombre y Apellido Del Usuario Ya Existe");
                }
                user = (from u in cn.users
                        where u.usuario == Usuario.usuario
                        select u).ToList();

                if (user.Count > 0)
                {
                    throw new Exception("El Usuario Ya Existe");
                }

                Obj.nombre = Usuario.nombre;
                Obj.apellido = Usuario.apellido;
                Obj.tipo = Usuario.tipo;
                if (Obj.nombre == string.Empty && Obj.apellido == string.Empty)
                {
                    throw new Exception("Ingrese Nombre y Apellido");
                }
                Obj.usuario = Usuario.usuario;
                Obj.password = Usuario.password;
                Obj.estado = 1;
                cn.users.Add(Obj);
                int result = cn.SaveChanges();
                if (result > 0)
                {
                    return Obj.usuarioID;
                }
                else
                {
                    throw new Exception("Error Al guardar El Registro");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static long update(EUsers Usuario)
        {
            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                List<users> usuarios = new List<users>();
                users Obj = new users();

                usuarios = (from u in cn.users
                            where u.nombre == Usuario.nombre && u.apellido == Usuario.apellido
                            select u).ToList();

                if (usuarios.Count >= 2)
                {
                    throw new Exception("El Usuario Ya Existe");
                }

                Obj = (from u in cn.users
                       where u.usuarioID == Usuario.usuarioID
                       select u).First();

                Obj.nombre = Usuario.nombre;
                Obj.apellido = Usuario.apellido;
                Obj.tipo = Usuario.tipo;
                Obj.usuario = Usuario.usuario;
                Obj.password = Usuario.password;
                Obj.estado = 1;
                int result = cn.SaveChanges();
                if (result > 0)
                {
                    return Obj.usuarioID;
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

        public static string delete(EUsers Usuario)
        {
            string rpta = "";
            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                users Obj = new users();
                //Obj = (from p in cn.paciente
                //       where p.id == Paciente.id
                //       select p).First();
                Obj = cn.users.Find(Usuario.usuarioID);
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


        public static List<EUsers> mostrar(string nombre ,string apellido, int pag)
        {
            try
            {
                List<EUsers> Usuarios = new List<EUsers>();
                List<users> usuarios = new List<users>();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    usuarios = (from u in cn.users
                                where u.estado == 1
                                where u.nombre.Contains(nombre)
                                where u.apellido.Contains(apellido)
                                orderby u.usuarioID descending
                                select u).ToList();

                    pag = pag * 10;
                    var tabla = usuarios.Skip(pag).Take(10);
                    if (usuarios.Count < pag)
                    {
                        tabla = usuarios.Skip(pag).Take(10);
                    }


                    foreach (var item in tabla)
                    {
                        EUsers Obj = new EUsers();
                        Obj.usuarioID = item.usuarioID;
                        Obj.nombre = item.nombre;
                        Obj.apellido = item.apellido;
                        Obj.tipo = item.tipo;
                        Obj.usuario = item.usuario;
                        Obj.password = item.password;

                        Obj.estado = item.estado;
                        Usuarios.Add(Obj);
                    }
                    return Usuarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EUsers login(EUsers Usuario)
        {
            try
            {
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    users Obj = new users();
                    EUsers login = new EUsers();
                    Obj = (from u in cn.users
                           where u.usuario == Usuario.usuario && u.password == Usuario.password
                           select u).First();
                    login.usuarioID = Obj.usuarioID;
                    login.nombre = Obj.nombre;
                    login.apellido = Obj.apellido;
                    login.tipo = Obj.tipo;
                    login.usuario = Obj.usuario;

                    return login;
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                throw new Exception("El Usuario que Ingresaste no coinciden con ninguna Cuenta "+ex.Message);
            }
        }
        public static int mostrarTotal(string nombre, string apellido)
        {
            try
            {
                List<users> usuarios = new List<users>();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    usuarios = (from u in cn.users
                                where u.estado == 1
                                where u.nombre.Contains(nombre)
                                where u.apellido.Contains(apellido)
                                orderby u.usuarioID descending
                                select u).ToList();

                    return usuarios.Count;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public EUsers mostrarUserID(int ID)
        {
            try
            {
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    users Obj = new users();
                    EUsers login = new EUsers();
                    Obj = (from u in cn.users
                           where u.usuarioID==ID
                           select u).First();
                    login.usuarioID = Obj.usuarioID;
                    login.nombre = Obj.nombre;
                    login.apellido = Obj.apellido;
                    login.tipo = Obj.tipo;
                    login.usuario = Obj.usuario;
                    login.password = Obj.password;

                    return login;
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                throw new Exception("El Usuario que Ingresaste no coinciden con ninguna Cuenta " + ex.Message);
            }
        }
        public static List<EUsers> mostrarOdontologo(string nombre, string apellido, int pag)
        {
            try
            {
                List<EUsers> Usuarios = new List<EUsers>();
                List<users> usuarios = new List<users>();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    usuarios = (from u in cn.users
                                where u.estado == 1
                                where u.tipo == "Odontologo"
                                where u.nombre.Contains(nombre) 
                                where u.apellido.Contains(apellido)
                                orderby u.usuarioID descending
                                select u).ToList();

                    pag = pag * 10;
                    var tabla = usuarios.Skip(pag).Take(10);
                    if (usuarios.Count < pag)
                    {
                        tabla = usuarios.Skip(pag).Take(10);
                    }

                    foreach (var item in tabla)
                    {
                        EUsers Obj = new EUsers();
                        Obj.usuarioID = item.usuarioID;
                        Obj.nombre = item.nombre;
                        Obj.apellido = item.apellido;
                        Obj.tipo = item.tipo;
                        Obj.usuario = item.usuario;
                        Obj.password = item.password;

                        Obj.estado = item.estado;
                        Usuarios.Add(Obj);
                    }
                    return Usuarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
