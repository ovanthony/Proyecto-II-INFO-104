<%@ Page Title="Estudiante" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="ProyectoIIProgra.Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/MasterRelated.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="miDiv">
        <h1 class="miTitulo">Estudiante</h1>
    </div>

    <div class="miDiv">
        <asp:GridView ID="GridStudent" runat="server" CssClass="miGrid">
        </asp:GridView>
    </div>

    <div class="miDiv">
        <div class="texto-con-input">
            <p class="miTexto">Código de estudiante:</p>
            <asp:TextBox ID="TStudentId" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Código de clase:</p>
            <asp:TextBox ID="TClassId" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Nombre de estudiante:</p>
            <asp:TextBox ID="TStudentName" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Número de estudiante:</p>
            <asp:TextBox ID="TStudentNumber" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Nota:</p>
            <asp:TextBox ID="TTotalGrade" runat="server"></asp:TextBox>
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
            <p class="miTexto">Correo:</p>
            <asp:TextBox ID="TEMail" runat="server"></asp:TextBox>
        </div>
    </div>


    <div class="miDivButton">
        <asp:Button ID="BAgregar" runat="server" Text="Agregar" CssClass="button" OnClick="BAgregar_Click" />
        <asp:Button ID="BBorrar" runat="server" Text="Borrar" CssClass="button" OnClick="BBorrar_Click" />
        <asp:Button ID="BConsultar" runat="server" Text="Consultar" CssClass="button" OnClick="BConsultar_Click" />
        <asp:Button ID="BModificar" runat="server" Text="Modificar" CssClass="button" OnClick="BModificar_Click" />
    </div>

</asp:Content>
