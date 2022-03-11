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
            _repositoryBase = new RepositoryBase("");
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
                _repositoryBase.CadastrarProduto<Jogo>(new Jogo(nomeJogo, quantidadeJogadores));
            }
        }

        public List<Jogo> BuscarTodos()
        {
            return _repositoryBase.BuscarTodosOsProdutos<Jogo>();
        }

        private bool VerificaSeJogoJaCadastrado(string nome)
        {
            var jogos = BuscarTodos();

            if (jogos.Any(x => x.Nome == nome))
            {
                return true;
            }

            return false;
        }
    }
}
