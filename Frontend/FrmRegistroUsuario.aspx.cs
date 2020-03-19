using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Connections;
using Backend.DAOS;
using Backend.Security;
using Backend.Models;

namespace Frontend
{
    public partial class FrmRegistroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            serverError.Visible = false;
            ddlCarrera.Visible = false;
            ddlTipo.Visible = false;
            if (Session["tipo"] != null)
            {
                if (!IsPostBack)
                {
                    if (Int32.Parse(Session["tipo"].ToString()) == 0)
                    {
                        ddlTipo.Visible = true;
                        ddlCarrera.Visible = true;
                        ddlCarrera.DataSource = new DAOCarrera(new NewConnection()).GetCarreras();
                        ddlCarrera.DataValueField = "IdCarrera";
                        ddlCarrera.DataTextField = "NombreCarrera";
                        ddlCarrera.DataBind();
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmListaUsuarios.aspx");
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            var keys = new string[]
            {
                txtNombre.Text,
                txtPaterno.Text,
                txtMaterno.Text,
                txtCorreo.Text,
                txtContra.Text,
                txtContraConfirm.Text
            };
            if (ValidatorService.AllRegister(keys, 2))
            {
                var usuario = new Usuario
                {
                    NombreUsuario = txtNombre.Text,
                    PaternoUsuario = txtPaterno.Text,
                    MaternoUsuario = txtMaterno.Text,
                    CorreoUsuario = txtCorreo.Text,
                    ContraUsuario = txtContra.Text,
                    CarreraUsuario = Int32.Parse(ddlCarrera.SelectedItem.Value),
                    TipoUsuario = Int32.Parse(ddlTipo.SelectedItem.Value)
                };
                if (new DAOUsuario(new NewConnection()).Insert(usuario))
                {
                    Response.Redirect("FrmListaUsuarios.aspx");
                }
                else
                {
                    serverError.Visible = true;
                }
            }
            else
            {
                serverError.InnerText = "Los datos se modificaron y ya no son válidos";
                serverError.Visible = true;
            }
        }
    }
}