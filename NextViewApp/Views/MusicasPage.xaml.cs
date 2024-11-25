using System.Collections.ObjectModel;
using NextViewApp.Models;

namespace NextViewApp.Views
{
    public partial class MusicasPage : ContentPage
    {
        public ObservableCollection<Conteudo> ListaDeMusicas { get; set; }

        public MusicasPage()
        {
            InitializeComponent();
            ListaDeMusicas = new ObservableCollection<Conteudo>
            {
                new Conteudo { Titulo = "Música 1", CapaAlbum = "musica1.png" },
                new Conteudo { Titulo = "Música 2", CapaAlbum = "musica2.png" },
                // Adicione mais músicas conforme necessário
            };
            BindingContext = this;
        }

        private void OnUploadMusicaClicked(object sender, EventArgs e)
        {
            DisplayAlert("Upload", "Funcionalidade de upload de música simulada.", "OK");
        }
    }
}
