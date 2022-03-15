using GameMatching.Comum.Repositories;
using GameMatching.Jogos.Entidades;
using GameMatching.Jogos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameMatching.Jogos.Services
{
    public class ServiceJogo : IServiceJogo
    {
        public RepositoryBase _repositoryBase { get; set; }

        public ServiceJogo()
        {
            _repositoryBase = new RepositoryBase("/Banco/Jogo.json");
        }

        public void Cadastrar(string nomeJogo, int quantidadeJogadores)
        {
            var hasErrors = false;

            if (string.IsNullOrWhiteSpace(nomeJogo))
            {
                Console.WriteLine("O nome do Jogo não pode estar vazio");
                hasErrors = true;
            }

            if (quantidadeJogadores < 1)
            {
                Console.WriteLine("A quantidade de jogadores em uma partida não pode ser menor que 1");
                hasErrors = true;
            }

            if (VerificaSeJogoJaCadastrado(nomeJogo))
            {
                Console.WriteLine("Jogo já cadastrado");
                hasErrors = true;
            }

            if (!hasErrors)
            {
                var idJogo = Guid.NewGuid();
                _repositoryBase.Cadastrar<Jogo>(new Jogo(idJogo, nomeJogo, quantidadeJogadores));
                Console.WriteLine($"Jogo cadastrado com sucesso, Id: {idJogo}");
            }
        }

        public List<Jogo> BuscarTodos()
        {
            return _repositoryBase.BuscarTodos<Jogo>();
        }

        private bool VerificaSeJogoJaCadastrado(string nome)
        {
            var jogos = BuscarTodos();

            if (jogos.Any(x => x.Nome == nome))
                return true;

            return false;
        }
    }
}
