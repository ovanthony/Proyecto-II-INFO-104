<%@ Page Title="Profesor" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="ProyectoIIProgra.Teacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/MasterRelated.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="miDiv">
        <h1 class="miTitulo">Profesor</h1>
    </div>

    <div class="miDiv">
        <asp:GridView ID="GridTeacher" runat="server" CssClass="miGrid">
        </asp:GridView>
    </div>

    <div class="miDiv">
        <div class="texto-con-input">
            <p class="miTexto">Código de profesor:</p>
            <asp:TextBox ID="TTeacherId" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Código de escuela:</p>
            <asp:TextBox ID="TSchoolId" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Nombre de profesor:</p>
            <asp:TextBox ID="TTeacherName" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Descripción:</p>
            <asp:TextBox ID="TDescription" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="miDivButton">
        <asp:Button ID="BAgregar" runat="server" Text="Agregar" CssClass="button" OnClick="BAgregar_Click" />
        <asp:Button ID="BBorrar" runat="server" Text="Borrar" CssClass="button" OnClick="BBorrar_Click" />
        <asp:Button ID="BConsultar" runat="server" Text="Consultar" CssClass="button" OnClick="BConsultar_Click" />
        <asp:Button ID="BModificar" runat="server" Text="Modificar" CssClass="button" OnClick="BModificar_Click" />
    </div>
</asp:Content>
