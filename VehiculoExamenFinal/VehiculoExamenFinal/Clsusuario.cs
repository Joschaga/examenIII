using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace VehiculoExamenFinal
{
    public class Clsusuario
    {
        public static string Nombre { get; set; }
        public static string Apellido { get; set; }
        public static string Usuario { get; set; }
        public static string Clave { get; set; }

        public static int ValidarLogin(string Email, string Clave)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ConsultarLogin", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Usuario", Email));
                    cmd.Parameters.Add(new SqlParameter("@Clave", Clave));

                    /*using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            Tipo = rdr["Tipo"].ToString();
                            retorno = 1;
                        }
                    }*/
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return retorno;
        }
    }
}