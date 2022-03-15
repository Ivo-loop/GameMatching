using System;
using System.Collections.Generic;
using GameMatching.Partidas.Entidades;

namespace GameMatching.SolicitacaoPlayer.Interfaces
{
    public interface IServiceSolicitacaoPlayer
    {
        void Cadastrar(string nomeJogo, string nomePlayer);

        List<GameMatching.SolicitacaoPlayer.Entidades.SolicitacaoPlayer> BuscarTodos();

        void ExcluirSolicitacoes(List<Guid> ids);
    }
}
