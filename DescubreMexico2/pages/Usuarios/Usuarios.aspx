<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="DescubreMexico2.pages.Usuarios.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Gestión de Usuarios
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    <style>
        .btn-xs {
            padding: .25rem .4rem;
            font-size: .75rem;
            line-height: 1.5;
            border-radius: .2rem;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-lg-10">
                <div class="card shadow-sm">
                    <div class="card-header bg-dark text-white d-flex justify-content-between align-items-center">
                        <h5 class="mb-0">Usuarios</h5>
                        <button class="btn btn-success btn-sm" onClick="location.href='UsuarioAlta.aspx'; return false;">
                            <i class="fas fa-user-plus me-1"></i>Agregar Usuario
                        </button>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="GVUsuarios" runat="server"
                            CssClass="table table-bordered table-hover"
                            AutoGenerateColumns="false"
                            DataKeyNames="IdUsuario"
                            OnRowDeleting="GVUsuarios_RowDeleting"
                            OnRowCommand="GVUsuarios_RowCommand"
                            OnRowEditing="GVUsuarios_RowEditing"
                            OnRowUpdating="GVUsuarios_RowUpdating"
                            OnRowCancelingEdit="GVUsuarios_RowCancelingEdit">

                            <Columns>

                                <asp:ButtonField
                                    ButtonType="Button"
                                    CommandName="Select"
                                    ShowHeader="true"
                                    Text="Seleccionar"
                                    ControlStyle-CssClass="btn btn-outline-success btn-xs" />

                                <asp:CommandField
                                    ButtonType="Button"
                                    ShowDeleteButton="True"
                                    ShowHeader="True"
                                    ControlStyle-CssClass="btn btn-outline-danger btn-xs" />

                                <asp:CommandField
                                    ButtonType="Button"
                                    ShowEditButton="True"
                                    ShowHeader="True"
                                    ControlStyle-CssClass="btn btn-outline-primary btn-xs" />

                                <asp:BoundField
                                    DataField="IdUsuario"
                                    HeaderText="Usuario Num"
                                    ItemStyle-Width="80px"
                                    ReadOnly="true" />

                                <asp:BoundField
                                    DataField="Nombre"
                                    HeaderText="Nombre"
                                    SortExpression="Nombre" />

                                <asp:BoundField
                                    DataField="Email"
                                    HeaderText="Correo Electrónico"
                                    SortExpression="Email" />

                                <asp:BoundField
                                    DataField="Telefono"
                                    HeaderText="Teléfono"
                                    SortExpression="Telefono" />

                                <asp:BoundField
                                    DataField="TipoUsuario"
                                    HeaderText="Permisos"
                                    SortExpression="TipoUsuario" />

                                <asp:TemplateField HeaderText="Activo" ItemStyle-Width="70px">
                                    <ItemTemplate>
                                        <div class="text-center">
                                            <asp:CheckBox ID="Activo" runat="server"
                                                Checked='<%#Eval("Activo")%>'
                                                Enabled="false" />
                                        </div>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="text-center">
                                            <asp:CheckBox ID="ChkEditActivo" runat="server"
                                                Checked='<%#Eval("Activo")%>' />
                                        </div>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
</asp:Content>
