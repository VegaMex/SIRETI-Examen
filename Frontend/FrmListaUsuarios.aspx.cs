using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Connections;
using Backend.DAOS;
using Backend.Security;

namespace Frontend
{
    public partial class FrmListaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            serverError.Visible = false;
            if (Session["tipo"] != null)
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
                    NombreUsuario.Value = grvListaUsuarios.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text;
                    Response.Write("<script>");
                    Response.Write("window.addEventListener('load', function () {$('#mdlConfirmarEliminacion').modal('show');});");
                    Response.Write("</script>");
                    break;
                case "btnCambiarContra":
                    IdUsuario.Value = grvListaUsuarios.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text;
                    NombreUsuario.Value = grvListaUsuarios.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text;
                    Response.Write("<script>");
                    Response.Write("window.addEventListener('load', function () {$('#mdlCambiarContra').modal('show');});");
                    Response.Write("</script>");
                    break;
                case "btnEditar":
                    var keys = new Dictionary<string, string>
                    {
                        { "id_usuario", grvListaUsuarios.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text }
                    };
                    SendWTF("FrmEditarUsuario.aspx", keys);
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

        protected void btnNuevaContra_Click(object sender, EventArgs e)
        {
            var keys = new string[]
            {
                txtNuevaContra.Text,
                txtNuevaContraConfirm.Text
            };

            if (ValidatorService.AllRegister(keys, 3))
            {
                if (new DAOUsuario(new NewConnection()).NewPassword(txtNuevaContra.Text, IdUsuario.Value))
                {
                    Response.Write("<script>");
                    Response.Write("window.addEventListener('load', function () {$('#mdlCambio').modal('show');});");
                    Response.Write("</script>");
                }
                else
                {
                    serverError.Visible = true;
                }
            }
        }

        private void SendWTF(string url, Dictionary<string, string> keys)
        {
            Response.Clear();
            Response.Write("<html>");
            Response.Write("<head></head>");
            Response.Write("<body onload=\"document.frm.submit()\">");
            Response.Write(string.Format("<form name=\"frm\" method=\"post\" action=\"{0}\" >", url));
            foreach (KeyValuePair<string, string> item in keys)
            {
                Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", item.Key, item.Value));
            }
            Response.Write("</form>");
            Response.Write("</body>");
            Response.Write("</html>");
            Response.End();
        }
    }
}