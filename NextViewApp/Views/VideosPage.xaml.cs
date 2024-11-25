using System.Collections.ObjectModel;
using NextViewApp.Models;

namespace NextViewApp.Views
{
    public partial class VideosPage : ContentPage
    {
        public ObservableCollection<Conteudo> ListaDeVideos { get; set; }

        public VideosPage()
        {
            InitializeComponent();
            ListaDeVideos = new ObservableCollection<Conteudo>
            {
                new Conteudo { Titulo = "Video 1", Thumbnail = "video1.png" },
                new Conteudo { Titulo = "Video 2", Thumbnail = "video2.png" },
                // Adicione mais vídeos conforme necessário
            };
            BindingContext = this;
        }

        private void OnUploadVideoClicked(object sender, EventArgs e)
        {
            DisplayAlert("Upload", "Funcionalidade de upload de vídeo simulada.", "OK");
        }
    }
}
