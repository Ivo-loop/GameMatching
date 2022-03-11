using GameMatching.Comum.Entidades;
using System;
using System.Collections.Generic;

namespace GameMatching.Partidas.Entidades
{
    public class Partida : EntidadeBase
    {
        public List<Guid> Players { get; set; }
        public Guid Jogo { get; set; }
    }
}
