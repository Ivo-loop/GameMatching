using System;
using GameMatching.Comum.Menus;
using GameMatching.Jogos.Services;

namespace GameMatching.Jogos.Menu
{
    public class MenuJogo : MenuBase
    {
        public override void Menu() 
        {
            var service = new ServiceJogo();

            Console.WriteLine("");
            Console.WriteLine("MENU DE JOGO");
            Console.WriteLine("Escolha uma das opções...");
            Console.WriteLine("1. Cadastrar Jogo");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Insira o nome do jogo: ");
                    var nomeJogo = Console.ReadLine();
                    Console.WriteLine("Insira a quantidade máxima de jogadores: ");
                    var qtdJogadores = Convert.ToInt32(Console.ReadLine());
                    service.Cadastrar(nomeJogo, qtdJogadores);
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