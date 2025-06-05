<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="RecorridoEditar.aspx.cs" Inherits="DescubreMexico2.pages.Gestion.RecorridoEditar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Editar Recorrido
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
                        <h5 class="mb-0">Recorrido</h5>
                    </div>

                    <div class="card-body">
                        <asp:Label ID="lblIdRecorrido" runat="server" CssClass="form-text text-muted"></asp:Label>

                        <!-- Titulo -->
                        <div class="mb-3">
                            <asp:Label ID="lblTitulo" runat="server" Text="Título" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtTitulo" runat="server" MaxLength="50" CssClass="form-control" placeholder="Título del recorrido" />
                        </div>

                        <!-- Descripción -->
                        <div class="mb-3">
                            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" Rows="4" runat="server" CssClass="form-control" placeholder="Descripción del recorrido" />
                        </div>

                        <!-- Tipo Recorrido -->
                        <div class="mb-3">
                            <asp:Label ID="lblTipo" runat="server" Text="Tipo de Recorrido" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlTipoRecorrido" runat="server" CssClass="form-control">
                                
                            </asp:DropDownList>
                        </div>

                        <!-- Duración en horas -->
                        <div class="mb-3">
                            <asp:Label ID="lblDuracion" runat="server" Text="Duración (horas)" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtDuracionHoras" runat="server" TextMode="Number" CssClass="form-control" />
                        </div>

                        <!-- Precio -->
                        <div class="mb-3">
                            <asp:Label ID="lblPrecio" runat="server" Text="Precio" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtPrecio" runat="server" TextMode="Number" CssClass="form-control" />
                        </div>

                        <!-- Dificultad -->
                        <div class="mb-3">
                            <asp:Label ID="lblDificultad" runat="server" Text="Dificultad" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlDificultad" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Baja" Value="baja" />
                                <asp:ListItem Text="Media" Value="media" />
                                <asp:ListItem Text="Alta" Value="alta" />
                            </asp:DropDownList>
                        </div>

                        <!-- Max. Participantes -->
                        <div class="mb-3">
                            <asp:Label ID="lblMaxParticipantes" runat="server" Text="Máx. Participantes" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtMaxParticipantes" runat="server" TextMode="Number" CssClass="form-control" />
                        </div>

                        <!-- Guía -->
                        <div class="mb-3">
                            <asp:Label ID="lblGuia" runat="server" Text="Guía Asignado" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlGuia" runat="server" CssClass="form-control">
                                
                            </asp:DropDownList>
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
    <br /><br /><br />


    <!-- Tabla de Recorrido Lugares -->
    <div class="container mt-3">
        <div class="card shadow">
            <div class="card-header bg-secondary text-white">
                <h5 class="mb-0">Lugares del Recorrido</h5>
            </div>
            <div class="card-body">

                <!-- Inputs para agregar nuevo -->
                <div class="row mb-3">
                    <div class="col-md-5">
                        <asp:Label ID="lblIdLugarNuevo" runat="server" Text="Lugar" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="ddlIdLugarNuevo" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2 d-flex align-items-end">
                        <asp:Button ID="btnAgregarLugar" runat="server" Text="Agregar" CssClass="btn btn-primary w-100" OnClick="btnAgregarLugar_Click" />
                    </div>
                </div>
                <br>
                <!-- Tabla para mostrar los lugares del recorrido -->
                <asp:GridView ID="gvLugaresRecorrido" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered"
                    DataKeyNames="IdRecorridoLugar" OnRowCommand="gvLugaresRecorrido_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="IdRecorridoLugar" HeaderText="ID RLugar" Visible="False" />
                        <asp:BoundField DataField="IdRecorrido" HeaderText="ID Recorrido" Visible="False" />
                        <asp:BoundField DataField="IdLugar" HeaderText="ID Lugar" Visible="False" />
                        <asp:BoundField DataField="Lugar" HeaderText="Nombre Lugar" />
                        <asp:ImageField DataImageUrlField="ImagenUrl" HeaderText="Imagen" ControlStyle-Width="60px" ControlStyle-Height="60px" />

                        <asp:ButtonField ButtonType="Button" CommandName="Eliminar" Text="Eliminar" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
    <br><br><br>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="linksJs" runat="server">
</asp:Content>
