using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VehiculoExamenFinal
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Bingresar_Click(object sender, EventArgs e)
        {
            Clsusuario.Usuario = Tusuario.Text;
            Clsusuario.Clave = Tclave.Text;

            String s = System.Configuration.ConfigurationManager.ConnectionStrings["VehiculosExamenFinalConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            SqlCommand comando = new SqlCommand("exec ConsultarLogin " + "'" + Tusuario.Text + "', " + "'" + Tclave.Text + "'", conn);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                Response.Redirect("inicio.aspx");
            }
            else
            {
                Lmensaje.Text = " usuario o contraseña incorrecto";
            }
            conn.Close();
        }
    }
}