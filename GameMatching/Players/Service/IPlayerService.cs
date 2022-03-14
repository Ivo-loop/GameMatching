using System.Collections.Generic;
using GameMatching.Players.Entidades;

namespace GameMatching.Players.Interfaces
{
    public interface IPlayerService
    {
        void CadastrarPlayer(string nomePlayer);
        List<Player> BuscarTodos();
    }
}
