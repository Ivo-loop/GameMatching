using GameMatching.Comum.Entidades;
using System;
using System.Collections.Generic;

namespace GameMatching.Partidas.Entidades
{
    public class Partida : EntidadeBase
    {
        public List<Guid> Players { get; set; }
        public Guid Jogo { get; set; }

        public Partida(Guid jogo)
        {
            Id = Guid.NewGuid();
            Players = new List<Guid>();
            Jogo = jogo;
        }
    }
}
