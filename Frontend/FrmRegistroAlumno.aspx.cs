using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.DAOS;
using Backend.Models;
using Backend.Security;
using Backend.Connections;

namespace Frontend
{
    public partial class FrmRegistroAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            serverError.Visible = false;
            if (!IsPostBack)
            {
                ddlCarrera.DataSource = new DAOCarrera(new NewConnection()).GetCarreras();
                ddlCarrera.DataValueField = "IdCarrera";
                ddlCarrera.DataTextField = "NombreCarrera";
                ddlCarrera.DataBind();
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            var keys = new string[]
            {
                txtControl.Text,
                txtNombre.Text,
                txtPaterno.Text,
                txtMaterno.Text,
                txtCorreo.Text,
                txtContra.Text,
                txtContraConfirm.Text
            };

            if (ValidatorService.AllRegister(keys, 0))
            {
                var alumno = new Alumno
                {
                    ControlAlumno = txtControl.Text,
                    NombreAlumno = txtNombre.Text,
                    PaternoAlumno = txtPaterno.Text,
                    MaternoAlumno = txtMaterno.Text,
                    CorreoAlumno = txtCorreo.Text,
                    ContraAlumno = txtContra.Text,
                    CarreraAlumno = Int32.Parse(ddlCarrera.SelectedItem.Value),
                    TipoAlumno = 1
                };
                if (new DAOAlumno(new NewConnection()).Insert(alumno))
                {
                    Response.Redirect("FrmLogin.aspx");
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmLogin.aspx");
        }
    }
}