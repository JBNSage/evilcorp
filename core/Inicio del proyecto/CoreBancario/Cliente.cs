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
    class Cliente
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string TipoDocumento { get; set; }
        public string NoDocumento { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string CodigoPostal { get; set; }
        public string Contraseña { get; set; }

        public void PedirDatos(string opcion)
        {
            Console.Clear();

            Console.WriteLine($"{opcion} cliente", Color.Green);
            Console.WriteLine("-----------------------------------------------------------");

            Console.Write("Nombres: ");
            Nombres = Console.ReadLine();

            Console.Write("Apellidos: ");
            Apellidos = Console.ReadLine();

            Console.Write("Tipo de documento: ");
            TipoDocumento = Console.ReadLine();

            Console.Write("Número de documento: ");
            NoDocumento = Console.ReadLine();

            Console.Write("Teléfono: ");
            Telefono = Console.ReadLine();

            Console.Write("Celular: ");
            Celular = Console.ReadLine();

            Console.Write("Correo Electrónico: ");
            CorreoElectronico = Console.ReadLine();

            Console.Write("Dirección: ");
            Direccion = Console.ReadLine();

            Console.Write("Ciudad: ");
            Ciudad = Console.ReadLine();

            Console.Write("Provincia: ");
            Provincia = Console.ReadLine();

            Console.Write("Código postal: ");
            CodigoPostal = Console.ReadLine();

            Console.Write("Contraseña: ");
            Contraseña = Console.ReadLine();

            
        }

        public bool CrearCliente()
        {

            SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["cS"].ToString());
            sql.Open();
            SqlCommand cmd = new SqlCommand("spCrearCliente", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombres", Nombres);
            cmd.Parameters.AddWithValue("@apellidos", Apellidos);
            cmd.Parameters.AddWithValue("@tipoDocumento", TipoDocumento);
            cmd.Parameters.AddWithValue("@noDocumento", NoDocumento);
            cmd.Parameters.AddWithValue("@telefono", Telefono);
            cmd.Parameters.AddWithValue("@celular", Celular);
            cmd.Parameters.AddWithValue("@correoElectronico", CorreoElectronico);
            cmd.Parameters.AddWithValue("@direccion", Direccion);
            cmd.Parameters.AddWithValue("@ciudad", Ciudad);
            cmd.Parameters.AddWithValue("@provincia", Provincia);
            cmd.Parameters.AddWithValue("@codigoPostal", CodigoPostal);
            cmd.Parameters.AddWithValue("@contraseña", Contraseña);

            cmd.Parameters.Add("@return", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();

            if ((int)cmd.Parameters["@return"].Value == 0)
            {
                Console.WriteLine("\nEste cliente ya existe\n", Color.Red);
                return false;
            }
            else
            {
                Console.WriteLine("\nCliente registrado con éxito\n", Color.Green);
                return true;
            }

        }

        public bool LeerCliente()
        {
            Console.Clear();

            Console.Write("Ingrese el No. de Documento único: ");
            NoDocumento = Console.ReadLine();

            SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["cS"].ToString());
            sql.Open();
            SqlCommand cmd = new SqlCommand("spLeerCliente", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@noDocumento", NoDocumento);

            cmd.Parameters.Add("@return", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();

            if ((int)cmd.Parameters["@return"].Value == 0)
            {
                Console.WriteLine("\nEste cliente no existe en la base de datos\n", Color.Red);
                return false;
            }
            else
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine($"\nNombres: {dr["Nombres"]}\nApellidos: {dr["Apellidos"]}\nTipo de Documento: {dr["TipoDocumento"]}\nNo. de Documento: {dr["NoDocumento"]}\nTeléfono: {dr["Telefono"]}\nCelular: {dr["Celular"]}\nCorreo Electrónico: {dr["CorreoElectronico"]}\nDirección: {dr["Direccion"]}\nCiudad: {dr["Ciudad"]}\nProvincia: {dr["Provincia"]}\nCódigo Postal: {dr["CodigoPostal"]}\nContraseña: {dr["Contraseña"]}");
                }
                dr.Close();

                //Console.WriteLine("\nCliente registrado con éxito\n", Color.Green);
                return true;
            }

        }
    }
}
