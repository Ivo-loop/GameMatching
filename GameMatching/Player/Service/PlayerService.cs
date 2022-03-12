using System;
using System.Collections.Generic;
using System.Linq;
using GameMatching.Comum.Repositories;
using GameMatching.Player.Interfaces;

namespace GameMatching.Player.Service
{
    public class PlayerService : IPlayerService
    {
        public RepositoryBase _repositoryBase { get; set; }

        public PlayerService()
        {
             _repositoryBase = new RepositoryBase("Player.json");
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
                _repositoryBase.Cadastrar<Entidades.Player>(new Entidades.Player(nomePlayer));
            }
        }

        public List<GameMatching.Player.Entidades.Player> BuscarTodos()
        {
            return _repositoryBase.BuscarTodos<GameMatching.Player.Entidades.Player>();
        }

        private bool VerificaSePlayerExiste(string nome)
        {
            var players = BuscarTodos();

            if (players.Any(x => x.Nome == nome))
            {
                return true;
            }

            return false;
        }
    }
}
