using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;


namespace CoreBancario
{
    public class Usuario
    {

        public string nomUsuario { get; set; }

        public string contraseña { get; set; }

        public string correoElectronico { get; set; }

        public string noDocumento { get; set; }

        public string sucursal { get; set; }

        Perfil perfil = new Perfil();

        public void PedirDatos(string accion)
        {
            string confirmar = null;
            bool error = false;
            do
            {
                do
                {
                    try
                    {
                        Console.Clear();

                        Console.WriteLine($"{accion} usuario", Color.Green);
                        Console.WriteLine("-----------------------------------------------------------");

                        Console.Write("Número de documento: ");
                        noDocumento = Console.ReadLine();
                        perfil.noDocumento = noDocumento;

                        Console.Write("Nombre de usuario: ");
                        nomUsuario = Console.ReadLine();
                        perfil.nomUsuario = nomUsuario;

                        Console.Write("Contraseña: ");
                        contraseña = Console.ReadLine();

                        Console.Write("Ingrese nuevamente la contraseña: ");
                        confirmar = Console.ReadLine();

                        Console.Write("Correo Electrónico: ");
                        correoElectronico = Console.ReadLine();

                        Console.Write("Sucursal: ");
                        sucursal = Console.ReadLine();

                        Console.Write("Derecho de consulta: ");
                        perfil.consulta = Convert.ToByte(Console.ReadLine());

                        Console.Write("Derecho de mantenimieto: ");
                        perfil.mantenimiento = Convert.ToByte(Console.ReadLine());

                        Console.Write("Derecho de administración: ");
                        perfil.administracion = Convert.ToByte(Console.ReadLine());

                        if (contraseña != confirmar)
                        {
                            Console.WriteLine("Las contraseñas no coinciden, por favor intente de nuevo", Color.Red);
                            Console.ReadKey();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Inserte información válida", Color.Red);
                        Console.ReadKey();
                        error = true;
                    }
                } while (contraseña != confirmar);
                
            } while (error);
           
            
        }

        public bool LogIn()
        {
            Console.Clear();
            Console.Write("Inserte su cedula: ");
            noDocumento = Console.ReadLine();

            SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["cS"].ToString());
            sql.Open();
            SqlCommand cmd = new SqlCommand("spLeerUsuario", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cedula", noDocumento);
            cmd.Parameters.Add("@return", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();

            if ((int)cmd.Parameters["@return"].Value == 1)
            {
                // Console.WriteLine("\nEste usuario ya existe\n", Color.Red);
                Console.Write("Inserte su contraseña: ");
                contraseña = Console.ReadLine();

                SqlDataReader dr = cmd.ExecuteReader();
                string dbContraseña = null;
                while (dr.Read())
                {
                    dbContraseña = dr["Contraseña"].ToString();
                };
                if (contraseña == dbContraseña)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("\nUSUARIO O CONTRASEÑA ERRONEA!\n", Color.Red);
                    Console.WriteLine("presione cualquier tecla para continuar... ");
                    return false;
                }
            }
            else
            {
                Console.Write("Inserte su contraseña: ");
                contraseña = Console.ReadLine();
                Console.WriteLine("\nUSUARIO O CONTRASEÑA ERRONEA!\n", Color.Red);
                Console.WriteLine("presione cualquier tecla para continuar... ");
                contraseña = null;
                return false;
            }

        }

        public bool CrearUsuario()
        {
            
               
                SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["cS"].ToString());
                sql.Open();
                SqlCommand cmd = new SqlCommand("spCrearUsuario", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nomUsuario", nomUsuario);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                cmd.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);
                cmd.Parameters.AddWithValue("@NoDocumento", noDocumento);
                cmd.Parameters.AddWithValue("@Sucursal", sucursal);

                cmd.Parameters.Add("@return", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                if ((int)cmd.Parameters["@return"].Value == 0)
                {
                    Console.WriteLine("\nEste usuario ya existe\n", Color.Red);
                    return false;
                }
                else
                {
                    Console.WriteLine("\nUsuario registrado con éxito\n", Color.Green);
                    perfil.CrearPerfil();
                    return true;
                }

           
            
        }

        public void BuscarUsuario()
        {
            Console.Clear();
            Console.WriteLine($"Consultar usuario", Color.Green);
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Inserte la cédula a buscar");
            noDocumento = Console.ReadLine();

            SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["cS"].ToString());
            sql.Open();
            SqlCommand cmd = new SqlCommand("spLeerUsuario", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cedula", noDocumento);
            cmd.Parameters.Add("@return", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();

            if ((int) cmd.Parameters["@return"].Value == 1)
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "spFiltrarUsuario";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@noDocumento", noDocumento);
                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("\nUsuario encontrado!", Color.Green);

                while (dr.Read())
                {
                    Console.WriteLine($"\nNombre de usuario: {dr["NombreUsuario"]}");
                    Console.WriteLine($"Correro electrónico: {dr["CorreoElectronico"]}");
                    Console.WriteLine($"Sucursal: {dr["Sucursal"]}");
                    Console.WriteLine($"Derecho de consulta: {dr["Consulta"]}");
                    Console.WriteLine($"Derecho de administración: {dr["Administracion"]}");
                    Console.WriteLine($"Derecho de mantenimiento: {dr["Mantenimiento"]}\n");
                }
            }
            else
            {
                Console.WriteLine("Este usuario no existe", Color.Red);
            }
           
        }

        public bool ActualizarUsuario()
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = ConfigurationManager.ConnectionStrings["cS"].ToString();
            sql.Open();
            SqlCommand cmd = new SqlCommand("spActualizarUsuario", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nomUsuario", nomUsuario);
            cmd.Parameters.AddWithValue("@Contraseña", contraseña);
            cmd.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);
            cmd.Parameters.AddWithValue("@NoDocumento", noDocumento);
            cmd.Parameters.AddWithValue("@Sucursal", sucursal);

            cmd.Parameters.Add("@return", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();

            if ((int)cmd.Parameters["@return"].Value == 0)
            {
                Console.WriteLine("\nEste usuario no existe\n", Color.Red);
                return false;
            }
            else
            {
                perfil.ActualizarPerfil();
                Console.WriteLine("\nUsuario actualizado con éxito\n", Color.Green);
                return true;
            }
        }

        public void EliminarUsuario()
        {

        }

        
    }
}
