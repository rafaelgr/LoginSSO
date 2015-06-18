using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Security.Principal;
using System.Configuration;
using LonginSSOLib;

namespace LoginSSOWeb
{
    public partial class LoginGdesAc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // obtener las rutas para fallo o acierto en el login
            string gdesAcUrlSuccess = ConfigurationManager.AppSettings["GdesAcUrlSuccess"];
            string gdesAcUrlFail = ConfigurationManager.AppSettings["GdesAcUrlFail"];
            // comprobar la identidad del usuario logado
            WindowsIdentity wi = (WindowsIdentity)Page.User.Identity;
            if (wi.User == null)
            {
                Response.Redirect(gdesAcUrlFail);
            }
            else
            {

                // leer la cadena de conexión de los parámetros
                string connectionString= ConfigurationManager.ConnectionStrings["GdesAc"].ConnectionString;

                AcTrabajador t = null;
                string login = wi.User.Value;
                string password = wi.User.Value;
                using (MySqlConnection conn = CntGdesAc.GetConnection(connectionString))
                {
                    conn.Open();
                    t = CntGdesAc.GetAcTrabajadorLogin(login, conn);
                    if (t != null)
                    {
                        // Grabar la cookie para que funcione
                        string js = String.Format("trabajadorCookie('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');", t.TrabajadorId, t.Nombre, t.Login, t.Idioma, t.Evaluador, gdesAcUrlSuccess);
                        ScriptManager.RegisterStartupScript(this, GetType(), "trabajadorCookie", js, true);
                        //Response.Redirect(gdesAcUrlSuccess);
                    }
                    else
                    {
                        Response.Redirect(gdesAcUrlFail);
                    }
                    conn.Close();
                }
            }
        }
    }
}