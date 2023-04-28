using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIIProgra
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BIngresar_Click(object sender, EventArgs e)
        {
            if (Login.ValidarUsuario(tusuario.Text, tpassword.Text) > 0)
            {
                Response.Redirect("Inicio.aspx");
            }
        }
    }
}