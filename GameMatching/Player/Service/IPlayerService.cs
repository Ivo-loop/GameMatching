using System.Collections.Generic;

namespace GameMatching.Player.Interfaces
{
    public interface IPlayerService
    {
        void CadastrarPlayer(string nomePlayer);
        List<GameMatching.Player.Entidades.Player> BuscarTodos();
    }
}
