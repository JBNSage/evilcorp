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

        public void PedirDatos(string accion)
        {
            Console.Clear();

            Console.WriteLine($"{accion} usuario", Color.Green);
            Console.WriteLine("-----------------------------------------------------------");

            Console.Write("Nombre de usuario: ");
            nomUsuario = Console.ReadLine();

            Console.Write("Contraseña: ");
            contraseña = Console.ReadLine();

            Console.Write("Correo Electrónico: ");
            correoElectronico = Console.ReadLine();

            Console.Write("Número de documento: ");
            noDocumento = Console.ReadLine();

            Console.Write("Sucursal: ");
            sucursal = Console.ReadLine();
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
                    return true;
                }

                
            
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
                //contraseña = Console.ReadLine();

                // Aqui se pide la contraseña pero no en texto plano
                StringBuilder vcompleto = new StringBuilder();
                ConsoleKeyInfo vnombre;
                do
                {
                    vnombre = Console.ReadKey(true);

                    // Para borrar
                    if (vnombre.KeyChar == 8 && vcompleto.Length > 0)
                    {
                        vcompleto.Length--;
                        Console.Write("\b \b");
                    }

                    // Para hacer type
                    else if (vnombre.KeyChar != 13 && vnombre.KeyChar != 8)
                    {
                        try
                        {
                            vcompleto.Append(vnombre.KeyChar);
                            Console.Write("*");
                        }
                        catch { }
                    }
                } while (vnombre.KeyChar != 13);
                
                contraseña = Convert.ToString(vcompleto);


                SqlDataReader dr = cmd.ExecuteReader();
                string dbContraseña=null;
                while (dr.Read())
                {
                    dbContraseña = dr["Contraseña"].ToString();
                };
                if (contraseña== dbContraseña)
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
                contraseña =null;
                return false;
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
                Console.WriteLine("\nUsuario actualizado con éxito\n", Color.Green);
                return true;
            }
        }

        public void EliminarUsuario()
        {

        }

        
    }
}
