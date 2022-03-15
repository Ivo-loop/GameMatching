using GameMatching.Comum.Repositories;
using GameMatching.Partidas.Services;
using GameMatching.Partidas.Entidades;
using GameMatching.Partidas.Interfaces;
using GameMatching.SolicitacaoPlayer.Services;
using GameMatching.SolicitacaoPlayer.Entidades;
using GameMatching.SolicitacaoPlayer.Interfaces;
using GameMatching.Jogos.Entidades;
using GameMatching.Jogos.Services;
using GameMatching.Players.Service;
using GameMatching.Players.Entidades;
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
            _repositoryBasePartida = new RepositoryBase("/Banco/SolitacoesParty.json");
            _repositoryBaseSolicitacaoPlayer = new RepositoryBase("/Banco/SolitacoesPlayer.json");
        }

        public void ExcluirSolicitacoes(List<Guid> ids) 
        {
            var solicitacoes = _repositoryBaseSolicitacaoPlayer.BuscarTodos<GameMatching.SolicitacaoPlayer.Entidades.SolicitacaoPlayer>().Where(x => ids.Contains(x.Id)).ToList();

            solicitacoes.ForEach(x => _repositoryBaseSolicitacaoPlayer.Excluir<GameMatching.SolicitacaoPlayer.Entidades.SolicitacaoPlayer>(x));
        }

        public void ExcluirSolicitacaoPartida(Partida partida) 
        {
            _repositoryBasePartida.Excluir<Partida>(partida);
        }

        public List<GameMatching.SolicitacaoPlayer.Entidades.SolicitacaoPlayer> BuscarTodosServiceSolicitacaoPlayer() =>
          _repositoryBaseSolicitacaoPlayer.BuscarTodos<GameMatching.SolicitacaoPlayer.Entidades.SolicitacaoPlayer>();

        public List<Partida> BuscarTodosServicePartida() =>
          _repositoryBasePartida.BuscarTodos<Partida>();

        public void AtualizarPartida(Partida partida) 
        {
          var partidaBanco = _repositoryBasePartida.BuscarTodos<Partida>().Find(x => partida.Id == x.Id);

          ExcluirSolicitacaoPartida(partidaBanco);

          _repositoryBasePartida.Cadastrar<Partida>(partida);          
        }
    }
}
