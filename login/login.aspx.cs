using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace AlquilaConConfianza
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string password = txtPassword.Text;

            if (correo.Length == 0 || password.Length == 0)
            {
                MostrarMensaje("Ingrese su correo y su contraseña.", false);
                return;
            }

            // La cadena de conexión se configura en Web.config
            string conexionStr = ConfigurationManager.ConnectionStrings["AlquilaConConfianza"].ConnectionString;
            string destino = null;

            using (SqlConnection conn = new SqlConnection(conexionStr))
            {
                string query = "SELECT Id, Rol FROM Usuarios WHERE Correo = @Correo AND PasswordHash = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@Password", HashPassword(password));

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string rol = reader["Rol"].ToString();
                                Session["UsuarioId"] = reader["Id"];
                                Session["UsuarioCorreo"] = correo;
                                Session["Rol"] = rol;

                                // Redirección según rol
                                if (rol == "Propietario")
                                {
                                    destino = "Propietario.aspx";
                                }
                                else if (rol == "Arrendatario")
                                {
                                    destino = "Arrendatario.aspx";
                                }
                                else if (rol == "Administrador")
                                {
                                    destino = "Admin.aspx";
                                }
                                else
                                {
                                    MostrarMensaje("El usuario no tiene un rol válido.", false);
                                }
                            }
                            else
                            {
                                MostrarMensaje("Correo o contraseña incorrectos.", false);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MostrarMensaje("Error de conexión: " + ex.Message, false);
                    }
                }
            }

            if (destino != null)
            {
                // endResponse: false para no lanzar ThreadAbortException dentro del try/catch
                Response.Redirect(destino, false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        private void MostrarMensaje(string mensaje, bool exito)
        {
            lblMensaje.ForeColor = exito ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblMensaje.Text = mensaje;
        }

        // Los usuarios de query.sql guardan la contraseña como SHA-256 en hexadecimal.
        private static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder(bytes.Length * 2);
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
