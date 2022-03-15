using System;
using GameMatching.Partidas.Menu;
using GameMatching.Jogos.Menu;
using GameMatching.Players.Menu;
using GameMatching.SolicitacoesPlayer.Menu;

namespace GameMatching
{
    public class Program
    {
        static void Main(string[] args)
        {
            StartMenu();
        }

        public static void StartMenu()
        {
            Console.ReadLine();
            Console.Title = "GameMatching";
            Console.WriteLine("GAMEMATCHING");
            Console.WriteLine("Escolha um dos menus a seguir: ");
            Console.WriteLine("1. Menu de Player");
            Console.WriteLine("2. Menu de Jogo");
            Console.WriteLine("3. Menu de Solicitação Player");
            Console.WriteLine("4. Menu de Solicitação Partida");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Title = "Menu de Player";
                    var menuPlayer = new MenuPlayer();
                    menuPlayer.Menu();
                    break;
                case "2":
                    Console.Title = "Menu de Jogo";
                    var menuJogo = new MenuJogo();
                    menuJogo.Menu();
                    break;
                case "3":
                    Console.Title = "Menu de Solicitação de Player";
                    var menuSolicitacaoPlayer = new MenuSolicitacaoPlayer();
                    menuSolicitacaoPlayer.Menu();
                    break;
                case "4":
                    Console.Title = "Menu de Solicitação de Partida";
                    var menuPartida = new MenuPartida();
                    menuPartida.Menu();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção Inválida, tente novamente...");
                    break;
            }
            StartMenu();
        }
    }
}
