using GameMatching.Comum.Entidades;
using System;

namespace GameMatching.Jogos.Entidades
{
    public class Jogo : EntidadeBase
    {
        public string Nome { get; private set; }
        public int QuantidadeJogadores { get; private set; }

        public Jogo(Guid id, string nome, int quantidadeJogadores)
        {
            Id = id;
            Nome = nome;
            QuantidadeJogadores = quantidadeJogadores;
        }
    }
}
