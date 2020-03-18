using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (Session["tipo"] != null || Session["carrera"] != null || Session["nombre"] != null)
            {
                Session["tipo"] = null;
                Session["carrera"] = null;
                Session["nombre"] = null;
                Response.Redirect("Default.aspx");
            }
        }
    }
}