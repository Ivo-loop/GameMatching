using GameMatching.Comum.Entidades;

namespace GameMatching.Player.Entidades
{
    public class Player : EntidadeBase
    {
        public string Nome { get; set; }

        public Player(string nomePlayer)
        {
            Nome = nomePlayer;            
        }
    }
}
