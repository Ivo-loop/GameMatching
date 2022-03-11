using GameMatching.Comum.Entidades;
using System;

namespace GameMatching.SolicitacaoPlayer.Entidades
{
    public class SolicitacaoPlayer : EntidadeBase
    {
        public Guid IdPartida { get; set; }
        public Guid IdJogo { get; set; }
    }
}
