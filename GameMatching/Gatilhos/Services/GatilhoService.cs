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
            _repositoryBasePartida = new RepositoryBase("/Banco/SolitacoesParty.json");
            _repositoryBaseSolicitacaoPlayer = new RepositoryBase("/Banco/SolitacoesPlayer.json");
        }

        public void ExcluirSolicitacoes(List<Guid> ids) 
        {
            var solicitacoes = _repositoryBaseSolicitacaoPlayer.BuscarTodos<SolicitacaoPlayer>().Where(x => ids.Contains(x.Id)).ToList();

            solicitacoes.ForEach(x => _repositoryBaseSolicitacaoPlayer.Excluir<SolicitacaoPlayer>(x));
        }

        public void ExcluirSolicitacaoPartida(Partida partida) 
        {
            Console.WriteLine(partida.Id + "," + partida.Players.Count + "," + partida.Jogo);
            _repositoryBasePartida.Excluir<Partida>(partida);
        }

        public List<SolicitacaoPlayer> BuscarTodosServiceSolicitacaoPlayer() =>
          _repositoryBaseSolicitacaoPlayer.BuscarTodos<SolicitacaoPlayer>();

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
