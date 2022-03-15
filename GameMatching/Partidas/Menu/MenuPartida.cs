using GameMatching.Comum.Menus;
using System;
using System.Collections.Generic;

namespace GameMatching.Partidas.Menu
{
    public class MenuPartida : MenuBase
    {
        public override void Menu() 
        {
            //var service = new ServicePartida();
            
            Console.WriteLine("");
            Console.WriteLine("MENU DE SOLICITAÇÃO DE PARTIDA");
            Console.WriteLine("Escolha uma das opções...");
            Console.WriteLine("1. Cadastrar Partida");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Insira o nome do jogo: ");
                    var nomeJogo = Console.ReadLine();
                    Console.WriteLine("Insira a quantidade de players na partida: ");
                    var qtdPlayers = Convert.ToInt32(Console.ReadLine());
                    var players = new List<string>();
                    for (int i = 0; i < qtdPlayers; i++)
                    {
                        Console.WriteLine($"Insira o nome do player {i + 1}: ");
                        players.Add(Console.ReadLine());
                    }
                    //service.Cadastrar(nomeJogo, players);
                    Console.ReadLine();
                    Menu();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Opção Inválida, tente novamente...");
                    Console.ReadLine();
                    Menu();
                    break;
            }
        }
    }
}
