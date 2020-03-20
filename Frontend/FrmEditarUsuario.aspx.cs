using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Connections;
using Backend.DAOS;
using Backend.Models;
using Backend.Security;

namespace Frontend
{
    public partial class FrmEditarUsuario : System.Web.UI.Page
    {
        //string id_usuario = "0";
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
                        if (Request["id_usuario"] != null)
                        {
                            IdUsuario.Value = Request["id_usuario"].ToString();
                            var usuario = new DAOUsuario(new NewConnection()).GetOne(IdUsuario.Value.ToString());
                            if (usuario != null)
                            {
                                txtNombre.Text = usuario.NombreUsuario;
                                txtPaterno.Text = usuario.PaternoUsuario;
                                txtMaterno.Text = usuario.MaternoUsuario;
                                txtCorreo.Text = usuario.CorreoUsuario;
                                ddlCarrera.SelectedValue = usuario.CarreraUsuario.ToString();
                                ddlTipo.SelectedValue = usuario.TipoUsuario.ToString();
                            }
                            else
                            {
                                serverError.InnerText = "No se pudieron recuperar los datos";
                            }
                        }
                        else
                        {
                            Response.Redirect("FrmListaUsuarios.aspx");
                        }
                    }
                    else if (tipo == 2 || tipo == 3)
                    {
                        lblCarrera.Visible = false;
                        lblTipo.Visible = false;
                        if (Request["id_usuario"] != null)
                        {
                            IdUsuario.Value = Request["id_usuario"].ToString();
                            var usuario = new DAOUsuario(new NewConnection()).GetOne(IdUsuario.Value.ToString());
                            if (usuario != null)
                            {
                                txtNombre.Text = usuario.NombreUsuario;
                                txtPaterno.Text = usuario.PaternoUsuario;
                                txtMaterno.Text = usuario.MaternoUsuario;
                                txtCorreo.Text = usuario.CorreoUsuario;
                            }
                            else
                            {
                                serverError.InnerText = "No se pudieron recuperar los datos";
                                serverError.Visible = true;
                            }
                        }
                        else
                        {
                            Response.Redirect("FrmListaUsuarios.aspx");
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var keys = new string[]
            {
                txtNombre.Text,
                txtPaterno.Text,
                txtMaterno.Text,
                txtCorreo.Text
            };
            if (ValidatorService.AllRegister(keys, 4))
            {
                var tipo = Int32.Parse(Session["tipo"].ToString());
                if (tipo == 0)
                {
                    var usuario = new Usuario
                    {
                        IdUsuario = Int32.Parse(IdUsuario.Value.ToString()),
                        NombreUsuario = txtNombre.Text,
                        PaternoUsuario = txtPaterno.Text,
                        MaternoUsuario = txtMaterno.Text,
                        CorreoUsuario = txtCorreo.Text,
                        CarreraUsuario = Int32.Parse(ddlCarrera.SelectedItem.Value),
                        TipoUsuario = Int32.Parse(ddlTipo.SelectedItem.Value)
                    };

                    if (new DAOUsuario(new NewConnection()).UpdateAll(usuario))
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
                    var usuario = new Usuario
                    {
                        IdUsuario = Int32.Parse(IdUsuario.Value.ToString()),
                        NombreUsuario = txtNombre.Text,
                        PaternoUsuario = txtPaterno.Text,
                        MaternoUsuario = txtMaterno.Text,
                        CorreoUsuario = txtCorreo.Text
                    };

                    if (new DAOUsuario(new NewConnection()).UpdatePartial(usuario))
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmListaUsuarios.aspx");
        }
    }
}