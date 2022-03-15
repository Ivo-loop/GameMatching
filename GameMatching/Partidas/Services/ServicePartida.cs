using GameMatching.Comum.Repositories;
using GameMatching.Partidas.Entidades;
using GameMatching.Partidas.Interfaces;
using GameMatching.Jogos.Entidades;
using GameMatching.Jogos.Services;
using GameMatching.Gatilhos.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameMatching.Partidas.Services
{
    public class ServicePartida : IServicePartida
    {
        public RepositoryBase _repositoryBase { get; set; }
        private ServiceJogo _serviceJogo;
        private GatilhoService _gatilhoService;

        public ServicePartida()
        {
            _repositoryBase = new RepositoryBase("/Banco/SolitacoesParty.json");
            _serviceJogo = new ServiceJogo();
            _gatilhoService = new GatilhoService();
        }

        public void Cadastrar(string nomeJogo)
        {
            if (!ExisteJogoCadastrado(nomeJogo, out var jogo))
            {
                Console.WriteLine($"Não existe jogo cadastrado para o nome: {nomeJogo}!");
                return;
            }

            if (JaExisteSolicitacaoPartida(jogo.Id))
            {
                Console.WriteLine($"Solicitação já cadastrada para o nome: {nomeJogo}!");
                return;
            }

            var partida = new Partida(jogo.Id);

            if (!AtribuiSolicitacaoPlayer(partida, jogo.QuantidadeJogadores)) {
                _repositoryBase.Cadastrar<Partida>(partida);
                Console.WriteLine($"Partida cadastrada com sucesso, Id: {partida.Id}");
            } else {
                Console.WriteLine("Partida foi montada com sucesso, retirando a solicitação de players e de partida!");
            }
        }

        public List<Partida> BuscarTodos()
        {
            return _repositoryBase.BuscarTodos<Partida>();
        }

        private bool JaExisteSolicitacaoPartida(Guid idJogo)
        {
            var allResults = BuscarTodos();

            var result = allResults.Find(x => x.Jogo == idJogo);

            if (result != null) 
                return true;

            return false;
        }

        private bool ExisteJogoCadastrado(string nomeJogo, out Jogo jogo) 
        { 
            jogo = _serviceJogo.BuscarTodos().Find(x => x.Nome == nomeJogo);

            if (jogo != null)
                return true;

            return false;
        }

        private bool AtribuiSolicitacaoPlayer(Partida partida, int quantidadeMaxima) 
        {
            var solicitacoesPlayer = _gatilhoService.BuscarTodosServiceSolicitacaoPlayer().Where(x => x.IdJogo == partida.Jogo).ToList();

            Console.WriteLine(solicitacoesPlayer.Count);

            var quantidadeMaximaAtingida = false;

            foreach (var solicitacao in solicitacoesPlayer) {
                if ((partida.Players.Count + 1) == quantidadeMaxima) {
                    quantidadeMaximaAtingida = true;

                    break;
                }

                partida.Players.Add(solicitacao.IdPlayer);
            }

            if (quantidadeMaximaAtingida) {
                _gatilhoService.ExcluirSolicitacoes(partida.Players);

                return true;
            }

            return false;
        }
    }
}
