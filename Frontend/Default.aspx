<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Frontend.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>Sistema de Gestión de Residencias y Titulación</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/style.css" />
</head>
<body class="d-flex flex-column h-100">
    <header class="py-1">
        <div class="row flex-nowrap justify-content-between align-items-center">
            <div class="col-4 text-center">
                <h1><a class="header-logo text-dark" href="#">SIRETI</a></h1>
            </div>
            <div class="col-4 d-flex justify-content-end">
                <form runat="server">
                    <asp:Button ID="btnRegistrarse" class="btn btn-sm btn-outline-primary mr-2" runat="server" Text="Registrarse" OnClick="btnRegistrarse_Click" />
                    <asp:Button ID="btnIniciarSesion" class="btn btn-sm btn-outline-success" runat="server" Text="Iniciar Sesión" OnClick="btnIniciarSesion_Click" />
                </form>
            </div>
        </div>
    </header>
    <footer class="mt-auto py-3">
        <p>by <a href="http:\\www.itsur.edu.mx">Instituto Tecnológico Superior del Sur de Guanajuato</a>.</p>
        <p>Programación Web II</p>
    </footer>
    <script src="js/jquery-3.4.1.js"></script>
    <script src="js/bootstrap.js"></script>
</body>
</html>
