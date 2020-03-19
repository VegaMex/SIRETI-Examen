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
            serverError.Visible = false;
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
            switch (e.CommandName)
            {
                case "btnEliminar":
                    IdUsuario.Value = grvListaUsuarios.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text;
                    Response.Write("<script>");
                    Response.Write("window.addEventListener('load', function () {$('#mdlConfirmarEliminacion').modal('show');});");
                    Response.Write("</script>");
                    break;
            }
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            if (new DAOUsuario(new NewConnection()).Delete(IdUsuario.Value))
            {
                int tipo = Int32.Parse(Session["tipo"].ToString());
                if (tipo != 1 || tipo != 4)
                {
                    serverError.Visible = false;
                    string carrera = Session["carrera"].ToString();
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
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                serverError.Visible = true;
            }
        }
    }
}