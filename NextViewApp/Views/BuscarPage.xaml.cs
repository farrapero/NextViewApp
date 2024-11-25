using System;
using System.Collections.ObjectModel;
using NextViewApp.Models;

namespace NextViewApp.Views
{
    public partial class BuscarPage : ContentPage
    {
        /// <summary>
        /// Lista de resultados da busca exibidos na interface.
        /// </summary>
        public ObservableCollection<Conteudo> ResultadosBusca { get; set; }

        /// <summary>
        /// Repositório simulado para buscar dados.
        /// </summary>
        private readonly PlaylistRepository repository;

        /// <summary>
        /// Construtor da página de busca.
        /// </summary>
        public BuscarPage()
        {
            InitializeComponent();
            ResultadosBusca = new ObservableCollection<Conteudo>();
            repository = new PlaylistRepository(); // Simula o repositório
            BindingContext = this;
        }

        /// <summary>
        /// Evento acionado quando o botão de busca é pressionado.
        /// </summary>
        /// <param name="sender">Componente SearchBar.</param>
        /// <param name="e">Argumentos do evento.</param>
        private async void OnSearchButtonPressed(object sender, EventArgs e)
        {
            var searchBar = (SearchBar)sender;
            string termoBusca = searchBar.Text;

            // Limpa os resultados anteriores
            ResultadosBusca.Clear();

            if (!string.IsNullOrWhiteSpace(termoBusca))
            {
                // Busca playlists com base no termo
                var resultados = repository.GetPlaylistsByName(termoBusca);

                if (resultados.Count > 0)
                {
                    foreach (var playlist in resultados)
                    {
                        // Adiciona os resultados ao ObservableCollection
                        ResultadosBusca.Add(new Conteudo { Titulo = playlist.Nome, Imagem = "playlist.png" });
                    }
                }
                else
                {
                    // Exibe mensagem se não encontrar resultados
                    await DisplayAlert("Sem resultados", "Nenhuma playlist encontrada para o termo buscado.", "OK");
                }
            }
            else
            {
                // Exibe alerta se o termo de busca estiver vazio
                await DisplayAlert("Busca inválida", "Por favor, insira um termo para buscar.", "OK");
            }
        }
    }
}
