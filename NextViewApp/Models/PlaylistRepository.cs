using System;
using System.Collections.Generic;
using System.Linq;

namespace NextViewApp.Models
{
    public class PlaylistRepository
    {
        /// <summary>
        /// Lista simulando o banco de dados de playlists.
        /// </summary>
        private List<Playlist> playlists;

        /// <summary>
        /// Construtor da classe PlaylistRepository.
        /// Inicializa a lista de playlists.
        /// </summary>
        public PlaylistRepository()
        {
            playlists = new List<Playlist>();
        }

        /// <summary>
        /// Retorna todas as playlists.
        /// </summary>
        public List<Playlist> GetAllPlaylists()
        {
            return playlists;
        }

        /// <summary>
        /// Busca uma playlist pelo ID.
        /// </summary>
        /// <param name="id">ID da playlist.</param>
        public Playlist GetPlaylistByID(int id)
        {
            return playlists.FirstOrDefault(p => p.ID == id);
        }

        /// <summary>
        /// Adiciona uma nova playlist.
        /// </summary>
        /// <param name="playlist">Playlist a ser adicionada.</param>
        public void AddPlaylist(Playlist playlist)
        {
            if (playlist == null)
            {
                throw new ArgumentNullException(nameof(playlist), "A playlist não pode ser nula.");
            }

            if (playlists.Any(p => p.ID == playlist.ID))
            {
                throw new ArgumentException("Uma playlist com este ID já existe.");
            }

            playlists.Add(playlist);
        }

        /// <summary>
        /// Atualiza uma playlist existente.
        /// </summary>
        /// <param name="playlist">Playlist com os dados atualizados.</param>
        public void UpdatePlaylist(Playlist playlist)
        {
            if (playlist == null)
            {
                throw new ArgumentNullException(nameof(playlist), "A playlist não pode ser nula.");
            }

            var existingPlaylist = GetPlaylistByID(playlist.ID);
            if (existingPlaylist == null)
            {
                throw new KeyNotFoundException("Playlist não encontrada.");
            }

            existingPlaylist.Nome = playlist.Nome;
            existingPlaylist.Usuario = playlist.Usuario;
            existingPlaylist.Conteudos = playlist.Conteudos;
        }

        /// <summary>
        /// Exclui uma playlist com base no ID.
        /// </summary>
        /// <param name="id">ID da playlist a ser excluída.</param>
        public void DeletePlaylist(int id)
        {
            var playlist = GetPlaylistByID(id);
            if (playlist == null)
            {
                throw new KeyNotFoundException("Playlist não encontrada.");
            }

            playlists.Remove(playlist);
        }

        /// <summary>
        /// Busca playlists pelo nome.
        /// </summary>
        /// <param name="nome">Nome parcial ou completo da playlist.</param>
        public List<Playlist> GetPlaylistsByName(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome da playlist não pode ser vazio ou nulo.");
            }

            return playlists.Where(p => p.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Busca todas as playlists de um usuário.
        /// </summary>
        /// <param name="usuarioID">ID do usuário.</param>
        public List<Playlist> GetPlaylistsByUsuario(int usuarioID)
        {
            return playlists.Where(p => p.Usuario?.ID == usuarioID).ToList();
        }
    }
}
