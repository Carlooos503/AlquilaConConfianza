using System;

namespace AlquilaConConfianza
{
    public partial class Arrendatario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null || Session["Rol"].ToString() != "Arrendatario")
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}
