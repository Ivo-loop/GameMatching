using System.Collections.Generic;
using GameMatching.Jogos.Entidades;

namespace GameMatching.Jogos.Interfaces
{
    public interface IServiceJogo
    {
        void Cadastrar(string nomeJogo, int quantidadeJogadores);
        List<Jogo> BuscarTodos();
    }
}
