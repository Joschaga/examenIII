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
    public partial class placas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGridPlacas();
        }
        protected void LlenarGridPlacas()
        {
            string constr = ConfigurationManager.ConnectionStrings["VehiculosExamenFinalConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("exec ConsultarPlaca"))
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
                SqlCommand comando = new SqlCommand("exec IngresarPlaca " + "'" + Tnumplaca.Text + "', " + int.Parse(Tidusuario.Text) + ", "
                                                    + int.Parse(Tmonto.Text), conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            { }
            LlenarGridPlacas();
        }

        protected void Bmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                String s = System.Configuration.ConfigurationManager.ConnectionStrings["VehiculosExamenFinalConnectionString"].ConnectionString;
                SqlConnection conexion = new SqlConnection(s);
                conexion.Open();
                SqlCommand comando = new SqlCommand("exec ActualizarPlaca " + "'" + Tnumplaca.Text + "', " + int.Parse(Tidusuario.Text) + ", "
                                                    + int.Parse(Tmonto.Text), conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            { }
            LlenarGridPlacas();
        }

        protected void Bborrar_Click(object sender, EventArgs e)
        {
            try
            {
                String s = System.Configuration.ConfigurationManager.ConnectionStrings["VehiculosExamenFinalConnectionString"].ConnectionString;
                SqlConnection conexion = new SqlConnection(s);
                conexion.Open();
                SqlCommand comando = new SqlCommand("exec BorrarPlaca " + "'" + Tnumplaca.Text + "'", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            { }
            LlenarGridPlacas();
        }
    }
}