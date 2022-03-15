using System;
using System.Collections.Generic;
using GameMatching.Partidas.Entidades;

namespace GameMatching.Partidas.Interfaces
{
    public interface IServicePartida
    {
        void Cadastrar(Guid idJogo);

        List<Partida> BuscarTodos();
    }
}
