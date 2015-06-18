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
    public partial class LoginGdesOd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // obtener las rutas para fallo o acierto en el login
            string gdesOdUrlSuccess = ConfigurationManager.AppSettings["GdesOdUrlSuccess"];
            string gdesOdUrlFail = ConfigurationManager.AppSettings["GdesOdUrlFail"];
            // comprobar la identidad del usuario logado
            WindowsIdentity wi = (WindowsIdentity)Page.User.Identity;
            if (wi.User == null)
            {
                Response.Redirect(gdesOdUrlFail);
            }
            else
            {

                // leer la cadena de conexión de los parámetros
                string connectionString= ConfigurationManager.ConnectionStrings["GdesOd"].ConnectionString;

                OdTrabajador t = null;
                string login = wi.User.Value;
                string password = wi.User.Value;
                using (MySqlConnection conn = CntGdesAc.GetConnection(connectionString))
                {
                    conn.Open();
                    t = CntGdesAc.GetOdTrabajadorLogin(login, conn);
                    if (t != null)
                    {
                        // Grabar la cookie para que funcione
                        string js = String.Format("trabajadorCookie('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');", t.TrabajadorId, t.Nombre, t.Login, t.Idioma, t.Evaluador, gdesOdUrlSuccess);
                        ScriptManager.RegisterStartupScript(this, GetType(), "trabajadorCookie", js, true);
                        //Response.Redirect(gdesOdUrlSuccess);
                    }
                    else
                    {
                        Response.Redirect(gdesOdUrlFail);
                    }
                    conn.Close();
                }
            }
        }
    }
}