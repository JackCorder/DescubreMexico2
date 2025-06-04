<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="galeria.aspx.cs" Inherits="DescubreMexico2.pages.galeria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Galería
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <main class="py-5 bg-light">
      <div class="container">
        <div class="row justify-content-center">
          <article class="col-md-10">
              <h2>Nuestra Galería</h2>
                <br /><br />
            <!-- Inicio Carrusel -->
            <div id="carouselExampleFade" class="carousel slide carousel-fade shadow-lg rounded overflow-hidden" data-bs-ride="carousel">
              <div class="carousel-inner">
                <div class="carousel-item active">
                  <img src="../assets/images/carrusel.jpg" class="d-block w-100 img-fluid rounded" alt="Ángel de la Independencia">
                  <div class="carousel-caption d-none d-md-block bg-dark bg-opacity-50 rounded p-2">
                    <h5>Ángel de la Independencia</h5>
                    <p>Uno de los monumentos más icónicos de la Ciudad de México.</p>
                  </div>
                </div>
                <div class="carousel-item">
                  <img src="../assets/images/carrusel2.jpg" class="d-block w-100 img-fluid rounded" alt="Palacio de Bellas Artes">
                  <div class="carousel-caption d-none d-md-block bg-dark bg-opacity-50 rounded p-2">
                    <h5>Palacio de Bellas Artes</h5>
                    <p>Un majestuoso recinto cultural y arquitectónico.</p>
                  </div>
                </div>
                <div class="carousel-item">
                  <img src="../assets/images/carrusel3.jpg" class="d-block w-100 img-fluid rounded" alt="Centro Histórico">
                  <div class="carousel-caption d-none d-md-block bg-dark bg-opacity-50 rounded p-2">
                    <h5>Centro Histórico</h5>
                    <p>El corazón de la historia y cultura de la ciudad.</p>
                  </div>
                </div>
                <div class="carousel-item">
                  <img src="../assets/images/carrusel4.jpg" class="d-block w-100 img-fluid rounded" alt="Centro Histórico">
                  <div class="carousel-caption d-none d-md-block bg-dark bg-opacity-50 rounded p-2">
                    <h5>Centro Histórico</h5>
                    <p>El corazón de la historia y cultura de la ciudad.</p>
                  </div>
                </div>
                <div class="carousel-item">
                  <img src="../assets/images/carrusel5.jpg" class="d-block w-100 img-fluid rounded" alt="Centro Histórico">
                  <div class="carousel-caption d-none d-md-block bg-dark bg-opacity-50 rounded p-2">
                    <h5>Centro Histórico</h5>
                    <p>El corazón de la historia y cultura de la ciudad.</p>
                  </div>
                </div>
                <div class="carousel-item">
                    <img src="../assets/images/carrusel6.jpg" class="d-block w-100 img-fluid rounded" alt="Centro Histórico">
                    <div class="carousel-caption d-none d-md-block bg-dark bg-opacity-50 rounded p-2">
                    <h5>Centro Histórico</h5>
                    <p>El corazón de la historia y cultura de la ciudad.</p>
                    </div>
                </div>
              </div>
              <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="prev">
                <span class="carousel-control-prev-icon bg-dark rounded-circle p-2" aria-hidden="true"></span>
                <span class="visually-hidden">Anterior</span>
              </button>
              <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="next">
                <span class="carousel-control-next-icon bg-dark rounded-circle p-2" aria-hidden="true"></span>
                <span class="visually-hidden">Siguiente</span>
              </button>
            </div>
            <!--Final Carrusel-->


          </article>
        </div>
        <br /><br />
        <article class="row g-4">

          <!-- Video 1 -->
          <div class="col-md-6">
            <div class="card shadow-sm">
              <video class="w-100 rounded" controls>
                <source src="../assets/videos/video1.mp4" type="video/mp4">
                Tu navegador no soporta el video.
              </video>
              <div class="card-body">
                <h5 class="card-title">Paseo de la Reforma</h5>
                <p class="card-text">Una de las avenidas más emblemáticas de la Ciudad de México.</p>
              </div>
            </div>
          </div>

          <!-- Video 2 -->
          <div class="col-md-6">
            <div class="card shadow-sm">
              <video class="w-100 rounded" controls>
                <source src="../assets/videos/video3.mp4" type="video/mp4">
                Tu navegador no soporta el video.
              </video>
              <div class="card-body">
                <h5 class="card-title">Monumento a la Revolución</h5>
                <p class="card-text">Majestuosa construcción dedicada a conmemorar la Revolución Mexicana.</p>
              </div>
            </div>
          </div>

        </article>


        <br /><br />
        <section class="d-flex justify-content-center">
          <div class="col-md-10">
            <div id="map" style="width: 100%; height: 400px;"></div>
          </div>
        </section>
    
        <!-- Reproductor de audio (no visible) -->
        <audio id="bg-galeria-audio" loop>
          <source src="../assets/audios/audio1.mp3" type="audio/mpeg">
          Tu navegador no soporta el elemento de audio.
        </audio>

        <!-- Botón de música -->
        <button id="music-galeria-btn" class="btn btn-light shadow-sm rounded-circle p-3 music-button" title="Activar música centro">
          <i class="fas fa-music"></i>
        </button>


      </div>
    </main>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="linksJs" runat="server">
    <script src="<%= ResolveUrl("~/Scripts/galeria.js") %>"></script>
</asp:Content>
