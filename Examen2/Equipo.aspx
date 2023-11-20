<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Equipo.aspx.cs" Inherits="Examen2.Equipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/form.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
               <h1>Equipo</h1> 
    </div>
        <div>
    <br />
    <br />
    <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
        RowStyle-CssClass="rows" AllowPaging="True" />

    <br />
    <br />
    <br />
</div>
<div class="container text-center">
    Filtro: <asp:TextBox ID="txtFiltro" class="form-control" runat="server"></asp:TextBox>
    EquipoID: <asp:TextBox ID="tid" class="form-control" runat="server"></asp:TextBox>
    TipoEquipo: <asp:TextBox ID="ttipoEquipo" class="form-control" runat="server"></asp:TextBox>
    Modelo: <asp:TextBox ID="tModelo" class="form-control" runat="server"></asp:TextBox>
    UsuarioID: <asp:TextBox ID="tusuarioid" class="form-control" runat="server"></asp:TextBox>
</div>  
<div class="container text-center">
    <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Agregar" OnClick="Button1_Click" style="height: 34px" />
    <asp:Button ID="Button2" class="btn btn-outline-secondary" runat="server" Text="Borrar" OnClick="Button2_Click" />
    <asp:Button ID="Button3" runat="server" class="btn btn-outline-danger" Text="Modificar" OnClick="Button3_Click" style="width: 120px" />
    <asp:Button ID="Bconsulta" runat="server" class="btn btn-outline-danger" Text="Consultar" OnClick="Button4_Click" />
</div>
</asp:Content>


