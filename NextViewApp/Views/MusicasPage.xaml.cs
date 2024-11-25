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
                new Conteudo { Titulo = "M�sica 1", CapaAlbum = "musica1.png" },
                new Conteudo { Titulo = "M�sica 2", CapaAlbum = "musica2.png" },
                // Adicione mais m�sicas conforme necess�rio
            };
            BindingContext = this;
        }

        private void OnUploadMusicaClicked(object sender, EventArgs e)
        {
            DisplayAlert("Upload", "Funcionalidade de upload de m�sica simulada.", "OK");
        }
    }
}
