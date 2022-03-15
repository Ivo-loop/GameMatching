using GameMatching.Comum.Repositories;
using GameMatching.Partidas.Entidades;
using GameMatching.Partidas.Interfaces;
using GameMatching.Jogos.Entidades;
using GameMatching.Jogos.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameMatching.Partidas.Services
{
    public class ServicePartida : IServicePartida
    {
        public RepositoryBase _repositoryBase { get; set; }
        private ServiceJogo _serviceJogo;

        public ServicePartida()
        {
            _repositoryBase = new RepositoryBase("/Banco/SolitacoesParty.json");
            _serviceJogo = new ServiceJogo();
        }

        public void Cadastrar(string nomeJogo)
        {
            if (!ExisteJogoCadastrado(nomeJogo, out var jogo))
            {
                Console.WriteLine($"Não existe jogo cadastrado para o jogo: {nomeJogo}!");
                return;
            }

            if (JaExisteSolicitacaoPartida(jogo.Id))
            {
                Console.WriteLine($"Solicitação já cadastrada para o jogo: {nomeJogo}!");
                return;
            }

            var partida = new Partida(jogo.Id);
            _repositoryBase.Cadastrar<Partida>(new Partida(jogo.Id));
            Console.WriteLine($"Partida cadastrada com sucesso, Id: {partida.Id}");
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
    }
}
