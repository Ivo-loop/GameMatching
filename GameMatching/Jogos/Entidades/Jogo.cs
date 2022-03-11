using GameMatching.Comum.Entidades;

namespace GameMatching.Jogos.Entidades
{
    public class Jogo : EntidadeBase
    {
        public string Nome { get; set; }
        public int QuantidadeJogadores { get; set; }
    }
}
