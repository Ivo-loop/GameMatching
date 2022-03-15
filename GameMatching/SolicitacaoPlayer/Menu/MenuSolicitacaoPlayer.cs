using GameMatching.Comum.Menus;
using GameMatching.SolicitacaoPlayer.Services;
using System;

namespace GameMatching.SolicitacaoPlayer.Menu
{
    public class MenuSolicitacaoPlayer : MenuBase
    {
        public override void Menu()
        {
            var service = new ServiceSolicitacaoPlayer();

            Console.WriteLine("Solicitação de Player");
            while (true)
            {
                Console.WriteLine("1. Cadastradar Solicitação de Jogador");
                Console.WriteLine("0. Voltar");
                Console.Write("Seleciona a Opção Desejada: ");
                switch (Console.Read())
                {
                    case '1':
                        Console.ReadLine();
                        Console.Title = "Cadastro de partida";
                        Console.WriteLine("Insira o nome do jogo: ");
                        var nomeJogo = Console.ReadLine();

                        Console.WriteLine("Insira o nome do player: ");
                        var nomePlayer = Console.ReadLine();

                        service.Cadastrar(nomeJogo, nomePlayer);
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Comando inválido");
                        break;
                }
            }
        }
    }
}
