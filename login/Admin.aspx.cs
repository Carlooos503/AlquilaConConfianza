using System;

namespace AlquilaConConfianza
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null || Session["Rol"].ToString() != "Administrador")
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}
