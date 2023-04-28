<%@ Page Title="Curso Estudiante" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="StudentCourse.aspx.cs" Inherits="ProyectoIIProgra.StudentCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/MasterRelated.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="miDiv">
        <h1 class="miTitulo">Curso Estudiante</h1>
    </div>

    <div class="miDiv">
        <asp:GridView ID="GridStudentCourse" runat="server" CssClass="miGrid">
        </asp:GridView>
    </div>

    <div class="miDiv">
        <div class="texto-con-input">
            <p class="miTexto">Código de estudiante:</p>
            <asp:TextBox ID="TStudentId" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Código de curso:</p>
            <asp:TextBox ID="TCourseId" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="miDivButton">
        <asp:Button ID="BAgregar" runat="server" Text="Agregar" CssClass="button" OnClick="BAgregar_Click" />
        <asp:Button ID="BBorrar" runat="server" Text="Borrar" CssClass="button" OnClick="BBorrar_Click" />
        <asp:Button ID="BConsultar" runat="server" Text="Consultar" CssClass="button" OnClick="BConsultar_Click" />
        <asp:Button ID="BModificar" runat="server" Text="Modificar" CssClass="button" OnClick="BModificar_Click" />
    </div>

</asp:Content>
