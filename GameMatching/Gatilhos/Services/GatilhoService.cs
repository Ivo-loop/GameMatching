using GameMatching.Comum.Repositories;
using GameMatching.Partidas.Entidades;
using GameMatching.SolicitacoesPlayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameMatching.Gatilhos.Services
{
    public class GatilhoService
    {
        public RepositoryBase _repositoryBasePartida { get; set; }
        public RepositoryBase _repositoryBaseSolicitacaoPlayer { get; set; }

        public GatilhoService()
        {
            _repositoryBasePartida = new RepositoryBase("/Banco/SolicitacoesParty.json");
            _repositoryBaseSolicitacaoPlayer = new RepositoryBase("/Banco/SolicitacoesPlayer.json");
        }

        public void ExcluirSolicitacoes(List<Guid> ids) 
        {
            var solicitacoes = _repositoryBaseSolicitacaoPlayer.BuscarTodos<SolicitacaoPlayer>();
            foreach (var solicitacao in solicitacoes.Where(x => ids.Contains(x.IdPlayer)).ToList())
            {
                var solicitacaoPlayerBanco = _repositoryBaseSolicitacaoPlayer.BuscarTodos<SolicitacaoPlayer>().FindIndex(x => x.Id == solicitacao.Id);
                _repositoryBaseSolicitacaoPlayer.Excluir<SolicitacaoPlayer>(solicitacaoPlayerBanco);
            }
        }

        public void ExcluirSolicitacaoPartida(int partida)
        {
            _repositoryBasePartida.Excluir<Partida>(partida);
        }

        public List<SolicitacaoPlayer> BuscarTodosServiceSolicitacaoPlayer() =>
          _repositoryBaseSolicitacaoPlayer.BuscarTodos<SolicitacaoPlayer>();

        public List<Partida> BuscarTodosServicePartida() =>
          _repositoryBasePartida.BuscarTodos<Partida>();

        public void AtualizarPartida(Partida partida) 
        {
          var partidaBanco = _repositoryBasePartida.BuscarTodos<Partida>().FindIndex(x => x.Id == partida.Id);
          
          ExcluirSolicitacaoPartida(partidaBanco);

          _repositoryBasePartida.Cadastrar<Partida>(partida);          
        }
    }
}
