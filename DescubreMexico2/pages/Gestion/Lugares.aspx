<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Lugares.aspx.cs" Inherits="DescubreMexico2.pages.Gestion.Lugares" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Gestión de Lugares
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
                        <h5 class="mb-0">Lugares</h5>
                        <button class="btn btn-success btn-sm" onClick="location.href='LugarAlta.aspx'; return false;">
                            <i class="fas fa-user-plus me-1"></i>Agregar Lugares
                        </button>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="GVLugares" runat="server"
                            CssClass="table table-bordered table-hover"
                            AutoGenerateColumns="false"
                            DataKeyNames="IdLugar"
                            OnRowDeleting="GVLugares_RowDeleting"
                            OnRowCommand="GVLugares_RowCommand"
                            OnRowEditing="GVLugares_RowEditing"
                            OnRowUpdating="GVLugares_RowUpdating"
                            OnRowCancelingEdit="GVLugares_RowCancelingEdit">

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
                                    DataField="IdLugar"
                                    HeaderText="Lugar Num"
                                    ItemStyle-Width="80px"
                                    ReadOnly="true" />

                                <asp:BoundField
                                    DataField="Nombre"
                                    HeaderText="Nombre"
                                    SortExpression="Nombre" />

                                <asp:BoundField
                                    DataField="Descripcion"
                                    HeaderText="Descripcion"
                                    SortExpression="Descripcion" />

                                <asp:BoundField
                                    DataField="Ciudad"
                                    HeaderText="Ciudad"
                                    SortExpression="Ciudad" />

                                <asp:BoundField 
                                    DataField="Latitud" 
                                    HeaderText="Latitud" 
                                    SortExpression="Latitud" 
                                    DataFormatString="{0:F6}" 
                                    HtmlEncode="false" />

                                <asp:BoundField
                                    DataField="Longitud"
                                    HeaderText="Longitud"
                                    SortExpression="Longitud"
                                    DataFormatString="{0:F6}"
                                    HtmlEncode="false" />

                                <asp:ImageField 
                                    DataImageUrlField="ImagenUrl" 
                                    HeaderText="Fotografía"
                                    ReadOnly="True"
                                    ItemStyle-Width="120px"
                                    ControlStyle-Width="120px"
                                    ControlStyle-Height="90px">
                                    <ItemStyle CssClass="text-center align-middle" />
                                    <ControlStyle CssClass="img-thumbnail rounded" />
                                </asp:ImageField>

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
<asp:Content ID="Content4" ContentPlaceHolderID="linksJs" runat="server">
</asp:Content>
