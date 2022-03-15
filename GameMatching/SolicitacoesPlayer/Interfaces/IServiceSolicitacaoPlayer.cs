using System;
using System.Collections.Generic;
using GameMatching.SolicitacoesPlayer.Entidades;

namespace GameMatching.SolicitacoesPlayer.Interfaces
{
    public interface IServiceSolicitacaoPlayer
    {
        void Cadastrar(string nomeJogo, string nomePlayer);

        List<SolicitacaoPlayer> BuscarTodos();

        void ExcluirSolicitacoes(List<Guid> ids);
    }
}
