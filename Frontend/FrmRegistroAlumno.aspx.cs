using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.DAOS;
using Backend.Connections;

namespace Frontend
{
    public partial class FrmRegistroAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCarrera.DataSource = new DAOCarrera(new NewConnection()).GetCarreras();
                ddlCarrera.DataValueField = "IdCarrera";
                ddlCarrera.DataTextField = "NombreCarrera";
                ddlCarrera.DataBind();
            }
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {

        }
    }
}