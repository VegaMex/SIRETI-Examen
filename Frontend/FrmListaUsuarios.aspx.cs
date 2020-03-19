using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Connections;
using Backend.DAOS;

namespace Frontend
{
    public partial class FrmListaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["tipo"] == null))
            {
                int tipo = Int32.Parse(Session["tipo"].ToString());
                if (tipo != 1 || tipo != 4)
                {
                    string carrera = Session["carrera"].ToString();
                    if (!IsPostBack)
                    {
                        grvListaUsuarios.AutoGenerateColumns = false;
                        switch (tipo)
                        {
                            case 0:
                                grvListaUsuarios.DataSource = new DAOUsuario(new NewConnection()).GetAllUsuarios();
                                grvListaUsuarios.DataBind();
                                break;
                            case 2:
                            case 3:
                                grvListaUsuarios.DataSource = new DAOUsuario(new NewConnection()).GetAllDocentes(carrera);
                                grvListaUsuarios.DataBind();
                                break;
                        }
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmRegistroUsuario.aspx");
        }

        protected void grvListaUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}