<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmListaUsuarios.aspx.cs" Inherits="Frontend.FrmListaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <h1 class="display-4 text-center">Usuarios</h1>
        <div class="row col-4 d-flex justify-content-start my-2">
            <asp:Button ID="btnAgregar" CssClass="btn btn-success" runat="server" Text="Agregar nuevo usuario" OnClick="btnAgregar_Click" />
        </div>
        <asp:GridView ID="grvListaUsuarios" CssClass="table table-bordered table-striped" runat="server"
            OnRowCommand="grvListaUsuarios_RowCommand" DataKeyNames="IdUsuario">
            <Columns>
                <asp:BoundField DataField="IdUsuario" HeaderText="Clave" />
                <asp:BoundField DataField="NombreCompletoUsuario" HeaderText="Usuario" />
                <asp:BoundField DataField="CorreoUsuario" HeaderText="Correo" />
                <asp:BoundField DataField="CarreraUsuarioString" HeaderText="Carrera" />
                <asp:BoundField DataField="TipoUsuarioString" HeaderText="Tipo" />
                <asp:ButtonField CommandName="btnCambiarContra" ButtonType="Button" ControlStyle-CssClass="btn btn-warning" Text="Cambiar contraseña" />
                <asp:ButtonField CommandName="btnEditar" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Editar" />
                <asp:ButtonField CommandName="btnEliminar" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" />
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
    <script src="js/datatables.js"></script>
    <script src="js/frmListaUsuarios.js"></script>
</asp:Content>
