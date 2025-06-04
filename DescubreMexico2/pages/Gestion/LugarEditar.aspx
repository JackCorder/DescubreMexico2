<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="LugarEditar.aspx.cs" Inherits="DescubreMexico2.pages.Gestion.LugarEditar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
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
                        <h5 class="mb-0">Editar Lugar</h5>
                        <small class="text-muted">Editando: 
                            <asp:Label ID="Nombre" runat="server" Text=""></asp:Label>
                        </small>
                    </div>

                    <div class="card-body">
                        <asp:Label ID="lblIdLugar" runat="server" CssClass="form-text text-muted"></asp:Label>

                        <!-- Nombre -->
                        <div class="mb-3">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" MaxLength="50" CssClass="form-control" placeholder="Nombre Lugar" />
                        </div>

                        <!-- Descripcion -->
                        <div class="mb-3">
                            <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="150" CssClass="form-control" placeholder="Descripcion" />
                        </div>

                        <!-- Email -->
                        <div class="mb-3">
                            <asp:Label ID="lblCiudad" runat="server" Text="Ciudad" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtCiudad" runat="server" MaxLength="50" CssClass="form-control" placeholder="Ciudad de México" />
                        </div>

                       <!-- LATITUD -->
                        <div class="mb-3">
                            <asp:Label ID="lblLatitud" runat="server" CssClass="form-label" Text="Latitud"></asp:Label>
                            <asp:TextBox ID="txtLatitud" runat="server" CssClass="form-control" MaxLength="20" placeholder="Ej: 19.4326"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLatitud" runat="server" ControlToValidate="txtLatitud"
                                CssClass="text-danger" ErrorMessage="La latitud es requerida." Display="Dynamic" />
                            <asp:RegularExpressionValidator ID="revLatitud" runat="server" ControlToValidate="txtLatitud"
                                CssClass="text-danger" ErrorMessage="Ingrese una latitud válida."
                                ValidationExpression="^[-+]?[0-9]*\.?[0-9]+$" Display="Dynamic" />
                        </div>

                        <!-- LONGITUD -->
                        <div class="mb-3">
                            <asp:Label ID="lblLongitud" runat="server" CssClass="form-label" Text="Longitud"></asp:Label>
                            <asp:TextBox ID="txtLongitud" runat="server" CssClass="form-control" MaxLength="20" placeholder="Ej: -99.1332"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLongitud" runat="server" ControlToValidate="txtLongitud"
                                CssClass="text-danger" ErrorMessage="La longitud es requerida." Display="Dynamic" />
                            <asp:RegularExpressionValidator ID="revLongitud" runat="server" ControlToValidate="txtLongitud"
                                CssClass="text-danger" ErrorMessage="Ingrese una longitud válida."
                                ValidationExpression="^[-+]?[0-9]*\.?[0-9]+$" Display="Dynamic" />
                        </div>


                        <!-- Selección y subida de imagen -->
                        <div class="mb-3">
                            <label class="form-label">Seleccionar Foto</label>
                            <div class="row align-items-center">
                                <div class="col-md-6">
                                    <asp:FileUpload ID="SubeImagen" runat="server" CssClass="form-control" />
                                </div>
                                <div class="col-md-6">
                                    <asp:Button ID="btnSubeImagen" runat="server" Text="Subir" CssClass="btn btn-primary btn-sm" OnClick="btnSubeImagen_Click" />
                                </div>
                            </div>
                        </div>

                        <!-- Mostrar el nombre del archivo seleccionado -->
                        <div class="mb-3">
                            <asp:Label ID="lblNombreArchivo" runat="server" CssClass="form-text text-muted"></asp:Label>
                        </div>

                        <!-- Vista previa de la imagen -->
                        <div class="mb-3" id="divFoto" runat="server" Visible="false">
                            <asp:Label ID="lblFoto" runat="server" CssClass="form-label">Foto cargada:</asp:Label><br />
                            <asp:Image ID="imgFotoLugar" Width="150" Height="100" CssClass="img-thumbnail" runat="server" />
                            <br />
                            <asp:Label ID="urlFoto" runat="server" CssClass="text-muted"></asp:Label>
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
