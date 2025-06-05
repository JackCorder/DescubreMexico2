<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="AgendaAlta.aspx.cs" Inherits="DescubreMexico2.pages.Gestion.AgendaAlta" %>
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
                    <div class="card-header bg-primary text-white">
                        <h5 class="mb-0">Alta de Guia</h5>
                    </div>
                    <div class="card-body">

                        <div class="col-md-4">
                            <label for="ddlNuevoRecorrido">Recorrido:</label>
                            <asp:DropDownList ID="ddlNuevoRecorrido" runat="server" CssClass="form-control">
                                
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label for="txtNuevaFecha">Fecha:</label>
                            <asp:TextBox ID="txtNuevaFecha" runat="server" CssClass="form-control" TextMode="Date" />
                        </div>
                        <div class="col-md-4">
                            <label for="txtNuevaHora">Hora:</label>
                            <asp:TextBox ID="txtNuevaHora" runat="server" CssClass="form-control" TextMode="Time" />
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
