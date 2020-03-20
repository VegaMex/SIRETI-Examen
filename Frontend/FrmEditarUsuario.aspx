<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmEditarUsuario.aspx.cs" Inherits="Frontend.FrmEditarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container px-3 py-3 mb-2">
        <h1 class="display-4 text-center">Edición de usuarios</h1>
        <form id="form2" runat="server" novalidate>
            <asp:HiddenField ID="IdUsuario" runat="server" />
            <div id="serverError" class="alert alert-danger" runat="server">
                Se ha producido un error en el servidor
            </div>
            <div class="form-row justify-content-center">
                <div class="col-md-4 mb-3">
                    <label for="txtNombre">Nombre</label>
                    <asp:TextBox ID="txtNombre" TextMode="SingleLine" class="form-control" autocomplete="off" runat="server" required></asp:TextBox>
                    <div class="invalid-feedback">
                        El nombre es obligatorio y debe tener un formato válido
                    </div>
                </div>
            </div>
            <div class="form-row justify-content-center">
                <div class="col-md-4 mb-3">
                    <label for="txtPaterno">Apellido paterno</label>
                    <asp:TextBox ID="txtPaterno" TextMode="SingleLine" class="form-control" autocomplete="off" runat="server" required></asp:TextBox>
                    <div class="invalid-feedback">
                        El apellido paterno es obligatorio y debe tener un formato válido
                    </div>
                </div>
            </div>
            <div class="form-row justify-content-center">
                <div class="col-md-4 mb-3">
                    <label for="txtMaterno">Apellido materno</label>
                    <asp:TextBox ID="txtMaterno" TextMode="SingleLine" class="form-control" autocomplete="off" runat="server" required></asp:TextBox>
                    <div class="invalid-feedback">
                        El apellido materno debe tener un formato válido
                    </div>
                </div>
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
                    <asp:Label ID="lblCarrera" AssociatedControlID="ddlCarrera" runat="server" Text="Carrera"></asp:Label>
                    <asp:DropDownList ID="ddlCarrera" class="form-control" runat="server" required></asp:DropDownList>
                    <div class="invalid-feedback">
                        Debe seleccionar una carrera
                    </div>
                </div>
            </div>
            <div class="form-row justify-content-center">
                <div class="col-md-4 mb-3">
                    <asp:Label ID="lblTipo" AssociatedControlID="ddlTipo" runat="server" Text="Tipo"></asp:Label>
                    <asp:DropDownList ID="ddlTipo" class="form-control" runat="server" required>
                        <asp:ListItem Selected="True" Value="2">Coordinador</asp:ListItem>
                        <asp:ListItem Value="3">Encargado</asp:ListItem>
                        <asp:ListItem Value="4">Docente</asp:ListItem>
                    </asp:DropDownList>
                    <div class="invalid-feedback">
                        Debe seleccionar un tipo
                    </div>
                </div>
            </div>
            <div class="form-row justify-content-center">
                <asp:Button ID="btnCancelar" class="btn btn-secondary mr-4" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                <asp:Button ID="btnEditar" class="btn btn-primary" runat="server" Text="Editar" OnClick="btnEditar_Click" />
            </div>
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
    <script src="js/frmEditarUsuario.js"></script>
</asp:Content>
