<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DescubreMexico2.pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Iniciar Sesión
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!-- Aquí puedes agregar CSS extra si quieres -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background: linear-gradient(to right, #f8f9fa, #dee2e6);
            height: 100vh;
        }

        .login-container {
            max-width: 400px;
            margin: auto;
            margin-top: 10%;
            background-color: white;
            padding: 2rem;
            border-radius: 1rem;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
        }

        .form-control:focus {
            border-color: #ffc107;
            box-shadow: 0 0 0 0.2rem rgba(255, 193, 7, 0.25);
        }

        .btn-login {
            background-color: #ffc107;
            border-color: #ffc107;
            color: #212529;
        }

        .btn-login:hover {
            background-color: #e0a800;
            border-color: #d39e00;
        }

        .login-title {
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <form id="form1" runat="server">
        <div class="container">
            <div class="login-container">
                <h4 class="text-center login-title mb-4">Iniciar Sesión</h4>

                <!-- Email -->
                <div class="mb-3">
                    <asp:Label ID="lblEmail" runat="server" Text="Correo electrónico" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="ejemplo@correo.com" required="true" />
                </div>

                <!-- Contraseña -->
                <div class="mb-3">
                    <asp:Label ID="lblPassword" runat="server" Text="Contraseña" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingrese su contraseña" required="true" />
                </div>

                <!-- Botón Ingresar -->
                <div class="d-grid">
                    <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-login" OnClick="btnLogin_Click" />
                </div>
                <br />
                <div class="d-grid">
                    <asp:Button ID="btnVolver" runat="server" Text="Volver a inicio" CssClass="btn btn-secondary" PostBackUrl="~/Index.aspx" />
                </div>

                <!-- Mensaje -->
                <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger text-center d-block mt-3" />
            </div>
        </div>
    </form>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="linksJs" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
