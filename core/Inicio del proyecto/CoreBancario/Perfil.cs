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
    class Perfil
    {
        public string noDocumento { get; set; }

        public string nomUsuario { get; set; }

        public byte consulta { get; set; }

        public byte mantenimiento { get; set; }

        public byte administracion { get; set; }

        
        public bool CrearPerfil()
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = ConfigurationManager.ConnectionStrings["cS"].ToString();
            sql.Open();
            SqlCommand cmd = new SqlCommand("spCrearPerfil", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NoDocumento", noDocumento);
            cmd.Parameters.AddWithValue("@nomUsuario", nomUsuario);
            cmd.Parameters.AddWithValue("@Consulta", consulta);
            cmd.Parameters.AddWithValue("@Mantenimiento", mantenimiento);
            cmd.Parameters.AddWithValue("@Administracion", administracion);

            cmd.Parameters.Add("@return", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();

            if ((int)cmd.Parameters["@return"].Value == 0)
            {
                Console.WriteLine("\nEste perfil ya existe\n", Color.Red);
                return false;
            }
            else
            {
                Console.WriteLine("\nPerfil registrado con éxito\n", Color.Green);
                return true;
            }
        }

        public void ActualizarPerfil()
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = ConfigurationManager.ConnectionStrings["cS"].ToString();
            sql.Open();
            SqlCommand cmd = new SqlCommand("spActualizarPerfil", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NoDocumento", noDocumento);
            cmd.Parameters.AddWithValue("@nomUsuario", nomUsuario);
            cmd.Parameters.AddWithValue("@Consulta", consulta);
            cmd.Parameters.AddWithValue("@Mantenimiento", mantenimiento);
            cmd.Parameters.AddWithValue("@Administracion", administracion);

            
            cmd.ExecuteNonQuery();

            
        }
    }
}
