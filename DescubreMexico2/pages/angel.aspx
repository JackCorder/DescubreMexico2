<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="angel.aspx.cs" Inherits="DescubreMexico2.pages.angel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Angel de la Independencia
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
              <img src="../assets/images/angel.jpg" alt="Angel de la Independencia de la Ciudad de México" class="img-fluid rounded shadow">
              <img src="../assets/images/angel3.jpg" alt="Angel de la Independencia de la Ciudad de México" class="img-fluid rounded shadow">
            </div>
          </div>

          <!-- Columna de texto -->
          <div class="col-md-8">
    
            <br />
              <h2 class="mb-3">Angel de la Independencia</h2>
          
              <br />
                <p class="lead text-muted">
                  Angel de la Independencia es un monumento ubicado en la Ciudad de México, México. Fue construido en 1910 para conmemorar la independencia de México.
                </p>
            <br />
            <section class="videos-contenedor">
                <iframe width="560" height="315" src="https://www.youtube.com/embed/_B9FpCsqD3Q?si=NH93zSfT0Raz7NPj" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" referrerpolicy="strict-origin-when-cross-origin" allowfullscreen></iframe>    
            </section>
            <br />
              <!-- Reproductor de audio (no visible) -->
            <audio id="bg-angel-audio" loop>
              <source src="../assets/audios/audio_angel.mp3" type="audio/mpeg">
              Tu navegador no soporta el elemento de audio.
            </audio>

            <!-- Botón de música -->
            <button id="music-angel-btn" class="btn btn-light shadow-sm rounded-circle p-3 music-button" title="Activar música ángel">
              <i class="fas fa-music"></i>
            </button>
          </div>
        </div>
      </div>
    </main>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="linksJs" runat="server">
    <script src="<%= ResolveUrl("~/Scripts/angel.js") %>"></script>
</asp:Content>
