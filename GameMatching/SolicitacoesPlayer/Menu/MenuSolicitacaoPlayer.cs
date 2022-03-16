using GameMatching.Comum.Menus;
using GameMatching.SolicitacoesPlayer.Services;
using System;

namespace GameMatching.SolicitacoesPlayer.Menu
{
    public class MenuSolicitacaoPlayer : MenuBase
    {
        public override void Menu()
        {
            var service = new ServiceSolicitacaoPlayer();

            Console.WriteLine("");
            Console.WriteLine("MENU DE SOLICITAÇÃO DE PLAYER");
            Console.WriteLine("Escolha uma das opções...");
            Console.WriteLine("1. Cadastrar solicitação de player");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Insira o nome do jogo: ");
                    var nomeJogo = Console.ReadLine();
                    Console.WriteLine("Insira o nome do player: ");
                    var nomePlayer = Console.ReadLine();
                    service.Cadastrar(nomeJogo, nomePlayer);
                    Console.ReadLine();
                    Menu();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida, tente novamente...");
                    Console.ReadLine();
                    Menu();
                    break;
            }
        }
    }
}
