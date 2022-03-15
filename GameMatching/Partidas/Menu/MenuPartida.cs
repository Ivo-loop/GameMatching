using GameMatching.Comum.Menus;
using GameMatching.Partidas.Services;
using System;
using System.Collections.Generic;

namespace GameMatching.Partidas.Menu
{
    public class MenuPartida : MenuBase
    {
        public override void Menu() 
        {
            var service = new ServicePartida();

            Console.WriteLine("MENU DE SOLICITAÇÃO DE PARTIDA");
            Console.WriteLine("Escolha uma das opções...");
            Console.WriteLine("1. Cadastrar Partida");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Title = "Cadastro de partida";
                    Console.WriteLine("Insira o guid do jogo: ");
                    var guidJogo = Guid.Parse(Console.ReadLine());
                    service.Cadastrar(guidJogo);
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
