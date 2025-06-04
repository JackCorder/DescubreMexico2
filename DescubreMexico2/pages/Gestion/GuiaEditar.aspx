<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="GuiaEditar.aspx.cs" Inherits="DescubreMexico2.pages.Gestion.GuiaEditar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Editar Guia
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
                    <div class="card-header bg-warning text-dark">
                        <h5 class="mb-0">Editar Guia</h5>
                        <small class="text-muted">Editando: 
                            <asp:Label ID="GuiaNombre" runat="server" Text=""></asp:Label>
                        </small>
                    </div>

                    <div class="card-body">
                        <asp:Label ID="lblIdGuia" runat="server" CssClass="form-text text-muted"></asp:Label>

                        <!-- Nombre -->
                        <div class="mb-3">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" MaxLength="50" CssClass="form-control" placeholder="Nombre completo" />
                        </div>

                        <!-- Email -->
                        <div class="mb-3">
                            <asp:Label ID="lblEmail" runat="server" Text="Correo Electrónico" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" CssClass="form-control" placeholder="correo@ejemplo.com" />
                        </div>

                        <!-- Teléfono -->
                        <div class="mb-3">
                            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtTelefono" runat="server" MaxLength="10" CssClass="form-control" placeholder="5512345678" />
                        </div>

                        <!-- Experiencia -->
                        <div class="mb-3">
                            <asp:Label ID="lblExperiencia" runat="server" Text="Experiencia" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtExperiencia" runat="server" />
                        </div>
                        

                        <!-- Activo -->
                        <div class="mb-4">
                            <asp:Label ID="lblActivo" runat="server" Text="¿Activo?" CssClass="form-label me-2"></asp:Label>
                            <asp:CheckBox ID="chkActivo" runat="server" CssClass="form-check-input" />
                        </div>

                        <!-- Botón -->
                        <div class="text-center">
                            <asp:Button ID="btnGuardar" CssClass="btn btn-success px-4" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" />
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
