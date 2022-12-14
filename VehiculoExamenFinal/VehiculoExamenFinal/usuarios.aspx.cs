using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VehiculoExamenFinal
{
    public partial class usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGridUsuarios();
        }
        protected void LlenarGridUsuarios()
        {
            string constr = ConfigurationManager.ConnectionStrings["VehiculosExamenFinalConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("exec ConsultarUsuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }

        protected void Bingresar_Click(object sender, EventArgs e)
        {
            try
            {
                String s = System.Configuration.ConfigurationManager.ConnectionStrings["VehiculosExamenFinalConnectionString"].ConnectionString;
                SqlConnection conexion = new SqlConnection(s);
                conexion.Open();
                SqlCommand comando = new SqlCommand("exec IngresarUsuarios " + "'" + Tusuario.Text + "', " + "'" + Tclave.Text + "', " 
                                                    + "'" + Tnombre.Text + "', " + "'" + Tapellido.Text + "'", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            { }
            LlenarGridUsuarios();
        }
        protected void Bmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                String s = System.Configuration.ConfigurationManager.ConnectionStrings["VehiculosExamenFinalConnectionString"].ConnectionString;
                SqlConnection conexion = new SqlConnection(s);
                conexion.Open();
                SqlCommand comando = new SqlCommand("exec ActualizarUsuarios " + "'" + Tusuario.Text + "', " + "'" + Tclave.Text + "', "
                                                    + "'" + Tnombre.Text + "', " + "'" + Tapellido.Text + "'", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            { }
            LlenarGridUsuarios();
        }
        protected void Bborrar_Click(object sender, EventArgs e)
        {
            try
            {
                String s = System.Configuration.ConfigurationManager.ConnectionStrings["VehiculosExamenFinalConnectionString"].ConnectionString;
                SqlConnection conexion = new SqlConnection(s);
                conexion.Open();
                SqlCommand comando = new SqlCommand("exec BorrarUsuarios " + "'" + Tusuario.Text + "'", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            { }
            LlenarGridUsuarios();
        }
    }
}