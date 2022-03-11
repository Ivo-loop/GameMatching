using GameMatching.Comum.Entidades;

namespace GameMatching.Jogos.Entidades
{
    public class Jogo : EntidadeBase
    {
        public string Nome { get; private set; }
        public int QuantidadeJogadores { get; private set; }

        public Jogo(string nome, int quantidadeJogadores)
        {
            Nome = nome;
            QuantidadeJogadores = quantidadeJogadores;
        }
    }
}
