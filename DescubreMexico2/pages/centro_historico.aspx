<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="centro_historico.aspx.cs" Inherits="DescubreMexico2.pages.centro_historico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Centro Historico
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="py-5 bg-light">
      <div class="container">
        <div class="row align-items-center">
  
          <!-- Columna de imágenes -->
          <div class="col-md-4 mb-4 mb-md-0">
            <div class="d-flex flex-column gap-3">
              <img src="../assets/images/centro.jpg" alt="Centro Histórico de la Ciudad de México" class="img-fluid rounded shadow">
              <img src="../assets/images/centro2.jpg" alt="Centro Histórico de la Ciudad de México" class="img-fluid rounded shadow">
              <img src="../assets/images/centro3.jpg" alt="Centro Histórico de la Ciudad de México" class="img-fluid rounded shadow">
            </div>
          </div>

          <!-- Columna de texto -->
          <div class="col-md-8">
        
        
            <br />
              <h2 class="mb-3">Centro Histórico</h2>
          
                <p class="lead text-muted">
                  El Centro Histórico de la Ciudad de México es una zona que alberga una gran cantidad de edificios históricos y monumentos, como la <strong>Catedral Metropolitana</strong>, el <strong>Palacio de Bellas Artes</strong> y la <strong>Torre Latinoamericana</strong>.
                </p>
            <br />

            <!-- Reproductor de audio (no visible) -->
            <audio id="bg-centro-audio" loop>
              <source src="../assets/audios/audio_centro_historico.mp3" type="audio/mpeg">
              Tu navegador no soporta el elemento de audio.
            </audio>

            <!-- Botón de música -->
            <button id="music-centro-btn" class="btn btn-light shadow-sm rounded-circle p-3 music-button" title="Activar música centro">
              <i class="fas fa-music"></i>
            </button>
              <br />
              <section class="videos-contenedor">
                  <iframe width="560" height="315" src="https://www.youtube.com/embed/jxbRcW2YG24?si=byC_41d1i4Z4LmnD" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" referrerpolicy="strict-origin-when-cross-origin" allowfullscreen></iframe>
              </section>
        
          </div>
        </div>
      </div>
    </main>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="linksJs" runat="server">
    <script src="<%= ResolveUrl("~/Scripts/centroH.js") %>"></script>
</asp:Content>
