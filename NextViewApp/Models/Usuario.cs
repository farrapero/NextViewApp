namespace NextViewApp.Models
{
    public class Usuario
    {
        /// <summary>
        /// Identificador único do usuário.
        /// </summary>
        public int ID { get; set; }

        private string nome;

        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string Nome
        {
            get => nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O nome do usuário não pode ser vazio ou nulo.");
                }
                nome = value;
            }
        }

        private string email;

        /// <summary>
        /// E-mail do usuário.
        /// </summary>
        public string Email
        {
            get => email;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                {
                    throw new ArgumentException("O e-mail fornecido é inválido.");
                }
                email = value;
            }
        }

        /// <summary>
        /// Lista de playlists pertencentes ao usuário.
        /// </summary>
        public List<Playlist> Playlists { get; set; }

        /// <summary>
        /// Construtor da classe Usuario.
        /// Inicializa a lista de playlists.
        /// </summary>
        public Usuario()
        {
            Playlists = new List<Playlist>();
        }

        /// <summary>
        /// Adiciona uma playlist ao usuário.
        /// </summary>
        /// <param name="playlist">Playlist a ser adicionada.</param>
        public void AdicionarPlaylist(Playlist playlist)
        {
            if (playlist == null)
            {
                throw new ArgumentNullException(nameof(playlist), "A playlist não pode ser nula.");
            }

            if (Playlists.Any(p => p.ID == playlist.ID))
            {
                throw new ArgumentException("A playlist já existe na lista do usuário.");
            }

            Playlists.Add(playlist);
        }

        /// <summary>
        /// Remove uma playlist do usuário.
        /// </summary>
        /// <param name="playlist">Playlist a ser removida.</param>
        public void RemoverPlaylist(Playlist playlist)
        {
            if (playlist == null || !Playlists.Contains(playlist))
            {
                throw new ArgumentException("A playlist especificada não existe na lista do usuário.");
            }

            Playlists.Remove(playlist);
        }
    }
}
