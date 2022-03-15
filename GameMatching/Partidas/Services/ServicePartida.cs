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

        public void Cadastrar(Guid idJogo)
        {
            if (!ExisteJogoCadastrado(idJogo))
            {
                Console.WriteLine($"Não existe jogo cadastrado para esse id: {idJogo}!");
                return;
            }

            if (JaExisteSolicitacaoPartida(idJogo, out var nomeJogo))
            {
                Console.WriteLine($"Solicitação já cadastrada para o jogo: {nomeJogo}!");
                return;
            }

            var partida = new Partida(idJogo);
            _repositoryBase.Cadastrar<Partida>(new Partida(idJogo));
            Console.WriteLine($"Partida cadastrada com sucesso, Id: {partida.Id}");
        }

        public List<Partida> BuscarTodos()
        {
            return _repositoryBase.BuscarTodos<Partida>();
        }

        private bool JaExisteSolicitacaoPartida(Guid idJogo, out string nomeJogo)
        {
            nomeJogo = "";
            
            var allResults = BuscarTodos();

            var result = allResults.Find(x => x.Jogo == idJogo);

            if (result != null) {
                nomeJogo = BuscarNomeJogo(idJogo);

                return true;
            }

            return false;
        }

        private string BuscarNomeJogo(Guid idJogo) => _serviceJogo.BuscarTodos().Find(x => x.Id == idJogo).Nome;

        private bool ExisteJogoCadastrado(Guid idJogo) => _serviceJogo.BuscarTodos().Any(x => x.Id == idJogo);
    }
}
