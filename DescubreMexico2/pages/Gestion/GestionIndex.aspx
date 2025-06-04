<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="GestionIndex.aspx.cs" Inherits="DescubreMexico2.pages.Gestion.GestionIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Gestion
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
                        <h5 class="mb-0">Recorridos</h5>
                        <button class="btn btn-success btn-sm" onClick="location.href='RecorridoAlta.aspx'; return false;">
                            <i class="fas fa-map-marked-alt me-1"></i>Agregar Recorrido
                        </button>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="GVRecorridos" runat="server"
                            CssClass="table table-bordered table-hover"
                            AutoGenerateColumns="false"
                            DataKeyNames="IdRecorrido"
                            OnRowDeleting="GVRecorridos_RowDeleting"
                            OnRowCommand="GVRecorridos_RowCommand"
                            OnRowDataBound="GVRecorridos_RowDataBound"
                            OnRowEditing="GVRecorridos_RowEditing"
                            OnRowUpdating="GVRecorridos_RowUpdating"
                            OnRowCancelingEdit="GVRecorridos_RowCancelingEdit">

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
                                    DataField="IdRecorrido"
                                    HeaderText="ID"
                                    ReadOnly="true"
                                    ItemStyle-Width="50px" />

                                <asp:BoundField
                                    DataField="Titulo"
                                    HeaderText="Título"
                                    SortExpression="Titulo" />

                                <asp:TemplateField HeaderText="Tipo de Recorrido">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTipoRecorrido" runat="server" Text='<%# Eval("TipoRecorrido") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DDLTipoRecorrido" runat="server" CssClass="form-control" Width="200px">
                                           
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField
                                    DataField="DuracionHoras"
                                    HeaderText="Duración (hrs)"
                                    SortExpression="DuracionHoras" 
                                    ItemStyle-Width="100px"/>

                                <asp:BoundField
                                    DataField="Precio"
                                    HeaderText="Precio"
                                    DataFormatString="{0:C}"
                                    SortExpression="Precio"
                                    HtmlEncode="false" 
                                    ItemStyle-Width="100px"/>

                                <asp:TemplateField HeaderText="Dificultad" SortExpression="Dificultad">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDificultad" runat="server" Text='<%# Eval("Dificultad") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlDificultad" runat="server" CssClass="form-control" Width="150px">
                                            <asp:ListItem Text="Baja" Value="baja"></asp:ListItem>
                                            <asp:ListItem Text="Media" Value="media"></asp:ListItem>
                                            <asp:ListItem Text="Alta" Value="alta"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField
                                    DataField="MaxParticipantes"
                                    HeaderText="Máx. Participantes"
                                    SortExpression="MaxParticipantes" 
                                    ItemStyle-Width="100px"/>

                                <asp:TemplateField HeaderText="Guía">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuiaNombre" runat="server" Text='<%# Eval("GuiaNombre") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DDLGuia" runat="server" CssClass="form-control" Width="200px">
                                           
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Activo" ItemStyle-Width="70px">
                                    <ItemTemplate>
                                        <div class="text-center">
                                            <asp:CheckBox ID="ChkActivo" runat="server"
                                                Checked='<%# Eval("Activo") %>'
                                                Enabled="false" />
                                        </div>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="text-center">
                                            <asp:CheckBox ID="ChkEditActivo" runat="server"
                                                Checked='<%# Bind("Activo") %>' />
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
