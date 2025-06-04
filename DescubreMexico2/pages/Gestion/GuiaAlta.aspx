<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="GuiaAlta.aspx.cs" Inherits="DescubreMexico2.pages.Gestion.GuiaAlta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Alta de Usuario
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .card {
            border-radius: 1rem;
        }

        .form-label {
            font-weight: 500;
        }

        .text-danger {
            font-size: 0.875rem;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-lg-8">
                <div class="card shadow">
                    <div class="card-header bg-primary text-white">
                        <h5 class="mb-0">Alta de Guia</h5>
                    </div>
                    <div class="card-body">

                        <!-- NOMBRE -->
                        <div class="mb-3">
                            <asp:Label ID="lblNombre" runat="server" CssClass="form-label" Text="Nombre"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtNombre" ControlToValidate="txtNombre" CssClass="text-danger" runat="server" ErrorMessage="Nombre requerido"></asp:RequiredFieldValidator>
                        </div>

                        <!-- EMAIL -->
                        <div class="mb-3">
                            <asp:Label ID="lblEmail" runat="server" CssClass="form-label" Text="Correo Electrónico"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtEmail" ControlToValidate="txtEmail" CssClass="text-danger" runat="server" ErrorMessage="Correo requerido"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" ControlToValidate="txtEmail" CssClass="text-danger" runat="server"
                                ErrorMessage="Correo inválido"
                                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" />
                        </div>

                        <!-- TELÉFONO -->
                        <div class="mb-3">
                            <asp:Label ID="lblTelefono" runat="server" CssClass="form-label" Text="Teléfono"></asp:Label>
                            <asp:TextBox ID="txtTelefono" runat="server" MaxLength="15" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtTelefono" ControlToValidate="txtTelefono" CssClass="text-danger" runat="server" ErrorMessage="Teléfono requerido"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revTelefono" ControlToValidate="txtTelefono" CssClass="text-danger" runat="server"
                                ErrorMessage="Formato de teléfono inválido"
                                ValidationExpression="^\d{7,15}$" />
                        </div>

                        <!-- EXPERIENCIA -->
                        <div class="mb-3">
                            <asp:Label ID="lblExperiencia" runat="server" CssClass="form-label" Text="Experiencia"></asp:Label>
                            <asp:TextBox ID="txtExperiencia" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtExperiencia" CssClass="text-danger" runat="server" ErrorMessage="Experiencia requerido"></asp:RequiredFieldValidator>
                        </div>

                        <!-- BOTÓN -->
                        <div class="text-center">
                            <asp:Button ID="btnGuardar" Visible="true" CssClass="btn btn-success px-4" runat="server"
                                Text="Guardar Guia" OnClick="btnGuardar_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="linksJs" runat="server">
</asp:Content>
