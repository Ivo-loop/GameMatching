using GameMatching.Comum.Repositories;
using GameMatching.SolicitacoesPlayer.Entidades;
using GameMatching.SolicitacoesPlayer.Interfaces;
using GameMatching.Jogos.Entidades;
using GameMatching.Jogos.Services;
using GameMatching.Players.Service;
using GameMatching.Players.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using GameMatching.Gatilhos.Services;

namespace GameMatching.SolicitacoesPlayer.Services
{
    public class ServiceSolicitacaoPlayer : IServiceSolicitacaoPlayer
    {
        public RepositoryBase _repositoryBase { get; set; }
        private ServiceJogo _serviceJogo;
        private ServicePlayer _servicePlayer;
        private GatilhoService _gatilhoService;

        public ServiceSolicitacaoPlayer()
        {
            _repositoryBase = new RepositoryBase("/Banco/SolicitacoesPlayer.json");
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

            var solicitacaoPlayer = new SolicitacaoPlayer(jogo.Id, player.Id);

            if (!AtribuiPartida(solicitacaoPlayer, jogo)) {
                _repositoryBase.Cadastrar<SolicitacaoPlayer>(solicitacaoPlayer);
                Console.WriteLine($"Solicitação de jogador cadastrada com sucesso, Id: {solicitacaoPlayer.Id}");
            } else {
                Console.WriteLine("Partida foi montada com sucesso, retirando a solicitação de players e de partida!");
            }
        }

        public List<SolicitacaoPlayer> BuscarTodos()
        {
            return _repositoryBase.BuscarTodos<SolicitacaoPlayer>();
        }

        public void ExcluirSolicitacoes(List<Guid> ids) 
        {
            var solicitacoes = _repositoryBase.BuscarTodos<SolicitacaoPlayer>().Where(x => ids.Contains(x.Id)).ToList();

            foreach (var solicitacao in solicitacoes)
            {
                var solicitacaoPlayerBanco = _repositoryBase.BuscarTodos<SolicitacaoPlayer>().FindIndex(x => x.Id == solicitacao.Id);
                _repositoryBase.Excluir<SolicitacaoPlayer>(solicitacaoPlayerBanco);
            }
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

        private bool AtribuiPartida(SolicitacaoPlayer solicitacaoPlayer, Jogo jogo) 
        {
            var partida = _gatilhoService.BuscarTodosServicePartida().Find(x => x.Jogo == jogo.Id);

            if (partida != null) 
            {
                solicitacaoPlayer.IdPartida = partida.Id;

                partida.Players.Add(solicitacaoPlayer.IdPlayer);
                _gatilhoService.AtualizarPartida(partida);


                var solicitacoesPlayer = _gatilhoService.BuscarTodosServiceSolicitacaoPlayer().Where(x => x.IdJogo == partida.Jogo).ToList();
                
                var quantidadeMaximaAtingida = false;

                foreach (var solicitacao in solicitacoesPlayer) {
                    if ((solicitacoesPlayer.Count + 1) == jogo.QuantidadeJogadores) {
                        quantidadeMaximaAtingida = true;

                        break;
                    }

                    partida.Players.Add(solicitacao.IdPlayer);
                }

                if (quantidadeMaximaAtingida)
                    _gatilhoService.ExcluirSolicitacoes(partida.Players);


                if (partida.Players.Count >= jogo.QuantidadeJogadores)
                {
                    ExcluirSolicitacoes(partida.Players);

                    var qtdPartidasBanco = _gatilhoService.BuscarTodosServicePartida().Count;

                    var partidaBanco = BuscarTodos().FindIndex(x => partida.Id == x.Id);

                    if (qtdPartidasBanco ==  1){
                        partidaBanco = 0;
                    }
                    else{
                        var auxiliar = partidaBanco;
                        partidaBanco = auxiliar * -1;
                        
                    }
                    
                    _gatilhoService.ExcluirSolicitacaoPartida(partidaBanco);

                    return true;
                }
            }

            return false;
        }
    }
}
