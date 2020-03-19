<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLogin.aspx.cs" Inherits="Frontend.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>Iniciar sesión</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/style.css" />
</head>
<body>
    <header class="py-1">
        <div class="row flex-nowrap justify-content-between align-items-center">
            <div class="col-4 text-center">
                <h1><a class="header-logo text-dark" href="#">SIRETI</a></h1>
            </div>
        </div>
    </header>

    <div class="container px-3 py-3 mb-2">
        <h1 class="display-4 text-center">Iniciar Sesión</h1>
        <form id="form1" runat="server" novalidate>
            <div id="serverError" class="alert alert-danger" runat="server">
                Se ha producido un error en el servidor
            </div>
            <div class="form-row justify-content-center">
                <div class="col-md-4 mb-3">
                    <label for="txtCorreo">Correo electrónico</label>
                    <asp:TextBox ID="txtCorreo" TextMode="Email" class="form-control" autocomplete="off" runat="server" required></asp:TextBox>
                    <div class="invalid-feedback">
                        El correo electrónico es obligatorio y debe tener un formato válido
                    </div>
                </div>
            </div>
            <div class="form-row justify-content-center">
                <div class="col-md-4 mb-3">
                    <label for="txtContra">Contraseña</label>
                    <asp:TextBox ID="txtContra" TextMode="Password" class="form-control" autocomplete="off" runat="server" required></asp:TextBox>
                    <div class="invalid-feedback">
                        La contraseña es obligatoria y debe tener un formato válido
                    </div>
                </div>
            </div>
            <div class="form-row justify-content-center">
                <asp:Button ID="btnIniciarSesion" class="btn btn-primary" runat="server" Text="Iniciar Sesión" OnClick="btnIniciarSesion_Click" />
            </div>
        </form>
    </div>

    <footer class="mt-auto py-3">
        <p>by <a href="http:\\www.itsur.edu.mx">Instituto Tecnológico Superior del Sur de Guanajuato</a>.</p>
        <p>Programación Web II</p>
    </footer>
    <script src="js/jquery-3.4.1.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/regex.js"></script>
    <script src="js/frmLogin.js"></script>
</body>
</html>
