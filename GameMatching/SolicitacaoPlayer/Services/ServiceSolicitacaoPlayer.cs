using GameMatching.Comum.Repositories;
using GameMatching.Partidas.Services;
using GameMatching.Partidas.Entidades;
using GameMatching.Partidas.Interfaces;
using GameMatching.SolicitacaoPlayer.Entidades;
using GameMatching.SolicitacaoPlayer.Interfaces;
using GameMatching.Jogos.Entidades;
using GameMatching.Jogos.Services;
using GameMatching.Players.Service;
using GameMatching.Players.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using GameMatching.Gatilhos.Services;

namespace GameMatching.SolicitacaoPlayer.Services
{
    public class ServiceSolicitacaoPlayer : IServiceSolicitacaoPlayer
    {
        public RepositoryBase _repositoryBase { get; set; }
        private ServiceJogo _serviceJogo;
        private ServicePlayer _servicePlayer;
        private GatilhoService _gatilhoService;

        public ServiceSolicitacaoPlayer()
        {
            _repositoryBase = new RepositoryBase("/Banco/SolitacoesPlayer.json");
            _serviceJogo = new ServiceJogo();
            _servicePlayer = new ServicePlayer();
            _gatilhoService = new GatilhoService();
        }

        public void Cadastrar(string nomeJogo, string nomePlayer)
        {
            if (!ExisteJogoCadastrado(nomeJogo, out var jogo))
            {
                Console.WriteLine($"Não existe jogo cadastrado para o nome: {nomeJogo}!");
                return;
            }

            if (!ExistePlayerCadastrado(nomePlayer, out var player))
            {
                Console.WriteLine($"Não existe player cadastrado para o nome: {nomePlayer}!");
                return;
            }

            var solicitacaoPlayer = new GameMatching.SolicitacaoPlayer.Entidades.SolicitacaoPlayer(jogo.Id, player.Id);

            if (!AtribuiPartida(solicitacaoPlayer, jogo)) {
                _repositoryBase.Cadastrar<GameMatching.SolicitacaoPlayer.Entidades.SolicitacaoPlayer>(solicitacaoPlayer);
                Console.WriteLine($"Solicitação de jogador cadastrada com sucesso, Id: {solicitacaoPlayer.Id}");
            } else {
                Console.WriteLine("Partida foi montada com sucesso, retirando a solicitação de players e de partida!");
            }
        }

        public List<GameMatching.SolicitacaoPlayer.Entidades.SolicitacaoPlayer> BuscarTodos()
        {
            return _repositoryBase.BuscarTodos<GameMatching.SolicitacaoPlayer.Entidades.SolicitacaoPlayer>();
        }

        public void ExcluirSolicitacoes(List<Guid> ids) 
        {
            var solicitacoes = _repositoryBase.BuscarTodos<GameMatching.SolicitacaoPlayer.Entidades.SolicitacaoPlayer>().Where(x => ids.Contains(x.Id)).ToList();

            solicitacoes.ForEach(x => _repositoryBase.Excluir<GameMatching.SolicitacaoPlayer.Entidades.SolicitacaoPlayer>(x));
        }

        private bool ExisteJogoCadastrado(string nomeJogo, out Jogo jogo) 
        { 
            jogo = _serviceJogo.BuscarTodos().Find(x => x.Nome == nomeJogo);

            if (jogo != null)
                return true;

            return false;
        }

        private bool ExistePlayerCadastrado(string nomePlayer, out Player player) 
        { 
            player = _servicePlayer.BuscarTodos().Find(x => x.Nome == nomePlayer);

            if (player != null)
                return true;

            return false;
        }

        private bool AtribuiPartida(GameMatching.SolicitacaoPlayer.Entidades.SolicitacaoPlayer solicitacaoPlayer, Jogo jogo) 
        {
            var partida = _gatilhoService.BuscarTodosServicePartida().Find(x => x.Jogo == jogo.Id);

            if (partida != null) 
            {
                Console.WriteLine("1");
                solicitacaoPlayer.IdPartida = partida.Id;

                partida.Players.Add(solicitacaoPlayer.IdPlayer);
                _gatilhoService.AtualizarPartida(partida);

                if (partida.Players.Count == jogo.QuantidadeJogadores)
                {
                    Console.WriteLine("2");
                   ExcluirSolicitacoes(partida.Players);
                   _gatilhoService.ExcluirSolicitacaoPartida(partida);

                   return true;
                }
            }

            return false;
        }
    }
}
