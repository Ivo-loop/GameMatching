using System;
using System.Collections.Generic;
using GameMatching.Partidas.Entidades;

namespace GameMatching.Partidas.Interfaces
{
    public interface IServicePartida
    {
        void Cadastrar(string nomeJogo);

        List<Partida> BuscarTodos();
    }
}
