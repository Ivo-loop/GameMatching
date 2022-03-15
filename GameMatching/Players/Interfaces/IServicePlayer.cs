using System.Collections.Generic;
using GameMatching.Players.Entidades;

namespace GameMatching.Players.Interfaces
{
    public interface IServicePlayer
    {
        void CadastrarPlayer(string nomePlayer);
        List<Player> BuscarTodos();
    }
}
