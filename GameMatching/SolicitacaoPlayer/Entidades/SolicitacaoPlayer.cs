using GameMatching.Comum.Entidades;
using System;

namespace GameMatching.SolicitacaoPlayer.Entidades
{
    public class SolicitacaoPlayer : EntidadeBase
    {
        public Guid IdPartida { get; set; }
        public Guid IdJogo { get; set; }
        public Guid IdPlayer { get; set; }

        public SolicitacaoPlayer(Guid idJogo, Guid idPlayer)
        {
            Id = Guid.NewGuid();
            IdPartida = Guid.Empty;
            IdPlayer = idPlayer;
            IdJogo = idJogo;
        }
    }
}
