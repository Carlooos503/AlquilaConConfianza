using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AlquilaConConfianza
{
    public partial class Propietario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Protección de ruta por rol
            if (Session["Rol"] == null || Session["Rol"].ToString() != "Propietario")
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarPropiedades();
            }
        }

        private void CargarPropiedades()
        {
            if (Session["UsuarioId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            string conexionStr = ConfigurationManager.ConnectionStrings["AlquilaConConfianza"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(conexionStr))
            {
                // Carga los inmuebles del propietario que tiene la sesión iniciada
                string query = "SELECT Titulo, Zona, Precio, Habitaciones, EstadoVerificacion FROM Casas WHERE PropietarioId = @PropietarioId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PropietarioId", Convert.ToInt32(Session["UsuarioId"]));

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        gvCasas.DataSource = dt;
                        gvCasas.DataBind();
                    }
                }
            }
        }
    }
}
