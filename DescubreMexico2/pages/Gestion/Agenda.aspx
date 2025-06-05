<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Agenda.aspx.cs" Inherits="DescubreMexico2.pages.Gestion.Agenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
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
                        <h5 class="mb-0">Agendas</h5>
                        <button class="btn btn-success btn-sm" onClick="location.href='AgendaAlta.aspx'; return false;">
                            <i class="fas fa-map-marked-alt me-1"></i>Agregar Agenda
                        </button>
                    </div>
                    <div class="card-body">
                       

                        <asp:GridView ID="GVAgendas" runat="server"
                            CssClass="table table-bordered table-hover"
                            AutoGenerateColumns="false"
                            DataKeyNames="IdAgenda"
                            OnRowDeleting="GVAgendas_RowDeleting"
                            OnRowDataBound="GVAgendas_RowDataBound"
                            OnRowEditing="GVAgendas_RowEditing"
                            OnRowUpdating="GVAgendas_RowUpdating"
                            OnRowCancelingEdit="GVAgendas_RowCancelingEdit">

                            <Columns>

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
                                    DataField="IdAgenda"
                                    HeaderText="ID"
                                    ReadOnly="true"
                                    ItemStyle-Width="50px" />

                                <asp:TemplateField HeaderText="Recorrido">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecorrido" runat="server" Text='<%# Eval("Recorrido") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DDLRecorrido" runat="server" CssClass="form-control" Width="200px">
               
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Fecha" SortExpression="Fecha">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFecha" runat="server" Text='<%# Eval("Fecha", "{0:yyyy-MM-dd}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" Text='<%# Bind("Fecha", "{0:yyyy-MM-dd}") %>' TextMode="Date" />
                                    </EditItemTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Hora de Inicio" SortExpression="HoraInicio">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHora" runat="server" Text='<%# Eval("HoraInicio", "{0:HH\\:mm}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtHoraInicio" runat="server" CssClass="form-control" Text='<%# Bind("HoraInicio", "{0:HH\\:mm}") %>' TextMode="Time" />
                                    </EditItemTemplate>
                                    <ItemStyle Width="120px" />
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("Estado") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control" Width="150px">
                                            <asp:ListItem Text="Programado" Value="programado"></asp:ListItem>
                                            <asp:ListItem Text="Realizado" Value="realizado"></asp:ListItem>
                                            <asp:ListItem Text="Cancelado" Value="cancelado"></asp:ListItem>
                                        </asp:DropDownList>
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
