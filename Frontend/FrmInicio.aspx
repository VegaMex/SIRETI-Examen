<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmInicio.aspx.cs" Inherits="Frontend.FrmInicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h1>Bienvenido(a) <% Response.Write(Session["nombre"].ToString()); %></h1>
    <h3><% Response.Write(Session["tipoString"].ToString());%></h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
