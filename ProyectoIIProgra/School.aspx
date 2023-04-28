<%@ Page Title="Escuela" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="School.aspx.cs" Inherits="ProyectoIIProgra.School" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/MasterRelated.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="miDiv">
        <h1 class="miTitulo">Escuela</h1>
    </div>

    <div class="miDiv">
        <asp:GridView ID="GridSchool" runat="server" CssClass="miGrid">
        </asp:GridView>
    </div>

    <div class="miDiv">
        <div class="texto-con-input">
            <p class="miTexto">Código de escuela:</p>
            <asp:TextBox ID="TSchoolId" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Nombre de escuela:</p>
            <asp:TextBox ID="TSchoolName" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Descripción:</p>
            <asp:TextBox ID="TDescription" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Dirección:</p>
            <asp:TextBox ID="TAddress" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Teléfono:</p>
            <asp:TextBox ID="TPhone" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Código postal:</p>
            <asp:TextBox ID="TPostCode" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Dirección postal:</p>
            <asp:TextBox ID="TPostAddress" runat="server"></asp:TextBox>
        </div>
    </div>


    <div class="miDivButton">
        <asp:Button ID="BAgregar" runat="server" Text="Agregar" CssClass="button" OnClick="BAgregar_Click" />
        <asp:Button ID="BBorrar" runat="server" Text="Borrar" CssClass="button" OnClick="BBorrar_Click" />
        <asp:Button ID="BConsultar" runat="server" Text="Consultar" CssClass="button" OnClick="BConsultar_Click" />
        <asp:Button ID="BModificar" runat="server" Text="Modificar" CssClass="button" OnClick="BModificar_Click" />
    </div>

</asp:Content>
