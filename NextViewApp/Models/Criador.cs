using System;
using System.Collections.Generic;

namespace NextViewApp.Models
{
    public class Criador
    {
        /// <summary>
        /// Identificador único do criador.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Nome do criador.
        /// </summary>
        private string nome;
        public string Nome
        {
            get => nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O nome do criador não pode ser vazio ou nulo.");
                }
                nome = value;
            }
        }

        /// <summary>
        /// Lista de conteúdos criados pelo criador.
        /// </summary>
        public List<Conteudo> Conteudos { get; set; }

        /// <summary>
        /// Construtor da classe Criador.
        /// </summary>
        public Criador()
        {
            Conteudos = new List<Conteudo>();
        }
    }
}
