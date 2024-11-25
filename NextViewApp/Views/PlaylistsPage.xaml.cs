using System.Collections.ObjectModel;
using System.Windows.Input;
using NextViewApp.Models;

namespace NextViewApp.Views
{
    public partial class PlaylistsPage : ContentPage
    {
        /// <summary>
        /// Lista observ�vel de playlists exibida na interface.
        /// </summary>
        public ObservableCollection<Playlist> ListaDePlaylists { get; set; }

        /// <summary>
        /// Comando para editar uma playlist.
        /// </summary>
        public ICommand EditarPlaylistCommand { get; set; }

        /// <summary>
        /// Comando para excluir uma playlist.
        /// </summary>
        public ICommand ExcluirPlaylistCommand { get; set; }

        /// <summary>
        /// Reposit�rio para simular opera��es com playlists.
        /// </summary>
        private readonly PlaylistRepository repository;

        public PlaylistsPage()
        {
            InitializeComponent();
            repository = new PlaylistRepository();

            // Carrega playlists iniciais no reposit�rio
            repository.AddPlaylist(new Playlist { ID = 1, Nome = "Favoritos" });
            repository.AddPlaylist(new Playlist { ID = 2, Nome = "Para Estudar" });

            // Inicializa a lista observ�vel com os dados do reposit�rio
            ListaDePlaylists = new ObservableCollection<Playlist>(repository.GetAllPlaylists());

            EditarPlaylistCommand = new Command<Playlist>(OnEditarPlaylist);
            ExcluirPlaylistCommand = new Command<Playlist>(OnExcluirPlaylist);

            BindingContext = this;
        }

        /// <summary>
        /// Evento acionado ao criar uma nova playlist.
        /// </summary>
        private async void OnCriarPlaylistClicked(object sender, EventArgs e)
        {
            string nome = await DisplayPromptAsync("Nova Playlist", "Digite o nome da nova playlist:");
            if (!string.IsNullOrWhiteSpace(nome))
            {
                var novaPlaylist = new Playlist { ID = ListaDePlaylists.Count + 1, Nome = nome };
                repository.AddPlaylist(novaPlaylist);
                ListaDePlaylists.Add(novaPlaylist);
            }
            else
            {
                await DisplayAlert("Erro", "O nome da playlist n�o pode ser vazio.", "OK");
            }
        }

        /// <summary>
        /// Evento acionado ao editar uma playlist.
        /// </summary>
        private async void OnEditarPlaylist(Playlist playlist)
        {
            if (playlist != null)
            {
                string novoNome = await DisplayPromptAsync("Editar Playlist", $"Digite o novo nome para '{playlist.Nome}':");
                if (!string.IsNullOrWhiteSpace(novoNome))
                {
                    playlist.Nome = novoNome;
                    repository.UpdatePlaylist(playlist);
                    // Atualiza a lista observ�vel
                    var index = ListaDePlaylists.IndexOf(playlist);
                    ListaDePlaylists[index] = playlist;
                }
                else
                {
                    await DisplayAlert("Erro", "O nome da playlist n�o pode ser vazio.", "OK");
                }
            }
        }

        /// <summary>
        /// Evento acionado ao excluir uma playlist.
        /// </summary>
        private async void OnExcluirPlaylist(Playlist playlist)
        {
            if (playlist != null)
            {
                bool confirmar = await DisplayAlert("Confirmar Exclus�o", $"Deseja excluir a playlist '{playlist.Nome}'?", "Sim", "N�o");
                if (confirmar)
                {
                    repository.DeletePlaylist(playlist.ID);
                    ListaDePlaylists.Remove(playlist);
                }
            }
        }
    }
}
