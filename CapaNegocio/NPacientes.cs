using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntity;

namespace CapaNegocio
{
    public class NPacientes
    {
        public static long save(EPaciente Paciente)
        {
            try
            {


                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                List<paciente> pacientes = new List<paciente>();
                paciente Obj = new paciente();

                pacientes = (from p in cn.paciente
                             where p.estado==1
                             where p.nombre == Paciente.nombre && p.apellido == Paciente.apellido
                             select p).ToList();

                if (pacientes.Count > 0)
                {
                    throw new Exception("El Paciente Ya Existe");
                }

                Obj.nombre = Paciente.nombre;
                Obj.apellido = Paciente.apellido;
                Obj.telefono = Paciente.telefono;
                if (Obj.nombre == string.Empty && Obj.apellido == string.Empty)
                {
                    throw new Exception("Ingrese Nombre y Apellido");
                }
                Obj.ci = Paciente.ci;
                Obj.fechaNacimiento = Paciente.fechaNacimiento;
                Obj.direccion = Paciente.direccion;
                Obj.sexo = Paciente.sexo;
                Obj.estado = 1;
                cn.paciente.Add(Obj);
                int result = cn.SaveChanges();
                if (result > 0)
                {
                    return Obj.pacienteID;
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

        public static long update(EPaciente Paciente)
        {

            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                List<paciente> pacientes = new List<paciente>();
                paciente Obj = new paciente();

                pacientes = (from p in cn.paciente
                             where p.estado == 1
                             where p.nombre == Paciente.nombre && p.apellido == Paciente.apellido
                             select p).ToList();

                if (pacientes.Count > 1)
                {
                    throw new Exception("El Paciente Ya Existe");
                }

                Obj = (from p in cn.paciente
                       where p.pacienteID == Paciente.pacienteID
                       select p).First();

                Obj.nombre = Paciente.nombre;
                Obj.apellido = Paciente.apellido;
                Obj.telefono = Paciente.telefono;
                Obj.ci = Paciente.ci;
                Obj.fechaNacimiento = Paciente.fechaNacimiento;
                Obj.direccion = Paciente.direccion;
                Obj.sexo = Paciente.sexo;
                Obj.estado = 1;
                int result = cn.SaveChanges();
                if (result > 0)
                {
                    return Obj.pacienteID;
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
        public static string delete(EPaciente Paciente)
        {
            string rpta = "";
            try
            {
                CapaDato.dbodontogramaEntity cn = new dbodontogramaEntity();
                paciente Obj = new paciente();
                //Obj = (from p in cn.paciente
                //       where p.id == Paciente.id
                //       select p).First();
                Obj = cn.paciente.Find(Paciente.pacienteID);
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

        public static List<EPaciente> mostrar(string nombre, string apellido, int pag)
        {
            try
            {
                List<EPaciente> Pacientes = new List<EPaciente>();
                List<paciente> pacientes = new List<paciente>();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    pacientes = (from p in cn.paciente
                                 where p.estado == 1
                                 where p.nombre.Contains(nombre)
                                 where p.apellido.Contains(apellido)
                                 orderby p.pacienteID descending
                                 select p).ToList();

                    pag = pag * 10;
                    var tabla = pacientes.Skip(pag).Take(10);
                    if (pacientes.Count < pag)
                    {
                        tabla = pacientes.Skip(pag).Take(10);
                    }

                    foreach (var item in tabla)
                    {
                        EPaciente Obj = new EPaciente();
                        Obj.pacienteID = item.pacienteID;
                        Obj.nombre = item.nombre;
                        Obj.apellido = item.apellido;
                        Obj.telefono = item.telefono;
                        Obj.ci = item.ci;
                        Obj.fechaNacimiento = item.fechaNacimiento;
                        Obj.direccion = item.direccion;
                        Obj.sexo = item.sexo;
                        Obj.estado = item.estado;
                        Pacientes.Add(Obj);
                    }
                    return Pacientes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public EPaciente mostraDatos(int id)
        {
            try
            {
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    paciente item = new paciente();
                    item = cn.paciente.Find(id);
                    EPaciente Obj = new EPaciente();
                    Obj.pacienteID = item.pacienteID;
                    Obj.nombre = item.nombre;
                    Obj.apellido = item.apellido;
                    Obj.telefono = item.telefono;
                    Obj.ci = item.ci;
                    Obj.fechaNacimiento = item.fechaNacimiento;
                    Obj.direccion = item.direccion;
                    Obj.sexo = item.sexo;
                    Obj.estado = item.estado;
                    

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public EPaciente mostraPacienteOdontograma(int ID)
        {
            try
            {
                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    paciente item = new paciente();
                    item = (from p in cn.paciente join c in cn.atencion on p.pacienteID equals c.pacienteID
                            join ct in cn.atencion_detalle on c.atencionID equals ct.atencionID
                            join od in cn.odontograma_detalle on ct.odontogramaID equals od.odontogramaID
                            join o in cn.odontograma on od.odontogramaID equals o.odontogramaID
                            where p.estado == 1 && o.odontogramaID == ID
                            select p).First();
                    EPaciente Obj = new EPaciente();
                    Obj.pacienteID = item.pacienteID;
                    Obj.nombre = item.nombre;
                    Obj.apellido = item.apellido;
                    Obj.telefono = item.telefono;
                    Obj.ci = item.ci;
                    Obj.fechaNacimiento = item.fechaNacimiento;
                    Obj.direccion = item.direccion;
                    Obj.sexo = item.sexo;
                    Obj.estado = item.estado;


                    return Obj;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<EPaciente> buscar(string nombre, string apellido)
        {
            try
            {
                List<EPaciente> Pacientes = new List<EPaciente>();
                List<paciente> pacientes = new List<paciente>();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    pacientes = (from p in cn.paciente
                                 where p.estado == 1
                                 where p.nombre.Contains(nombre) || p.apellido.Contains(apellido)
                                 //where p.apellido.Contains(apellido) || p.nombre.Contains(nombre)
                                 select p).ToList();

                    foreach (var item in pacientes)
                    {
                        EPaciente Obj = new EPaciente();
                        Obj.pacienteID = item.pacienteID;
                        Obj.nombre = item.nombre;
                        Obj.apellido = item.apellido;
                        Obj.telefono = item.telefono;
                        Obj.ci = item.ci;
                        Obj.fechaNacimiento = item.fechaNacimiento;
                        Obj.direccion = item.direccion;
                        Obj.sexo = item.sexo;
                        Obj.estado = item.estado;
                        Pacientes.Add(Obj);
                    }
                    return Pacientes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<EPaciente> mostrarTodo()
        {
            try
            {
                List<EPaciente> Pacientes = new List<EPaciente>();
                List<paciente> pacientes = new List<paciente>();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    pacientes = (from p in cn.paciente
                                 where p.estado == 1
                                 select p).ToList();



                    foreach (var item in pacientes)
                    {
                        EPaciente Obj = new EPaciente();
                        Obj.pacienteID = item.pacienteID;
                        Obj.nombre = item.nombre;
                        Obj.apellido = item.apellido;
                        Obj.telefono = item.telefono;
                        Obj.ci = item.ci;
                        Obj.fechaNacimiento = item.fechaNacimiento;
                        Obj.direccion = item.direccion;
                        Obj.sexo = item.sexo;
                        Obj.estado = item.estado;
                        Pacientes.Add(Obj);
                    }
                    return Pacientes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int mostrarTotal(string nombre , string apellido)
        {
            try
            {
                List<paciente> pacientes = new List<paciente>();

                using (dbodontogramaEntity cn = new dbodontogramaEntity())
                {
                    pacientes = (from p in cn.paciente
                                 where p.estado == 1
                                 where p.nombre.Contains(nombre)
                                 where p.apellido.Contains(apellido)
                                 select p).ToList();

                    return pacientes.Count;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
