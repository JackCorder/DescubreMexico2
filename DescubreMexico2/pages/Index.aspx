<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DescubreMexico2.pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Descubriendo Mexico
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="hero d-flex align-items-center justify-content-center text-center text-white">
          <!-- Audio automático -->
          <audio autoplay loop>
              <source src="assets/audios/audio1.mp3" type="audio/mpeg">
              Tu navegador no soporta el elemento de audio.
          </audio>

    
        <div class="row">
            <div class="col-12">
                <h1>Descubriendo Mexico</h1>
                <p id="escribir-parrafo">Mexico es un pais hermoso y con una cultura muy rica. Descubre nuestro tour de la ciudad de Mexico.</p>
                <br />
                <a class="btn btn-primary" href="agendar.aspx">Agendar</a>
            </div>
        </div>
    
        <!-- Reproductor de audio (no visible) -->
        <audio id="bg-index-audio" loop>
          <source src="../assets/audios/audio2.mp3" type="audio/mpeg">
          Tu navegador no soporta el elemento de audio.
        </audio>

        <!-- Botón de música -->
        <button id="music-index-btn" class="btn btn-light shadow-sm rounded-circle p-3 music-button" title="Activar música centro">
          <i class="fas fa-music"></i>
        </button>

    </main>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="linksJs" runat="server">
    <script src="<%= ResolveUrl("~/Scripts/index.js") %>"></script>
</asp:Content>
