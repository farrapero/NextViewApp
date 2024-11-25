using System;
using System.Collections.Generic;
using NextViewApp.Models;

namespace NextViewApp
{
    public class Playlist
    {
        /// <summary>
        /// Identificador único da playlist.
        /// </summary>
        public int ID { get; set; }

        private string nome;

        /// <summary>
        /// Nome da playlist.
        /// </summary>
        public string Nome
        {
            get => nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O nome da playlist não pode ser vazio ou nulo.");
                }
                nome = value;
            }
        }

        /// <summary>
        /// Usuário proprietário da playlist.
        /// </summary>
        public Usuario Usuario { get; set; }

        /// <summary>
        /// Lista de conteúdos presentes na playlist.
        /// </summary>
        public List<Conteudo> Conteudos { get; set; }

        /// <summary>
        /// Construtor da classe Playlist.
        /// Inicializa a lista de conteúdos para evitar referências nulas.
        /// </summary>
        public Playlist()
        {
            Conteudos = new List<Conteudo>();
        }

        /// <summary>
        /// Adiciona um conteúdo à playlist.
        /// </summary>
        /// <param name="conteudo">Conteúdo a ser adicionado.</param>
        public void AdicionarConteudo(Conteudo conteudo)
        {
            if (conteudo == null)
            {
                throw new ArgumentNullException(nameof(conteudo), "O conteúdo não pode ser nulo.");
            }

            Conteudos.Add(conteudo);
        }

        /// <summary>
        /// Remove um conteúdo da playlist.
        /// </summary>
        /// <param name="conteudo">Conteúdo a ser removido.</param>
        public void RemoverConteudo(Conteudo conteudo)
        {
            if (conteudo == null || !Conteudos.Contains(conteudo))
            {
                throw new ArgumentException("O conteúdo especificado não existe na playlist.");
            }

            Conteudos.Remove(conteudo);
        }
    }
}
