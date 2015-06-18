using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginSSOWeb
{
    public partial class LoginSSOTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WindowsIdentity wi = (WindowsIdentity)Page.User.Identity;
            if (wi.User == null)
            {
                lblUsuario.Text = wi.Name;
                lblLogin.Text = "NO ha un usuario logado";
            }
            else
            {
                lblUsuario.Text = "Usuario: " + wi.Name;
                lblLogin.Text = "Login / Password: " + wi.User.Value;

            }
        }
    }
}