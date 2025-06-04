<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="agendar.aspx.cs" Inherits="DescubreMexico2.pages.agendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Agendar Recorrido
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="formulario" class="py-5 bg-light">
      <div class="container">
        <div class="row justify-content-center">
          <div class="col-md-8">
            <div class="contenedor-form shadow-lg border-0 rounded-4">
              <div class="card-body p-5">
                <h2 class="mb-4 text-center">AGENDAR UN RECORRIDO</h2>
                <form id="formulario-tour" novalidate>
                  <div class="mb-3">
                    <label for="nombre" class="form-label">Nombre completo</label>
                    <input type="text" class="form-control" id="nombre" placeholder="Tu nombre" required>
                    <div class="invalid-feedback">El nombre solo puede contener letras y espacios.</div>
                  </div>

                  <div class="mb-3">
                    <label for="email" class="form-label">Correo electrónico</label>
                    <input type="email" class="form-control" id="email" placeholder="ejemplo@correo.com" required>
                    <div class="invalid-feedback">No ingresaste un correo electrónico válido.</div>
                  </div>

                  <div class="mb-3">
                    <label for="fecha" class="form-label">Fecha del recorrido</label>
                    <input type="date" class="form-control" id="fecha" required>
                    <div class="invalid-feedback">La fecha debe ser al menos 5 días después de hoy.</div>
                  </div>

                  <div class="mb-3">
                    <label for="personas" class="form-label">Número de personas</label>
                    <input type="number" class="form-control" id="personas" min="1" max="50" required>
                    <div class="invalid-feedback">El número debe estar entre 1 y 50.</div>
                  </div>

                  <div class="mb-3">
                    <label for="comentarios" class="form-label">Comentarios adicionales</label>
                    <textarea class="form-control" id="comentarios" rows="3" placeholder="¿Algo más que debamos saber?"></textarea>
                  </div>

                  <div class="d-grid">
                    <button type="submit" class="btn btn-primary btn-lg">Enviar solicitud</button>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </main>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="linksJs" runat="server">
    <script src="<%= ResolveUrl("~/Scripts/agendar.js") %>"></script>
</asp:Content>
