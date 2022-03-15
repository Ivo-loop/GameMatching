using System;
using GameMatching.Comum.Menus;
using GameMatching.Players.Service;

namespace GameMatching.Players.Menu
{
    public class MenuPlayer : MenuBase
    {
        public override void Menu() 
        {
            var service = new ServicePlayer();
            
            Console.WriteLine("");
            Console.WriteLine("MENU DE PLAYER");
            Console.WriteLine("Escolha uma das opções...");
            Console.WriteLine("1. Cadastrar Player");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Insira o nome do player: ");
                    var nomePlayer = Console.ReadLine();
                    service.CadastrarPlayer(nomePlayer);
                    Console.ReadLine();
                    Menu();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente...");
                    Console.ReadLine();
                    Menu();
                    break;
            }
        }
    }
}