namespace NextViewApp.Models
{
    public class Conteudo
    {
        public string Tipo { get; set; }  // "Música", "Vídeo", "Podcast"
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string CapaAlbum { get; set; }
        public string CapaPodcast { get; set; }
        public string Thumbnail { get; set; }
        // Outras propriedades...
    }
}
