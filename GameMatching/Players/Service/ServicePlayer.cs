using System;
using System.Collections.Generic;
using System.Linq;
using GameMatching.Comum.Repositories;
using GameMatching.Players.Interfaces;
using GameMatching.Players.Entidades;

namespace GameMatching.Players.Service
{
    public class ServicePlayer : IServicePlayer
    {
        public RepositoryBase _repositoryBase { get; set; }

        public ServicePlayer()
        {
             _repositoryBase = new RepositoryBase("/Banco/Player.json");
        }

        public void CadastrarPlayer(string nomePlayer)
        {
            var hasErrors = false;

            if (string.IsNullOrWhiteSpace(nomePlayer))
            {
                Console.WriteLine("O nome do Player não pode estar vazio");
                hasErrors = true;
            }

            if (VerificaSePlayerExiste(nomePlayer))
            {
                Console.WriteLine("Player já cadastrado");
                hasErrors = true;
            }

            if (!hasErrors)
            {
                var idPlayer = Guid.NewGuid();
                _repositoryBase.Cadastrar<Player>(new Player(idPlayer, nomePlayer));
                Console.WriteLine($"Player cadastrado com sucesso, Id: {idPlayer}");
            }
        }

        public List<Player> BuscarTodos()
        {
            return _repositoryBase.BuscarTodos<Player>();
        }

        private bool VerificaSePlayerExiste(string nome)
        {
            var players = BuscarTodos();

            if (players.Any(x => x.Nome == nome))
                return true;

            return false;
        }
    }
}
