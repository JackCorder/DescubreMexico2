<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bellas_artes.aspx.cs" Inherits="DescubreMexico2.pages.bellas_artes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Bellas Artes
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
                  <img src="../assets/images/bellasartes.jpg" alt="Bellas Artes de la Ciudad de México" class="img-fluid rounded shadow">
                  <img src="../assets/images/bellasartes2.jpg" alt="Bellas Artes de la Ciudad de México" class="img-fluid rounded shadow">
                </div>
              </div>

              <!-- Columna de texto -->
              <div class="col-md-8">
    
                <br />
                  <h2 class="mb-3">Bellas Artes</h2>
          
                  <br />
                    <p class="lead text-muted">
                        Bellas Artes es un edificio de arquitectura neomudéjar, ubicado en la Ciudad de México, México. Fue construido en 1910 para conmemorar la independencia de México.  
                    </p>
                <br />
                <section class="videos-contenedor">
                    <iframe width="560" height="315" src="https://www.youtube.com/embed/LMAE9VNelFc?si=L9F99OznMusIQAby" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" referrerpolicy="strict-origin-when-cross-origin" allowfullscreen></iframe>    
                </section>
                <br />
                <audio id="bg-bellas-audio" loop>
                    <source src="../assets/audios/audio_bellasartes.mp3" type="audio/mpeg">
                    Tu navegador no soporta el elemento de audio.
                </audio>

                <!-- Botón de música -->
                <button id="music-bellas-btn" class="btn btn-light shadow-sm rounded-circle p-3 music-button" title="Activar música bellas">
                    <i class="fas fa-music"></i>
                </button>
              </div>
            </div>
          </div>
        </main>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="linksJs" runat="server">
    <script src="<%= ResolveUrl("~/Scripts/bellas-artes.js") %>"></script>
</asp:Content>
