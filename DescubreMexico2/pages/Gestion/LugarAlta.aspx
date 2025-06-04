<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="LugarAlta.aspx.cs" Inherits="DescubreMexico2.pages.Gestion.LugarAlta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Alta Lugares
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
                        <h5 class="mb-0">Alta de Lugar</h5>
                    </div>
                    <div class="card-body">

                        <!-- NOMBRE -->
                        <div class="mb-3">
                            <asp:Label ID="lblNombre" runat="server" CssClass="form-label" Text="Nombre"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtNombre" ControlToValidate="txtNombre" CssClass="text-danger" runat="server" ErrorMessage="Nombre requerido"></asp:RequiredFieldValidator>
                        </div>


                        <!-- DESCRIPCION -->
                        <div class="mb-3">
                            <asp:Label ID="lblDescripcion" runat="server" CssClass="form-label" Text="Descripcion"></asp:Label>
                            <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="150" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtDescripcion" ControlToValidate="txtDescripcion" CssClass="text-danger" runat="server" ErrorMessage="Descripcion requerido"></asp:RequiredFieldValidator>
                        </div>
                        

                        <!-- CIUDAD -->
                        <div class="mb-3">
                            <asp:Label ID="lblCiudad" runat="server" CssClass="form-label" Text="Ciudad"></asp:Label>
                            <asp:TextBox ID="txtCiudad" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtCiudad" ControlToValidate="txtCiudad" CssClass="text-danger" runat="server" ErrorMessage="Ciudad requerido"></asp:RequiredFieldValidator>
                        </div>

                        <!-- LATITUD -->
                        <div class="mb-3">
                            <asp:Label ID="lblLatitud" runat="server" CssClass="form-label" Text="Latitud"></asp:Label>
                            <asp:TextBox ID="txtLatitud" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLatitud" runat="server" ControlToValidate="txtLatitud" CssClass="text-danger" ErrorMessage="Latitud requerida"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revLatitud" runat="server" ControlToValidate="txtLatitud" CssClass="text-danger"
                                ErrorMessage="Latitud inválida"
                                ValidationExpression="^[-+]?[0-9]*\.?[0-9]+$" />
                        </div>

                        <!-- LONGITUD -->
                        <div class="mb-3">
                            <asp:Label ID="lblLongitud" runat="server" CssClass="form-label" Text="Longitud"></asp:Label>
                            <asp:TextBox ID="txtLongitud" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLongitud" runat="server" ControlToValidate="txtLongitud" CssClass="text-danger" ErrorMessage="Longitud requerida"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revLongitud" runat="server" ControlToValidate="txtLongitud" CssClass="text-danger"
                                ErrorMessage="Longitud inválida"
                                ValidationExpression="^[-+]?[0-9]*\.?[0-9]+$" />
                        </div>


                        <!-- SUBIR FOTO -->
                        <div class="mb-3">
                            <label class="form-label">Seleccionar Foto</label>
                            <div class="row align-items-center">
                                <div class="col-md-6">
                                    <asp:FileUpload ID="SubeImagen" runat="server" CssClass="form-control" />
                                </div>
                                <div class="col-md-6">
                                    <asp:Button ID="btnSubeImagen" runat="server" Text="Subir Imagen" CssClass="btn btn-success"
                                        OnClick="btnSubeImagen_Click" />
                                </div>
                            </div>
                        </div>

                        <!-- VISTA PREVIA -->
                        <div class="mb-3" id="imgFoto" runat="server" visible="false">
                            <label class="form-label">Foto cargada:</label><br />
                            <asp:Image ID="imgFotoLugar" Width="150" Height="100" runat="server" CssClass="img-thumbnail" />
                            <br />
                            <asp:Label ID="urlFoto" runat="server" CssClass="text-muted"></asp:Label>
                        </div>

                        <!-- BOTÓN -->
                        <div class="text-center">
                            <asp:Button ID="btnGuardar" Visible="true" CssClass="btn btn-success px-4" runat="server"
                                Text="Registrar" OnClick="btnGuardar_Click" />
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
