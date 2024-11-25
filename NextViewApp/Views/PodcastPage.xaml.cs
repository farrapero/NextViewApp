using System.Collections.ObjectModel;
using NextViewApp.Models;

namespace NextViewApp.Views
{
    public partial class PodcastPage : ContentPage
    {
        public ObservableCollection<Conteudo> ListaDePodcasts { get; set; }

        public PodcastPage()
        {
            InitializeComponent();
            ListaDePodcasts = new ObservableCollection<Conteudo>
            {
                new Conteudo { Titulo = "Podcast 1", CapaPodcast = "podcast1.png" },
                new Conteudo { Titulo = "Podcast 2", CapaPodcast = "podcast2.png" },
                // Adicione mais podcasts conforme necessário
            };
            BindingContext = this;
        }

        private void OnUploadPodcastClicked(object sender, EventArgs e)
        {
            DisplayAlert("Upload", "Funcionalidade de upload de podcast simulada.", "OK");
        }
    }
}
