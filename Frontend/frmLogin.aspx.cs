using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.DAOS;
using Backend.Connections;
using Backend.Models;
using Backend.Security;

namespace Frontend
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            serverError.Visible = false;
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            var keys = new string[]
            {
                txtCorreo.Text,
                txtContra.Text
            };

            if (ValidatorService.AllRegister(keys, 1))
            {
                var email = txtCorreo.Text;
                var password = PasswordService.GetHash(txtContra.Text);
                Alumno alumno;
                Usuario usuario;
                alumno = new DAOAlumno(new NewConnection()).Login(email, password);

                if (alumno != null)
                {
                    Session["tipo"] = alumno.TipoAlumno;
                    Session["nombre"] = String.Format("{0} {1} {2}", alumno.NombreAlumno, alumno.PaternoAlumno, alumno.MaternoAlumno);
                    Response.Redirect("FrmInicio.aspx");
                }
                else
                {
                    usuario = new DAOUsuario(new NewConnection()).Login(email, password);

                    if (usuario != null)
                    {
                        Session["tipo"] = usuario.TipoUsuario;
                        if (usuario.TipoUsuario == 0)
                        {
                            Session["nombre"] = "ADMINISTRADOR";
                        }
                        else
                        {
                            Session["nombre"] = String.Format("{0} {1} {2}", usuario.NombreUsuario, usuario.PaternoUsuario, usuario.MaternoUsuario);
                        }
                        Response.Redirect("FrmInicio.aspx");
                    }
                    else
                    {
                        serverError.InnerText = "El usuario especificado no existe";
                        serverError.Visible = true;
                    }
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