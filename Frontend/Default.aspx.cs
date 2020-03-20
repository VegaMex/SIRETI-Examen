using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipo"] != null || Session["carrera"] != null || Session["nombre"] != null || Session["tipoString"] != null)
            {
                Session["tipo"] = null;
                Session["carrera"] = null;
                Session["nombre"] = null;
                Session["tipoString"] = null;
            }
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmLogin.aspx");
        }
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmRegistroAlumno.aspx");
        }
    }
}