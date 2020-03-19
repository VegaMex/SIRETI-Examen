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
                    var tipo = Int32.Parse(Session["tipo"].ToString());
                    if (tipo == 0)
                    {
                        ddlTipo.Visible = true;
                        ddlCarrera.Visible = true;
                        ddlCarrera.DataSource = new DAOCarrera(new NewConnection()).GetCarreras();
                        ddlCarrera.DataValueField = "IdCarrera";
                        ddlCarrera.DataTextField = "NombreCarrera";
                        ddlCarrera.DataBind();
                    } 
                    else if (tipo == 2 || tipo == 3)
                    {
                        lblCarrera.Visible = false;
                        lblTipo.Visible = false;
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
                var tipo = Int32.Parse(Session["tipo"].ToString());
                if (tipo == 0)
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
                else if (tipo == 2 || tipo == 3)
                {
                    var carrera = Int32.Parse(Session["carrera"].ToString());
                    var usuario = new Usuario
                    {
                        NombreUsuario = txtNombre.Text,
                        PaternoUsuario = txtPaterno.Text,
                        MaternoUsuario = txtMaterno.Text,
                        CorreoUsuario = txtCorreo.Text,
                        ContraUsuario = txtContra.Text,
                        CarreraUsuario = carrera,
                        TipoUsuario = 4
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
                    Response.Redirect("Default.aspx");
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