using GameMatching.Comum.Entidades;
using System;

namespace GameMatching.Players.Entidades
{
    public class Player : EntidadeBase
    {
        public string Nome { get; set; }

        public Player(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
